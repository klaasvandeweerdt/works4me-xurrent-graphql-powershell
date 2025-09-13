using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AutomationRuleQuery"/> object for building Xurrent <see cref="AutomationRule"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="AutomationRule"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAutomationRuleQuery")]
    [OutputType(typeof(AutomationRuleQuery))]
    public class NewXurrentAutomationRuleQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AutomationRule"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AutomationRule"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleField[] Properties { get; set; } = Array.Empty<AutomationRuleField>();

        /// <summary>
        /// Filters the query to return only the <see cref="AutomationRule"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="AutomationRule"/> view for the <see cref="AutomationRuleQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="AutomationRule"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="AutomationRule"/> results in the <see cref="AutomationRuleQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="AutomationRule"/> results.<br/>
        /// If omitted, the <see cref="AutomationRuleQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="AutomationRule"/> items returned per request in the <see cref="AutomationRuleQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleActionQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related <see cref="AutomationRuleAction"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleActionQuery? Actions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleExpressionQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related <see cref="AutomationRuleExpression"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleExpressionQuery? Expressions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? OwnerAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskTemplateQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="ProjectTaskTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateQuery? OwnerAsProjectTaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskTemplateRelationQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="ProjectTaskTemplateRelation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateRelationQuery? OwnerAsProjectTaskTemplateRelation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? OwnerAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="RequestTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? OwnerAsRequestTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="Workflow"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? OwnerAsWorkflow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? OwnerAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="WorkflowTaskTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateQuery? OwnerAsWorkflowTaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateRelationQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="WorkflowTaskTemplateRelation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateRelationQuery? OwnerAsWorkflowTaskTemplateRelation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplateQuery"/> in the <see cref="AutomationRuleQuery"/>, allowing related Owner data, cast to <see cref="WorkflowTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery? OwnerAsWorkflowTemplate { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{AutomationRuleFilterField}"/> conditions to the <see cref="AutomationRuleQuery"/>.<br/>
        /// Filters restrict which <see cref="AutomationRule"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<AutomationRuleFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="AutomationRuleQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="AutomationRule"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AutomationRuleQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AutomationRuleQuery query = new();

            if (WithId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WithId)))
                query.WithId(WithId);

            if (View is not null && MyInvocation.BoundParameters.ContainsKey(nameof(View)))
                query.View(View.Value);

            if (OrderBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OrderBy)))
            {
                if (SortOrder is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                    query.OrderBy(OrderBy.Value, SortOrder.Value);
                else
                    query.OrderBy(OrderBy.Value, GraphQL.SortOrder.Ascending);
            }

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Actions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Actions)))
                query.SelectActions(Actions);

            if (Expressions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Expressions)))
                query.SelectExpressions(Expressions);

            if (OwnerAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsProjectTask)))
                query.SelectOwner(OwnerAsProjectTask);

            if (OwnerAsProjectTaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsProjectTaskTemplate)))
                query.SelectOwner(OwnerAsProjectTaskTemplate);

            if (OwnerAsProjectTaskTemplateRelation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsProjectTaskTemplateRelation)))
                query.SelectOwner(OwnerAsProjectTaskTemplateRelation);

            if (OwnerAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsRequest)))
                query.SelectOwner(OwnerAsRequest);

            if (OwnerAsRequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsRequestTemplate)))
                query.SelectOwner(OwnerAsRequestTemplate);

            if (OwnerAsWorkflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflow)))
                query.SelectOwner(OwnerAsWorkflow);

            if (OwnerAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowTask)))
                query.SelectOwner(OwnerAsWorkflowTask);

            if (OwnerAsWorkflowTaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowTaskTemplate)))
                query.SelectOwner(OwnerAsWorkflowTaskTemplate);

            if (OwnerAsWorkflowTaskTemplateRelation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowTaskTemplateRelation)))
                query.SelectOwner(OwnerAsWorkflowTaskTemplateRelation);

            if (OwnerAsWorkflowTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowTemplate)))
                query.SelectOwner(OwnerAsWorkflowTemplate);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<AutomationRuleFilterField> filter in Filters)
                {
                    if (filter.BooleanValue is not null)
                        query.Where(filter.Property, filter.Operator, filter.BooleanValue.Value);
                    else if (filter.DateTimeValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.DateTimeValues);
                    else if (filter.IntegerValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.IntegerValues);
                    else if (filter.TextValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.TextValues);
                    else
                        query.Where(filter.Property, filter.Operator);
                }
            }

            if (Search is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Search)))
                query.Search(Search);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
