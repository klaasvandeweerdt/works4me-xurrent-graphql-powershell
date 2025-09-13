using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProjectTaskTemplateRelationQuery"/> object for building Xurrent <see cref="ProjectTaskTemplateRelation"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ProjectTaskTemplateRelation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectTaskTemplateRelationQuery")]
    [OutputType(typeof(ProjectTaskTemplateRelationQuery))]
    public class NewXurrentProjectTaskTemplateRelationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProjectTaskTemplateRelation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProjectTaskTemplateRelation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateRelationField[] Properties { get; set; } = Array.Empty<ProjectTaskTemplateRelationField>();

        /// <summary>
        /// Sets the maximum number of <see cref="ProjectTaskTemplateRelation"/> items returned per request in the <see cref="ProjectTaskTemplateRelationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="ProjectTaskTemplateRelationQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRules { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTemplatePhaseQuery"/> in the <see cref="ProjectTaskTemplateRelationQuery"/>, allowing related <see cref="ProjectTemplatePhase"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTemplatePhaseQuery? Phase { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskTemplateQuery"/> in the <see cref="ProjectTaskTemplateRelationQuery"/>, allowing related <see cref="ProjectTaskTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateQuery? TaskTemplate { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProjectTaskTemplateRelationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectTaskTemplateRelationQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (AutomationRules is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRules)))
                query.SelectAutomationRules(AutomationRules);

            if (Phase is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Phase)))
                query.SelectPhase(Phase);

            if (TaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TaskTemplate)))
                query.SelectTaskTemplate(TaskTemplate);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
