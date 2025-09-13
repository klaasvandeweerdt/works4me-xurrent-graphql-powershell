using System;
using Microsoft.Extensions.Logging;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Provides a factory for creating <see cref="ILoggerFactory"/> instances
    /// configured for a single PowerShell cmdlet execution.
    /// </summary>
    internal static class PSCmdletLoggerFactory
    {
        /// <summary>
        /// Creates an <see cref="ILoggerFactory"/> configured for a single cmdlet run.
        /// </summary>
        /// <param name="cmdlet">The <see cref="PSCmdlet"/> instance to inspect for preferences.</param>
        /// <param name="baseOptions">Optional base logger options. If <c>null</c>, defaults are used.</param>
        /// <returns>
        /// An <see cref="ILoggerFactory"/> configured with a <see cref="PowerShellLoggerProvider"/>
        /// that respects PowerShell verbosity/debug preferences.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cmdlet"/> is <c>null</c>.</exception>
        public static ILoggerFactory CreateForSingleLevel(PSCmdlet cmdlet, PowerShellLoggerOptions? baseOptions = null)
        {
            if (cmdlet is null)
                throw new ArgumentNullException(nameof(cmdlet));

            PowerShellLoggerOptions effective = baseOptions ?? new PowerShellLoggerOptions();

            bool verbose = IsSwitchPresent(cmdlet, "Verbose") || IsPreferenceEnabled(cmdlet, "VerbosePreference");
            bool debug = IsSwitchPresent(cmdlet, "Debug") || IsPreferenceEnabled(cmdlet, "DebugPreference");
            bool showInformation = verbose || debug;

            effective.MinimumLevel = showInformation ? LogLevel.Information : LogLevel.Warning;

            PowerShellLoggerProvider? provider = null;
            try
            {
                provider = new PowerShellLoggerProvider(effective);

                ILoggerFactory factory = LoggerFactory.Create(builder =>
                {
                    builder.ClearProviders();
                    builder.AddProvider(provider);
                    builder.SetMinimumLevel(LogLevel.Trace);
                });

                provider = null;
                return factory;
            }
            finally
            {
                provider?.Dispose();
            }
        }

        /// <summary>
        /// Determines whether a given switch parameter is present in the cmdlet’s bound parameters.
        /// </summary>
        private static bool IsSwitchPresent(PSCmdlet cmdlet, string name)
        {
            if (cmdlet.MyInvocation is null || cmdlet.MyInvocation.BoundParameters is null)
                return false;

            if (!cmdlet.MyInvocation.BoundParameters.TryGetValue(name, out object? value))
                return false;

            if (value is SwitchParameter sp)
                return sp.IsPresent;

            if (value is bool b)
                return b;

            return false;
        }

        /// <summary>
        /// Determines whether a given preference variable is enabled on the cmdlet. A preference is considered enabled if set to <see cref="ActionPreference.Continue"/> or <see cref="ActionPreference.Inquire"/>.
        /// </summary>
        private static bool IsPreferenceEnabled(PSCmdlet cmdlet, string preferenceVariableName)
        {
            object? val = cmdlet.GetVariableValue(preferenceVariableName);

            if (val is ActionPreference ap)
                return ap == ActionPreference.Continue || ap == ActionPreference.Inquire;

            return false;
        }
    }
}
