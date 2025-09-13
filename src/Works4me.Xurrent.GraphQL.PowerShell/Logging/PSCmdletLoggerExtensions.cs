using Microsoft.Extensions.Logging;
using System.Management.Automation;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using Works4me.Xurrent.GraphQL.PowerShell.Commands;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Provides extension methods for <see cref="PSCmdlet"/> to emit structured log messages for lifecycle events and parameters.
    /// </summary>
    /// <remarks>
    /// These helpers use <see cref="LoggerMessageDefinitions"/> to write consistent
    /// start, parameter, and end messages for cmdlet execution. Intended for use
    /// inside cmdlet <c>BeginProcessing</c>, <c>ProcessRecord</c>, and <c>EndProcessing</c>.
    /// </remarks>
    internal static class PSCmdletLoggerExtensions
    {
        /// <summary>
        /// Writes a standardized header log entry indicating that the cmdlet has started execution.
        /// </summary>
        /// <param name="cmdlet">The <see cref="PSCmdlet"/> instance being executed.</param>
        /// <param name="logger">The logger to write the entry to.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cmdlet"/> or <paramref name="logger"/> is null.</exception>
        public static void StartProcessingHeader(this PSCmdlet cmdlet, ILogger logger)
        {
            if (cmdlet is null)
                throw new ArgumentNullException(nameof(cmdlet));
            
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            string timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture);
            string cmdletName = cmdlet.MyInvocation.MyCommand.Name;

            LoggerMessageDefinitions.CmdletStart(logger, timestamp, cmdletName);
        }

        /// <summary>
        /// Writes structured log entries for each bound parameter of the cmdlet.
        /// </summary>
        /// <param name="cmdlet">The <see cref="PSCmdlet"/> instance being executed.</param>
        /// <param name="logger">The logger to write parameter entries to.</param>
        /// <remarks>
        /// • Collection parameters are expanded into a comma-separated list.<br />
        /// • Enum values are logged by name if possible.<br />
        /// • Sensitive parameters (such as <see cref="NewXurrentClient.PersonalAccessToken"/> and <see cref="NewXurrentClient.ClientSecret"/>) are masked with <c>***</c>.<br />
        /// • Null values are logged explicitly as <c>null</c>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cmdlet"/> or <paramref name="logger"/> is null.</exception>
        public static void WriteParameters(this PSCmdlet cmdlet, ILogger logger)
        {
            if (cmdlet is null)
                throw new ArgumentNullException(nameof(cmdlet));

            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            string timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture);
            string cmdletName = cmdlet.MyInvocation.MyCommand.Name;

            foreach (KeyValuePair<string, object> boundParameter in cmdlet.MyInvocation.BoundParameters)
            {
                string name = boundParameter.Key;
                object? value = boundParameter.Value;

                if (cmdlet is NewXurrentClient && (name == nameof(NewXurrentClient.PersonalAccessToken) || name == nameof(NewXurrentClient.ClientSecret)))
                {
                    cmdlet.WriteVerbose($"[{timestamp}] [{cmdletName}] Parameter: {name} | Value: ***");
                    continue;
                }

                if (value is IEnumerable enumerable && value is not string)
                {
                    List<string> items = new();
                    foreach (object? element in enumerable)
                    {
                        if (element is null)
                        {
                            items.Add("null");
                            continue;
                        }

                        Type t = element.GetType();
                        if (t.IsEnum)
                        {
                            string? enumName = Enum.GetName(t, element);
                            items.Add(enumName ?? element.ToString() ?? "null");
                        }
                        else
                        {
                            items.Add(element.ToString() ?? "null");
                        }
                    }
                    LoggerMessageDefinitions.CmdletParameter(logger, timestamp, cmdletName, name, $"[{string.Join(", ", items)}]");
                }
                else
                {
                    LoggerMessageDefinitions.CmdletParameter(logger, timestamp, cmdletName, name, $"{(value is null ? "null" : (value.ToString() ?? "null"))}");
                }
            }
        }

        /// <summary>
        /// Writes a standardized footer log entry indicating that the cmdlet has finished execution.
        /// </summary>
        /// <param name="cmdlet">The <see cref="PSCmdlet"/> instance being executed.</param>
        /// <param name="logger">The logger to write the entry to.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cmdlet"/> or <paramref name="logger"/> is null.</exception>
        public static void EndProcessingFooter(this PSCmdlet cmdlet, ILogger logger)
        {
            if (cmdlet is null)
                throw new ArgumentNullException(nameof(cmdlet));

            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            string timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture);
            string cmdletName = cmdlet.MyInvocation.MyCommand.Name;

            LoggerMessageDefinitions.CmdletEnd(logger, timestamp, cmdletName);
        }
    }
}
