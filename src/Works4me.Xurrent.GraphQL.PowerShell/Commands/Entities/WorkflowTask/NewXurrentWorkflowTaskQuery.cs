using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WorkflowTaskQuery"/> object for building Xurrent <see cref="WorkflowTask"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="WorkflowTask"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWorkflowTaskQuery")]
    [OutputType(typeof(WorkflowTaskQuery))]
    public class NewXurrentWorkflowTaskQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="WorkflowTask"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="WorkflowTask"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskField[] Properties { get; set; } = Array.Empty<WorkflowTaskField>();

        /// <summary>
        /// Filters the query to return only the <see cref="WorkflowTask"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="WorkflowTask"/> view for the <see cref="WorkflowTaskQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="WorkflowTask"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="WorkflowTask"/> results in the <see cref="WorkflowTaskQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="WorkflowTask"/> results.<br/>
        /// If omitted, the <see cref="WorkflowTaskQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="WorkflowTask"/> items returned per request in the <see cref="WorkflowTaskQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="AgileBoard"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery? AgileBoard { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardColumnQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="AgileBoardColumn"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery? AgileBoardColumn { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TaskApprovalQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="TaskApproval"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskApprovalQuery? Approvals { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRules { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="WorkflowTask"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? FailureTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InstructionsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Member { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Notes { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="ShopOrderLine"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? OrderLine { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PdfDesignQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="PdfDesign"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PdfDesignQuery? PdfDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowPhaseQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="WorkflowPhase"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowPhaseQuery? Phase { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Request { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? RequestServiceInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="RequestTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? RequestTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstances { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SprintBacklogItemQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="SprintBacklogItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintBacklogItemQuery? SprintBacklogItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Supplier { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="WorkflowTaskTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateQuery? Template { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeEntryQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="TimeEntry"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery? TimeEntries { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="WorkflowTaskQuery"/>, allowing related <see cref="Workflow"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? Workflow { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{WorkflowTaskFilterField}"/> conditions to the <see cref="WorkflowTaskQuery"/>.<br/>
        /// Filters restrict which <see cref="WorkflowTask"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<WorkflowTaskFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="WorkflowTaskQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="WorkflowTask"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="WorkflowTask"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/workflowtaskcustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="WorkflowTaskQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTaskQuery query = new();

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

            if (AgileBoard is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoard)))
                query.SelectAgileBoard(AgileBoard);

            if (AgileBoardColumn is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumn)))
                query.SelectAgileBoardColumn(AgileBoardColumn);

            if (Approvals is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Approvals)))
                query.SelectApprovals(Approvals);

            if (AutomationRules is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRules)))
                query.SelectAutomationRules(AutomationRules);

            if (ConfigurationItems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItems)))
                query.SelectConfigurationItems(ConfigurationItems);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (FailureTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FailureTask)))
                query.SelectFailureTask(FailureTask);

            if (InstructionsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InstructionsAttachments)))
                query.SelectInstructionsAttachments(InstructionsAttachments);

            if (Member is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Member)))
                query.SelectMember(Member);

            if (Notes is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                query.SelectNotes(Notes);

            if (OrderLine is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OrderLine)))
                query.SelectOrderLine(OrderLine);

            if (PdfDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(PdfDesign)))
                query.SelectPdfDesign(PdfDesign);

            if (Phase is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Phase)))
                query.SelectPhase(Phase);

            if (Request is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Request)))
                query.SelectRequest(Request);

            if (RequestServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestServiceInstance)))
                query.SelectRequestServiceInstance(RequestServiceInstance);

            if (RequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplate)))
                query.SelectRequestTemplate(RequestTemplate);

            if (ServiceInstances is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstances)))
                query.SelectServiceInstances(ServiceInstances);

            if (SprintBacklogItems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SprintBacklogItems)))
                query.SelectSprintBacklogItems(SprintBacklogItems);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                query.SelectSupplier(Supplier);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            if (Template is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Template)))
                query.SelectTemplate(Template);

            if (TimeEntries is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TimeEntries)))
                query.SelectTimeEntries(TimeEntries);

            if (Workflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Workflow)))
                query.SelectWorkflow(Workflow);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<WorkflowTaskFilterField> filter in Filters)
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

            if (CustomFilters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFilters)))
            {
                foreach (CustomFilter filter in CustomFilters)
                {
                    if (filter.TextValues is not null)
                        query.CustomFilter(filter.Name, filter.Operator, filter.TextValues);
                    else
                        query.CustomFilter(filter.Name, filter.Operator);
                }
            }

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
