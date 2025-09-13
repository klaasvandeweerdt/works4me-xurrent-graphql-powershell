using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Management.Automation;
using System.Globalization;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// An <see cref="ILogger"/> implementation that writes log messages
    /// to PowerShell streams (Verbose, Information, Warning, Error, Debug).
    /// </summary>
    internal sealed class PowerShellLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly PowerShellLoggerOptions _baseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellLogger"/> class.
        /// </summary>
        /// <param name="categoryName">The category name for the logger (usually a cmdlet name or type).</param>
        /// <param name="baseOptions">The base logger options applied when no scope is active.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="categoryName"/> or <paramref name="baseOptions"/> is null.</exception>
        public PowerShellLogger(string categoryName, PowerShellLoggerOptions baseOptions)
        {
            _categoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
            _baseOptions = baseOptions ?? throw new ArgumentNullException(nameof(baseOptions));
        }

        /// <inheritdoc/>
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return NullScope.Instance;
        }

        /// <inheritdoc/>
        public bool IsEnabled(LogLevel logLevel)
        {
            PowerShellLoggerOptions effective = GetEffectiveOptions();
            return logLevel >= effective.MinimumLevel && logLevel != LogLevel.None;
        }

        /// <inheritdoc/>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            PowerShellAmbientLogScope.Scope? scope = PowerShellAmbientLogScope.Current;
            if (scope == null || scope.Writer == null)
            {
                return;
            }

            PowerShellLoggerOptions options = GetEffectiveOptions();
            if (!IsEnabled(logLevel))
            {
                return;
            }

            bool onPipelineThread = Environment.CurrentManagedThreadId == scope.PipelineThreadId;

            if (state is IReadOnlyList<KeyValuePair<string, object?>> kvps)
            {
                foreach (KeyValuePair<string, object?> kv in kvps)
                {
                    if (kv.Key == "@Trace" && kv.Value is XurrentTraceMessage msg)
                    {
                        EmitTrace(scope, options, msg, onPipelineThread, eventId);
                        return;
                    }
                }
            }

            string message = formatter is not null ? formatter(state, exception) : (state is not null ? state.ToString() ?? string.Empty : string.Empty);
            Route(scope, options, logLevel, message, exception, eventId, onPipelineThread);
        }

        /// <summary>
        /// Routes a log message to the appropriate PowerShell stream or enqueues it for later flushing.
        /// </summary>
        private void Route(PowerShellAmbientLogScope.Scope scope, PowerShellLoggerOptions options, LogLevel level, string message, Exception? exception, EventId eventId, bool onPipelineThread)
        {
            PowerShellAmbientLogScope.WriteKind kind;
            string[]? tags = null;

            switch (level)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                    kind = options.RouteInformationToInformationStream
                        ? PowerShellAmbientLogScope.WriteKind.Information
                        : PowerShellAmbientLogScope.WriteKind.Verbose;
                    if (kind == PowerShellAmbientLogScope.WriteKind.Information)
                        tags = new[] { _categoryName, "Information" };
                    break;

                case LogLevel.Warning:
                    kind = PowerShellAmbientLogScope.WriteKind.Warning;
                    break;

                default:
                    kind = PowerShellAmbientLogScope.WriteKind.Error;
                    break;
            }

            PowerShellAmbientLogScope.WriteOperation op = new(kind, message, tags, exception, eventId, _categoryName);
            scope.Queue.Enqueue(op);
        }

        /// <summary>
        /// Emits detailed trace information from the <c>Works4me.Xurrent.GraphQL</c> library as a series of log messages.
        /// </summary>
        private void EmitTrace(PowerShellAmbientLogScope.Scope scope, PowerShellLoggerOptions options, XurrentTraceMessage msg, bool onPipelineThread, EventId eventId)
        {
            List<string> lines = new();

            if (msg.ResponseCode is not null)
            {
                lines.Add($"ID: {msg.Id:B} | Response: {msg.ResponseCode}");
                lines.Add($"ID: {msg.Id:B} | Response Time: {msg.ResponseTimeInMilliseconds}ms");
                lines.Add($"ID: {msg.Id:B} | Retry After: {msg.RetryAfterInMilliseconds ?? 0}ms");
            }
            else
            {
                lines.Add($"ID: {msg.Id:B} | Method: {msg.Method}");
                lines.Add($"ID: {msg.Id:B} | URI: {msg.Uri}");
                lines.Add($"ID: {msg.Id:B} | Account: {msg.AccountId}");
                lines.Add($"ID: {msg.Id:B} | Content: {msg.Content}");
            }

            string cmdletName = !string.IsNullOrEmpty(scope.CmdletName) ? scope.CmdletName : _categoryName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture);

            foreach (string line in lines)
            {
                string formatted = "[" + timestamp + "] [" + cmdletName + "] " + line;
                Route(scope, options, LogLevel.Information, formatted, null, eventId, onPipelineThread);
            }
        }

        /// <summary>
        /// Gets the effective logger options from the current scope if present, otherwise falls back to the base options provided at construction.
        /// </summary>
        private PowerShellLoggerOptions GetEffectiveOptions()
        {
            PowerShellAmbientLogScope.Scope? scope = PowerShellAmbientLogScope.Current;
            if (scope is not null)
            {
                return scope.Options;
            }

            return _baseOptions;
        }

        /// <summary>
        /// A no-op scope implementation returned by <see cref="BeginScope{TState}(TState)"/>.
        /// </summary>
        private sealed class NullScope : IDisposable
        {
            private static readonly NullScope _instance = new();

            /// <summary>
            /// Gets the singleton instance of <see cref="NullScope"/>.
            /// </summary>
            public static NullScope Instance
            {
                get => _instance;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
            }
        }
    }
}
