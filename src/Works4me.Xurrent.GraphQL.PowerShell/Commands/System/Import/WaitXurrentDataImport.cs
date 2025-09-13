using System;
using System.Management.Automation;
using System.Threading;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Waits for a bulk data import (started previously) to complete and returns the final status.<br/>
    /// Polls the Xurrent Bulk API at a configurable interval until completion (or until the timeout elapses).<br/>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "XurrentDataImport")]
    [OutputType(typeof(BulkImportResponse))]
    public class WaitXurrentDataImport : XurrentCmdletBase
    {
        /// <summary>
        /// The import token returned by <c>Start-XurrentDataImport</c> that identifies the import job to monitor.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// The interval, in seconds, between polling attempts while waiting for the import to complete.<br/>
        /// Must be between 10 and 120 seconds. Defaults to <c>30</c>.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(10, 120)]
        public int PollingInterval { get; set; } = 30;

        /// <summary>
        /// The maximum amount of time, in seconds, to wait for the import to complete.<br/>
        /// Use <c>0</c> to wait indefinitely. Defaults to <c>0</c>.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(0, 900)]
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for the import.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Polls the import status until it completes or the timeout is reached, then writes the final <see cref="BulkImportResponse"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                using CancellationTokenSource cts = Timeout > 0 ? new CancellationTokenSource(TimeSpan.FromSeconds(Timeout)) : new CancellationTokenSource();
                BulkImportResponse result = client.Client.Bulk.AwaitImportAsync(Token, TimeSpan.FromSeconds(PollingInterval), cts.Token).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(WaitXurrentDataImport), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(WaitXurrentDataImport), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
