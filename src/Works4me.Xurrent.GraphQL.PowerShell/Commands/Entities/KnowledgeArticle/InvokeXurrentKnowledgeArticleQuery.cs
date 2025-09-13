using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Invokes the <see cref="KnowledgeArticleQuery"/> against the Xurrent GraphQL API and writes the resulting <see cref="KnowledgeArticle"/> items to the pipeline.<br/>
    /// Use this cmdlet to execute a composed query and retrieve data.<br/>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "XurrentKnowledgeArticleQuery")]
    [OutputType(typeof(KnowledgeArticle))]
    public class InvokeXurrentKnowledgeArticleQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="KnowledgeArticleQuery"/> to execute.<br/>
        /// This parameter is required and determines which <see cref="KnowledgeArticle"/> data is retrieved.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery? Query { get; set; }

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
                KnowledgeArticleQuery query = Query ?? throw new ArgumentNullException(nameof(Query));
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ReadOnlyDataCollection<KnowledgeArticle> result = client.Client.GetAsync(query).GetAwaiter().GetResult();
                WriteObject(result, true);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(InvokeXurrentKnowledgeArticleQuery), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(InvokeXurrentKnowledgeArticleQuery), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
