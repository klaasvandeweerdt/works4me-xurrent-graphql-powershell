using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.Logging;
using System.Management.Automation;
using System.Globalization;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Manages the ambient logging scope for a PowerShell pipeline execution.
    /// Provides a way to capture the current <see cref="PSCmdlet"/> context
    /// and route log messages to the appropriate PowerShell streams.
    /// </summary>
    internal static class PowerShellAmbientLogScope
    {
        private static readonly AsyncLocal<Scope?> _current = new();

        /// <summary>
        /// Gets the current logging <see cref="Scope"/> for the pipeline thread, if any.
        /// </summary>
        internal static Scope? Current
        {
            get => _current.Value;
        }

        /// <summary>
        /// Begins a new logging scope bound to the specified <see cref="PSCmdlet"/> and options.
        /// </summary>
        /// <param name="cmdlet">The PowerShell cmdlet associated with the scope.</param>
        /// <param name="options">The logger options to apply for the scope.</param>
        /// <returns>An <see cref="IDisposable"/> that, when disposed, restores the previous scope. Typically used in a <c>using</c> statement.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="cmdlet"/> or <paramref name="options"/> is null.</exception>
        public static IDisposable Begin(PSCmdlet cmdlet, PowerShellLoggerOptions options)
        {
            if (cmdlet is null)
                throw new ArgumentNullException(nameof(cmdlet));

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            string cmdletName = cmdlet.MyInvocation is not null && cmdlet.MyInvocation.MyCommand is not null
                ? cmdlet.MyInvocation.MyCommand.Name
                : cmdlet.GetType().Name;

            Scope previous = _current.Value ?? new Scope(null, new PowerShellLoggerOptions(), null, 0, string.Empty, null);
            Scope next = new(new CmdletStreamWriter(cmdlet), options, previous, Environment.CurrentManagedThreadId, cmdletName, SynchronizationContext.Current);

            _current.Value = next;
            return new Popper(previous);
        }

        /// <summary>
        /// Flushes any queued log write operations for the current scope.
        /// Routes messages to the appropriate PowerShell streams.
        /// </summary>
        internal static void FlushCurrent()
        {
            Scope? scope = _current.Value;

            if (scope is null || scope.Writer is null)
                return;

            bool onPipelineThread = Environment.CurrentManagedThreadId == scope.PipelineThreadId;

            void WriteOne(in WriteOperation op)
            {
                switch (op.Kind)
                {
                    case WriteKind.Debug:
                        scope.Writer!.WriteDebug(op.Message);
                        break;

                    case WriteKind.Verbose:
                        scope.Writer!.WriteVerbose(op.Message);
                        break;

                    case WriteKind.Information:
                        scope.Writer!.WriteInformation(
                            op.Message,
                            op.Tags ?? new string[] { op.CategoryName, "Information" });
                        break;

                    case WriteKind.Warning:
                        scope.Writer!.WriteWarning(op.Message);
                        break;

                    case WriteKind.Error:
                        ErrorRecord rec = op.Exception is not null
                            ? new ErrorRecord(
                                op.Exception,
                                op.EventId.Id.ToString(CultureInfo.InvariantCulture),
                                ErrorCategory.NotSpecified,
                                null)
                            : new ErrorRecord(
                                new XurrentException(op.Message),
                                op.EventId.Id.ToString(CultureInfo.InvariantCulture),
                                ErrorCategory.NotSpecified,
                                null);
                        scope.Writer!.WriteError(rec);
                        break;
                }
            }

            if (!onPipelineThread && scope.SyncContext is null)
                return;

            while (scope.Queue.TryDequeue(out WriteOperation op))
            {
                if (onPipelineThread)
                {
                    WriteOne(in op);
                }
                else
                {
                    ManualResetEventSlim done = new(initialState: false);
                    scope.SyncContext!.Post(_ =>
                    {
                        try
                        {
                            WriteOne(in op); 
                        }
                        finally 
                        {
                            done.Set(); 
                        }
                    }, state: null);
                    done.Wait();
                    done.Dispose();
                }
            }
        }

        /// <summary>
        /// Represents a logging scope bound to a cmdlet and thread in the pipeline.
        /// Carries configuration and queued log write operations.
        /// </summary>
        internal sealed class Scope
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Scope"/> class, which represents a logging scope for a PowerShell cmdlet execution context.<br/>
            /// </summary>
            /// <param name="writer">The writer responsible for emitting messages to PowerShell streams (verbose, error, warning, etc.).</param>
            /// <param name="options">The logging options that control behavior within this scope.</param>
            /// <param name="parent">The parent <see cref="Scope"/>, if nested; otherwise <c>null</c>.</param>
            /// <param name="pipelineThreadId">The managed thread ID associated with the PowerShell pipeline execution.</param>
            /// <param name="cmdletName">The name of the cmdlet associated with this scope.</param>
            /// <param name="syncContext">The synchronization context used to marshal log writes to the appropriate thread or context.</param>
            public Scope(ICmdletStreamWriter? writer, PowerShellLoggerOptions options, Scope? parent, int pipelineThreadId, string cmdletName, SynchronizationContext? syncContext)
            {
                Writer = writer;
                Options = options;
                Parent = parent;
                PipelineThreadId = pipelineThreadId;
                Queue = new ConcurrentQueue<WriteOperation>();
                CmdletName = cmdletName;
                SyncContext = syncContext;
            }

            /// <summary>
            /// Gets the writer used to emit messages to PowerShell streams.
            /// </summary>
            public ICmdletStreamWriter? Writer { get; }

            /// <summary>
            /// Gets the logging options in effect for this scope.
            /// </summary>
            public PowerShellLoggerOptions Options { get; }

            /// <summary>
            /// Gets the parent scope, if any.
            /// </summary>
            public Scope? Parent { get; }

            /// <summary>
            /// Gets the thread ID of the PowerShell pipeline for this scope.
            /// </summary>
            public int PipelineThreadId { get; }

            /// <summary>
            /// Gets the queue of pending write operations.
            /// </summary>
            public ConcurrentQueue<WriteOperation> Queue { get; }

            /// <summary>
            /// Gets the name of the cmdlet associated with this scope.
            /// </summary>
            public string CmdletName { get; }

            public SynchronizationContext? SyncContext { get; }
        }

        /// <summary>
        /// Identifies the kind of PowerShell stream a log message should be written to.
        /// </summary>
        internal enum WriteKind
        {
            /// <summary>
            /// Message should be written to the debug stream.
            /// </summary>
            Debug,

            /// <summary>
            /// Message should be written to the verbose stream.
            /// </summary>
            Verbose,

            /// <summary>
            /// Message should be written to the information stream.
            /// </summary>
            Information,

            /// <summary>
            /// Message should be written to the warning stream.
            /// </summary>
            Warning,

            /// <summary>
            /// Message should be written to the error stream.
            /// </summary>
            Error
        }

        /// <summary>
        /// Represents a queued log write operation, including message,
        /// severity, and optional exception or tags.
        /// </summary>
        internal readonly struct WriteOperation
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="WriteOperation"/> struct.
            /// </summary>
            /// <param name="kind">The target stream for the message.</param>
            /// <param name="message">The log message.</param>
            /// <param name="tags">Optional tags for categorizing the message.</param>
            /// <param name="exception">An exception to log, if any.</param>
            /// <param name="eventId">The associated event identifier.</param>
            /// <param name="categoryName">The logging category name.</param>
            public WriteOperation(WriteKind kind, string message, string[]? tags, Exception? exception, EventId eventId, string categoryName)
            {
                Kind = kind;
                Message = message;
                Tags = tags;
                Exception = exception;
                EventId = eventId;
                CategoryName = categoryName;
            }

            /// <summary>
            /// Gets the target stream for the message.
            /// </summary>
            public WriteKind Kind { get; }

            /// <summary>
            /// Gets the log message.
            /// </summary>
            public string Message { get; }

            /// <summary>
            /// Gets optional tags for categorizing the message.
            /// </summary>
            public string[]? Tags { get; }

            /// <summary>
            /// Gets the exception to log, if any.
            /// </summary>
            public Exception? Exception { get; }

            /// <summary>
            /// Gets the associated event identifier.
            /// </summary>
            public EventId EventId { get; }

            /// <summary>
            /// Gets the logging category name.
            /// </summary>
            public string CategoryName { get; }
        }

        /// <summary>
        /// Restores the previous scope when disposed.
        /// </summary>
        private sealed class Popper : IDisposable
        {
            private readonly Scope _previous;
            private bool _disposed;

            /// <summary>
            /// Initializes a new instance of the <see cref="Popper"/> class.
            /// </summary>
            /// <param name="previous">The previous scope to restore when disposed.</param>
            public Popper(Scope previous)
            {
                _previous = previous;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                if (!_disposed)
                {
                    _current.Value = _previous;
                    _disposed = true;
                }
            }
        }
    }
}
