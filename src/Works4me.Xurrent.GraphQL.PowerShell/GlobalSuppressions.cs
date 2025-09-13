// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "PowerShell parameter binding requires array properties for correct cmdlet usage.")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "PowerShell cmdlets must catch all exceptions and translate them into ErrorRecords to provide consistent error handling to the user. Specific exceptions are handled first; the general catch ensures unexpected exceptions are reported cleanly without crashing the host.")]
[assembly: SuppressMessage("Style", "IDE0130:Namespace does not match folder structure", Justification = "Flattened Works4me.Xurrent.GraphQL.PowerShell.Commands to keep code structured per object.", Scope = "namespace", Target = "~N:Works4me.Xurrent.GraphQL.PowerShell.Commands")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Collection properties are settable to support serialization and data binding in entity models.")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "This is Xurrent entity name.", Scope = "type", Target = "~T:Works4me.Xurrent.GraphQL.PowerShell.Commands.SetXurrentCustomCollection")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "This is Xurrent entity name.", Scope = "type", Target = "~T:Works4me.Xurrent.GraphQL.PowerShell.Commands.NewXurrentCustomCollection")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "The enum defines type conversions.", Scope = "type", Target = "~T:Works4me.Xurrent.GraphQL.PowerShell.Enums.XurrentCustomFieldAs")]
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Keep signature in line.", Scope = "member", Target = "~M:Works4me.Xurrent.GraphQL.PowerShell.Logging.PowerShellLogger.Route(Works4me.Xurrent.GraphQL.PowerShell.Logging.PowerShellAmbientLogScope.Scope,Works4me.Xurrent.GraphQL.PowerShell.Logging.PowerShellLoggerOptions,Microsoft.Extensions.Logging.LogLevel,System.String,System.Exception,Microsoft.Extensions.Logging.EventId,System.Boolean)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The token is stored as a field and disposed in the class's Dispose method.", Scope = "type", Target = "~T:Works4me.Xurrent.GraphQL.PowerShell.Client.XurrentPowerShellClient")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The token is stored as a field and disposed in the NewXurrentClient class's Dispose method.", Scope = "type", Target = "~T:Works4me.Xurrent.GraphQL.PowerShell.Commands.NewXurrentToken")]

#if NET5_0_OR_GREATER

[assembly: SuppressMessage("Maintainability", "CA1510:Use ArgumentNullException throw helper", Justification = "Suppressed due to multi-target framework compatibility. The project builds for .NET 6, .NET 4.7.2, and .NET Standard 2.0, which do not support ArgumentNullException.ThrowIfNull. Ensures compatibility across all target frameworks.")]

#endif