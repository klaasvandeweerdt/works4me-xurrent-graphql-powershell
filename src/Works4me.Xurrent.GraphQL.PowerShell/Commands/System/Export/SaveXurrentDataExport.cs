using System;
using System.IO;
using System.Management.Automation;
using System.Threading;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Saves the result of a previously started Xurrent data export to a local file.<br/>
    /// This cmdlet polls the export service until the export is ready (or a timeout occurs), then downloads and writes the exported file to the specified path.<br/>
    /// Returns the path of the saved file.<br/>
    /// </summary>
    [Cmdlet(VerbsData.Save, "XurrentDataExport")]
    [OutputType(typeof(FileInfo))]
    public class SaveXurrentDataExport : XurrentCmdletBase
    {
        /// <summary>
        /// The export token string obtained from <see cref="StartXurrentDataExport"/>.<br/>
        /// Identifies the export job whose results should be downloaded.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// The full file system path where the exported file should be saved.<br/>
        /// Must be a valid path writable by the current user.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The interval, in seconds, between polling attempts while waiting for the export to complete.<br/>
        /// Must be between 10 and 120 seconds. Defaults to <c>30</c>.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(10, 120)]
        public int PollingInterval { get; set; } = 30;

        /// <summary>
        /// The maximum amount of time, in seconds, to wait for the export to complete.<br/>
        /// Use <c>0</c> to wait indefinitely. Defaults to <c>0</c>.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(0, 900)]
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for the export.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Polls the export service until the requested export is available or the timeout is reached.<br/>
        /// Downloads the export and saves it to <see cref="Path"/>.<br/>
        /// Writes the file path to the pipeline.<br/>
        /// Throws a terminating error if the request fails or the timeout is exceeded.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                using CancellationTokenSource cts = Timeout > 0 ? new CancellationTokenSource(TimeSpan.FromSeconds(Timeout)) : new CancellationTokenSource();
                client.Client.Bulk.AwaitDownloadAndSaveAsync(Path, Token, TimeSpan.FromSeconds(PollingInterval), cts.Token).GetAwaiter().GetResult();
                WriteObject(new FileInfo(Path), false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SaveXurrentDataExport), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SaveXurrentDataExport), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
