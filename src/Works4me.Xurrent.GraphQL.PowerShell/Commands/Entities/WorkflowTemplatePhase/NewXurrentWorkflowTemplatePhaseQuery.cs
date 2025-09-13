using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WorkflowTemplatePhaseQuery"/> object for building Xurrent <see cref="WorkflowTemplatePhase"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="WorkflowTemplatePhase"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWorkflowTemplatePhaseQuery")]
    [OutputType(typeof(WorkflowTemplatePhaseQuery))]
    public class NewXurrentWorkflowTemplatePhaseQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="WorkflowTemplatePhase"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="WorkflowTemplatePhase"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseField[] Properties { get; set; } = Array.Empty<WorkflowTemplatePhaseField>();

        /// <summary>
        /// Sets the maximum number of <see cref="WorkflowTemplatePhase"/> items returned per request in the <see cref="WorkflowTemplatePhaseQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="WorkflowTemplatePhaseQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="WorkflowTemplatePhaseQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTemplatePhaseQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
