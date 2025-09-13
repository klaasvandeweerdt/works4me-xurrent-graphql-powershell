<#
.SYNOPSIS
Chooses the correct binary at import time (net8.0 on Core/.NET 8+ or net472 on Windows PowerShell) and handles Desktop shim resolution.

.DESCRIPTION
- Windows PowerShell 5.1 (“Desktop”): forces TFM **net472** and:
  - Preloads common .NET Standard shim assemblies if they’re present in the TFM folder.
  - Installs an AppDomain.AssemblyResolve handler for the module lifetime and removes it on module unload.
- PowerShell 7+ (“Core”): inspects the host’s runtime:
  - If running on **.NET 8 or later**, uses TFM **net8.0**.
  - If running on .NET 7 or earlier, import aborts with a clear upgrade message (requires PowerShell 7.4+ / .NET 8+).
- If the selected binary is missing, import aborts with an error. (No TFM fallback.)

.REQUIREMENTS
- Windows PowerShell 5.1 (Desktop) **or** PowerShell 7.4+ running on .NET 8+ (Core)

.COMPATIBILITY
- Desktop: .NET Framework with shimmed .NET Standard dependencies.
- Core: .NET 8+ only.
#>

# Determine preferred TFM (Core uses net8.0 on .NET 8+; Desktop uses net472)
$here    = $PSScriptRoot
$binRoot = Join-Path $here 'bin'

if ($PSVersionTable.PSEdition -eq 'Desktop') {
    $tfm = 'net472'
}
else {
    $fx    = [System.Runtime.InteropServices.RuntimeInformation]::FrameworkDescription  # ".NET 8.0.7", ".NET 9.0.x"
    $major = [int]([regex]::Match($fx, '(\d+)\.').Groups[1].Value)
    if ($major -ge 8) {
        $tfm = 'net8.0'
    } else {
        throw "This module requires PowerShell 7.4+ (.NET 8+). Detected: $fx. Please upgrade PowerShell: https://aka.ms/powershell"
    }
}

# Build candidate path and validate it exists
$binary  = [IO.Path]::Combine($binRoot, $tfm, 'Works4me.Xurrent.GraphQL.PowerShell.dll')
if (-not (Test-Path -LiteralPath $binary)) {
    throw "Module binary not found: $binary. The installation/package is incomplete for TFM '$tfm'."
}

$binPath = Join-Path $binRoot $tfm

# Desktop: install resolver + preload common shims for .NET Standard on .NET Framework
if ($PSVersionTable.PSEdition -eq 'Desktop') {
    $map = @{
        'System.Runtime.CompilerServices.Unsafe' = 'System.Runtime.CompilerServices.Unsafe.dll'
        'System.Memory'                          = 'System.Memory.dll'
        'System.Buffers'                         = 'System.Buffers.dll'
        'System.Numerics.Vectors'                = 'System.Numerics.Vectors.dll'
    }

    $script:__Resolver = [System.ResolveEventHandler]{
        param($s,$e)
        foreach ($name in $map.Keys) {
            if ($e.Name -like "$name,*") {
                $p = Join-Path $binPath $map[$name]
                if (Test-Path -LiteralPath $p) { return [Reflection.Assembly]::LoadFrom($p) }
            }
        }
        $null
    }
    [AppDomain]::CurrentDomain.add_AssemblyResolve($script:__Resolver)

    foreach ($dll in $map.Values) {
        $p = Join-Path $binPath $dll
        if (Test-Path -LiteralPath $p) { [void][Reflection.Assembly]::LoadFrom($p) }
    }
}

# Import the selected binary module
Import-Module -Name $binary -ErrorAction Stop

# Clean up the resolver when the module is removed
$ExecutionContext.SessionState.Module.OnRemove = {
    if ($script:__Resolver) {
        [AppDomain]::CurrentDomain.remove_AssemblyResolve($script:__Resolver)
        $script:__Resolver = $null
    }
}
