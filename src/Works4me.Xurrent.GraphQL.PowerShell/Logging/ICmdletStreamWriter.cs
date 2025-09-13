using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Logging
{
    /// <summary>
    /// Defines an abstraction for writing messages to PowerShell streams. Implementations typically wrap <see cref="PSCmdlet"/> methods to provide a consistent interface for logging and diagnostics.
    /// </summary>
    internal interface ICmdletStreamWriter
    {
        /// <summary>
        /// Writes a verbose message to the PowerShell verbose stream.
        /// </summary>
        /// <param name="message">The verbose message to write.</param>
        void WriteVerbose(string message);

        /// <summary>
        /// Writes an informational message to the PowerShell information stream.
        /// </summary>
        /// <param name="message">The information message to write.</param>
        /// <param name="tags">Tags used to categorize the message. These can be leveraged by consumers of the information stream to filter or route messages.</param>
        void WriteInformation(string message, string[] tags);

        /// <summary>
        /// Writes a warning message to the PowerShell warning stream.
        /// </summary>
        /// <param name="message">The warning message to write.</param>
        void WriteWarning(string message);

        /// <summary>
        /// Writes an error record to the PowerShell error stream.
        /// </summary>
        /// <param name="record">The <see cref="ErrorRecord"/> that represents the error.</param>
        void WriteError(ErrorRecord record);

        /// <summary>
        /// Writes a debug message to the PowerShell debug stream.
        /// </summary>
        /// <param name="message">The debug message to write.</param>
        void WriteDebug(string message);
    }
}
