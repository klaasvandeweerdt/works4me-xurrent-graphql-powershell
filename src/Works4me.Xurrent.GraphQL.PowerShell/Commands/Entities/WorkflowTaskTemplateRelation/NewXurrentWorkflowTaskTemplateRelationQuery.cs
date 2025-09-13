using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WorkflowTaskTemplateRelationQuery"/> object for building Xurrent <see cref="WorkflowTaskTemplateRelation"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="WorkflowTaskTemplateRelation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWorkflowTaskTemplateRelationQuery")]
    [OutputType(typeof(WorkflowTaskTemplateRelationQuery))]
    public class NewXurrentWorkflowTaskTemplateRelationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="WorkflowTaskTemplateRelation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="WorkflowTaskTemplateRelation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateRelationField[] Properties { get; set; } = Array.Empty<WorkflowTaskTemplateRelationField>();

        /// <summary>
        /// Sets the maximum number of <see cref="WorkflowTaskTemplateRelation"/> items returned per request in the <see cref="WorkflowTaskTemplateRelationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="WorkflowTaskTemplateRelationQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRules { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateQuery"/> in the <see cref="WorkflowTaskTemplateRelationQuery"/>, allowing related <see cref="WorkflowTaskTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateQuery? FailureTaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplatePhaseQuery"/> in the <see cref="WorkflowTaskTemplateRelationQuery"/>, allowing related <see cref="WorkflowTemplatePhase"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseQuery? Phase { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateQuery"/> in the <see cref="WorkflowTaskTemplateRelationQuery"/>, allowing related <see cref="WorkflowTaskTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateQuery? TaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplateQuery"/> in the <see cref="WorkflowTaskTemplateRelationQuery"/>, allowing related <see cref="WorkflowTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery? WorkflowTemplate { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="WorkflowTaskTemplateRelationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTaskTemplateRelationQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (AutomationRules is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRules)))
                query.SelectAutomationRules(AutomationRules);

            if (FailureTaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FailureTaskTemplate)))
                query.SelectFailureTaskTemplate(FailureTaskTemplate);

            if (Phase is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Phase)))
                query.SelectPhase(Phase);

            if (TaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TaskTemplate)))
                query.SelectTaskTemplate(TaskTemplate);

            if (WorkflowTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplate)))
                query.SelectWorkflowTemplate(WorkflowTemplate);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
