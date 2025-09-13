using System;
using System.Management.Automation;
using Microsoft.Extensions.Logging;
using Works4me.Xurrent.GraphQL.PowerShell.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Provides a base class for all Xurrent PowerShell cmdlets.<br/>
    /// Handles logging setup, parameter logging, ambient log scope management, and offers extension points for derived cmdlets via <see cref="OnProcessRecord"/>.<br/>
    /// </summary>
    public abstract class XurrentCmdletBase : PSCmdlet
    {
        private ILogger? _logger;
        private IDisposable? _ambientScope;
        private PowerShellLoggerOptions? _loggerOptions;
        private bool _logParameters = true;

        /// <summary>
        /// Gets or sets a value indicating whether parameters should be logged<br/>
        /// when the cmdlet begins execution. Defaults to <c>true</c>.<br/>
        /// </summary>
        protected bool LogParameters
        {
            get => _logParameters;
            set => _logParameters = value;
        }

        /// <summary>
        /// Gets an <see cref="ILogger"/> instance configured for the current cmdlet.<br/>
        /// Lazily created based on the cmdlet’s name or type.<br/>
        /// </summary>
        protected ILogger Logger
        {
            get
            {
                if (_logger is null)
                {
                    string category = MyInvocation is not null && MyInvocation.MyCommand is not null ? MyInvocation.MyCommand.Name : GetType().FullName ?? "Cmdlet";
                    _logger = ModuleLoggerFactory.CreateLogger(category);
                }
                return _logger;
            }
        }

        /// <inheritdoc />
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _loggerOptions = new PowerShellLoggerOptions();
            _ambientScope = PowerShellAmbientLogScope.Begin(this, _loggerOptions);

            this.StartProcessingHeader(Logger);
            if (LogParameters)
            {
                this.WriteParameters(Logger);
            }
        }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            OnProcessRecord();
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            this.EndProcessingFooter(Logger);
            PowerShellAmbientLogScope.FlushCurrent();

            if (_ambientScope is not null)
            {
                _ambientScope.Dispose();
                _ambientScope = null;
            }

            base.EndProcessing();
        }

        /// <inheritdoc />
        protected override void StopProcessing()
        {
            PowerShellAmbientLogScope.FlushCurrent();
            base.StopProcessing();
        }

        /// <summary>
        /// Provides a hook for derived cmdlets to implement their main execution logic.<br/>
        /// Called from <see cref="ProcessRecord"/>.<br/>
        /// </summary>
        protected virtual void OnProcessRecord()
        {
        }
    }
}
