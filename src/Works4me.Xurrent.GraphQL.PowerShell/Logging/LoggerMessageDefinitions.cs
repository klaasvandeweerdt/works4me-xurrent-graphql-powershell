using Microsoft.Extensions.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Defines strongly-typed logging message templates for cmdlet lifecycle events.
    /// These methods use <see cref="LoggerMessageAttribute"/> to enable source-generated logging for improved performance.
    /// </summary>
    internal static partial class LoggerMessageDefinitions
    {
        /// <summary>
        /// Logs the start of a cmdlet execution.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> used to write the log entry.</param>
        /// <param name="Timestamp">The timestamp when the cmdlet started.</param>
        /// <param name="Cmdlet">The name of the cmdlet being executed.</param>
        [LoggerMessage(Level = LogLevel.Information, Message = "[{Timestamp}] [{Cmdlet}] Start")]
        internal static partial void CmdletStart(ILogger logger, string Timestamp, string Cmdlet);

        /// <summary>
        /// Logs a parameter value bound to the cmdlet.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> used to write the log entry.</param>
        /// <param name="Timestamp">The timestamp when the parameter was processed.</param>
        /// <param name="Cmdlet">The name of the cmdlet being executed.</param>
        /// <param name="Name">The name of the parameter.</param>
        /// <param name="Value">The stringified value of the parameter.</param>
        [LoggerMessage(Level = LogLevel.Information, Message = "[{Timestamp}] [{Cmdlet}] Parameter: {Name} | Value: {Value}")]
        internal static partial void CmdletParameter(ILogger logger, string Timestamp, string Cmdlet, string Name, string Value);

        /// <summary>
        /// Logs the end of a cmdlet execution.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> used to write the log entry.</param>
        /// <param name="Timestamp">The timestamp when the cmdlet ended.</param>
        /// <param name="Cmdlet">The name of the cmdlet being executed.</param>
        [LoggerMessage(Level = LogLevel.Information, Message = "[{Timestamp}] [{Cmdlet}] End")]
        internal static partial void CmdletEnd(ILogger logger, string Timestamp, string Cmdlet);
    }
}
