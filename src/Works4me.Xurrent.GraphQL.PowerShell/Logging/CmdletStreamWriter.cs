using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Provides a wrapper around <see cref="PSCmdlet"/> output methods, allowing logging and diagnostic messages to be written to the appropriate PowerShell streams.
    /// </summary>
    internal sealed class CmdletStreamWriter : ICmdletStreamWriter
    {
        private readonly PSCmdlet _cmdlet;

        /// <inheritdoc/>
        public CmdletStreamWriter(PSCmdlet cmdlet)
        {
            _cmdlet = cmdlet;
        }

        /// <inheritdoc/>
        public void WriteVerbose(string message)
        {
            try { _cmdlet.WriteVerbose(message); }
            catch (PipelineStoppedException) { }
            catch (PSInvalidOperationException) { }
            catch (ObjectDisposedException) { }
        }

        /// <inheritdoc/>
        public void WriteInformation(string message, string[] tags)
        {
            _cmdlet.WriteInformation(message, tags);
        }

        /// <inheritdoc/>
        public void WriteWarning(string message)
        {
            _cmdlet.WriteWarning(message);
        }

        /// <inheritdoc/>
        public void WriteError(ErrorRecord record)
        {
            _cmdlet.WriteError(record);
        }

        /// <inheritdoc/>
        public void WriteDebug(string message)
        {
            _cmdlet.WriteDebug(message);
        }
    }
}
