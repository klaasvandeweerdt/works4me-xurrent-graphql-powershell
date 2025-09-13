using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProblemQuery"/> object for building Xurrent <see cref="Problem"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Problem"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProblemQuery")]
    [OutputType(typeof(ProblemQuery))]
    public class NewXurrentProblemQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Problem"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Problem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemField[] Properties { get; set; } = Array.Empty<ProblemField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Problem"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Problem"/> view for the <see cref="ProblemQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Problem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Problem"/> results in the <see cref="ProblemQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Problem"/> results.<br/>
        /// If omitted, the <see cref="ProblemQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Problem"/> items returned per request in the <see cref="ProblemQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="AgileBoard"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery? AgileBoard { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardColumnQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="AgileBoardColumn"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery? AgileBoardColumn { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="KnowledgeArticleQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="KnowledgeArticle"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery? KnowledgeArticle { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Manager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Member { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Notes { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductBacklogQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="ProductBacklog"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductBacklogQuery? ProductBacklog { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Project"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery? Project { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Requests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstances { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SprintBacklogItemQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="SprintBacklogItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintBacklogItemQuery? SprintBacklogItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Supplier { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeEntryQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="TimeEntry"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery? TimeEntries { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? WorkaroundAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="ProblemQuery"/>, allowing related <see cref="Workflow"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? Workflow { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ProblemFilterField}"/> conditions to the <see cref="ProblemQuery"/>.<br/>
        /// Filters restrict which <see cref="Problem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ProblemFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ProblemQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Problem"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="Problem"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/problemcustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProblemQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProblemQuery query = new();

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

            if (ConfigurationItems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItems)))
                query.SelectConfigurationItems(ConfigurationItems);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (KnowledgeArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(KnowledgeArticle)))
                query.SelectKnowledgeArticle(KnowledgeArticle);

            if (Manager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                query.SelectManager(Manager);

            if (Member is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Member)))
                query.SelectMember(Member);

            if (Notes is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                query.SelectNotes(Notes);

            if (ProductBacklog is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklog)))
                query.SelectProductBacklog(ProductBacklog);

            if (Project is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Project)))
                query.SelectProject(Project);

            if (Requests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Requests)))
                query.SelectRequests(Requests);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (ServiceInstances is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstances)))
                query.SelectServiceInstances(ServiceInstances);

            if (SprintBacklogItems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SprintBacklogItems)))
                query.SelectSprintBacklogItems(SprintBacklogItems);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                query.SelectSupplier(Supplier);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            if (TimeEntries is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TimeEntries)))
                query.SelectTimeEntries(TimeEntries);

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            if (WorkaroundAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkaroundAttachments)))
                query.SelectWorkaroundAttachments(WorkaroundAttachments);

            if (Workflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Workflow)))
                query.SelectWorkflow(Workflow);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ProblemFilterField> filter in Filters)
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
