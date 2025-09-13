using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Starts a bulk data import job in Xurrent.<br/>
    /// The cmdlet uploads the specified file and requests that the data be imported into the given type.<br/>
    /// Returns an import token string that can be used to monitor the import progress.<br/>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "XurrentDataImport")]
    [OutputType(typeof(string))]
    public class StartXurrentDataImport : XurrentCmdletBase
    {
        /// <summary>
        /// The full file system path of the file to import.<br/>
        /// Must be a valid path readable by the current user.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The type of data being imported (e.g., the entity name or object type recognized by the Xurrent Bulk API).<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for the import.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the import request by uploading the file at <see cref="Path"/> and registering it as an import of type <see cref="Type"/>.<br/>
        /// Writes the import token string to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                string token = client.Client.Bulk.StartImportAsync(Path, Type).GetAwaiter().GetResult();
                WriteObject(token, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(StartXurrentDataImport), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(StartXurrentDataImport), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
