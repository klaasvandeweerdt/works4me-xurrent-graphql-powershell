<#
.SYNOPSIS
Chooses the correct binary at import time for the current PowerShell runtime and handles Desktop shim resolution.

.DESCRIPTION
- Windows PowerShell 5.1 (“Desktop”): forces TFM **net472** and:
  - Preloads common .NET Standard shim assemblies if they’re present in the TFM folder.
  - Installs an AppDomain.AssemblyResolve handler for the module lifetime and removes it on module unload.
- PowerShell 7+ ("Core"): selects the packaged binary for the known PowerShell runtime range:
  - PowerShell 7.4: net8.0
  - PowerShell 7.5: net9.0
  - PowerShell 7.6 and later: net10.0
- If the selected binary is missing, import aborts with an error. (No TFM fallback.)

.REQUIREMENTS
- Windows PowerShell 5.1 (Desktop) **or** PowerShell 7.4+ running on .NET 8+ (Core)

.COMPATIBILITY
- Desktop: .NET Framework with shimmed .NET Standard dependencies.
- Core: PowerShell 7.4+ with packaged binaries for the selected runtime TFM.
#>

# Determine preferred TFM for the current PowerShell edition/version
$here    = $PSScriptRoot
$binRoot = Join-Path $here 'bin'

if ($PSVersionTable.PSEdition -eq 'Desktop') {
    $tfm = 'net472'
}
else {
    switch ($PSVersionTable.PSVersion) {
        { $_.Major -eq 7 -and $_.Minor -eq 4 } { $tfm = 'net8.0'; break }
        { $_.Major -eq 7 -and $_.Minor -eq 5 } { $tfm = 'net9.0'; break }
        { $_.Major -eq 7 -and $_.Minor -ge 6 } { $tfm = 'net10.0'; break }
        default {
            throw "Unsupported PowerShell version: $($PSVersionTable.PSVersion)"
        }
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
