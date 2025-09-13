using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Invokes the <see cref="SiteQuery"/> against the Xurrent GraphQL API and writes the resulting <see cref="Site"/> items to the pipeline.<br/>
    /// Use this cmdlet to execute a composed query and retrieve data.<br/>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "XurrentSiteQuery")]
    [OutputType(typeof(Site))]
    public class InvokeXurrentSiteQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SiteQuery"/> to execute.<br/>
        /// This parameter is required and determines which <see cref="Site"/> data is retrieved.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? Query { get; set; }

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the query using the provided or default client and writes the results to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                SiteQuery query = Query ?? throw new ArgumentNullException(nameof(Query));
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ReadOnlyDataCollection<Site> result = client.Client.GetAsync(query).GetAwaiter().GetResult();
                WriteObject(result, true);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(InvokeXurrentSiteQuery), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(InvokeXurrentSiteQuery), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
