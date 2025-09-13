using Microsoft.Extensions.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Provides configuration options for the <see cref="PowerShellLogger"/>.
    /// </summary>
    /// <remarks>
    /// These options determine the minimum log level and whether informational
    /// messages are written to the Information stream or the Verbose stream.
    /// <br /><br />
    /// Log level mapping to PowerShell streams (depending on <see cref="RouteInformationToInformationStream"/>):<br />
    /// • <see cref="LogLevel.Trace"/> / <see cref="LogLevel.Debug"/> →  <c>WriteVerbose</c> by default, or <c>WriteInformation</c> if enabled.<br />
    /// • <see cref="LogLevel.Information"/> → Same as Trace/Debug — <c>WriteVerbose</c> unless enabled, then <c>WriteInformation</c> with tags.<br />
    /// • <see cref="LogLevel.Warning"/> → <c>WriteWarning</c><br />
    /// • <see cref="LogLevel.Error"/> / <see cref="LogLevel.Critical"/> → <c>WriteError</c><br />
    /// • <see cref="LogLevel.None"/> → Disabled (no output).
    /// </remarks>
    internal sealed class PowerShellLoggerOptions
    {
        private LogLevel _minimumLevel = LogLevel.Information;
        private bool _routeInformationToInformationStream;

        /// <summary>
        /// Gets or sets the minimum <see cref="LogLevel"/> that will be logged.
        /// Messages below this level are ignored.
        /// </summary>
        public LogLevel MinimumLevel
        {
            get => _minimumLevel;
            set => _minimumLevel = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Information, Debug, and Trace messages are routed to the Information stream instead of the Verbose stream.
        /// </summary>
        /// <remarks>
        /// • <c>false</c> (default): messages go to <c>WriteVerbose</c> (hidden unless <c>-Verbose</c> is enabled).<br />
        /// • <c>true</c>: messages go to <c>WriteInformation</c> with category tags, visible in the Information stream.
        /// </remarks>
        public bool RouteInformationToInformationStream
        {
            get => _routeInformationToInformationStream;
            set => _routeInformationToInformationStream = value;
        }
    }
}
