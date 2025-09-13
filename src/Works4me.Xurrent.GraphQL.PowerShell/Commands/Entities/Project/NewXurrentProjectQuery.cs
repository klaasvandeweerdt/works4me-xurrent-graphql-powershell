using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProjectQuery"/> object for building Xurrent <see cref="Project"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Project"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectQuery")]
    [OutputType(typeof(ProjectQuery))]
    public class NewXurrentProjectQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Project"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Project"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectField[] Properties { get; set; } = Array.Empty<ProjectField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Project"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Project"/> view for the <see cref="ProjectQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Project"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Project"/> results in the <see cref="ProjectQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Project"/> results.<br/>
        /// If omitted, the <see cref="ProjectQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Project"/> items returned per request in the <see cref="ProjectQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Customer { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InvoiceQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Invoice"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery? Invoices { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Manager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Notes { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectPhaseQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="ProjectPhase"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectPhaseQuery? Phases { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Problem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? Problems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Requests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Risk"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery? Risks { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="ProjectTask"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? Tasks { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? WorkHours { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="ProjectQuery"/>, allowing related <see cref="Workflow"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? Workflows { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ProjectFilterField}"/> conditions to the <see cref="ProjectQuery"/>.<br/>
        /// Filters restrict which <see cref="Project"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ProjectFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ProjectQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Project"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="Project"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/projectcustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProjectQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectQuery query = new();

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

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (Customer is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Customer)))
                query.SelectCustomer(Customer);

            if (Invoices is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Invoices)))
                query.SelectInvoices(Invoices);

            if (Manager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                query.SelectManager(Manager);

            if (Notes is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                query.SelectNotes(Notes);

            if (Phases is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Phases)))
                query.SelectPhases(Phases);

            if (Problems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Problems)))
                query.SelectProblems(Problems);

            if (Requests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Requests)))
                query.SelectRequests(Requests);

            if (Risks is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Risks)))
                query.SelectRisks(Risks);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (Tasks is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Tasks)))
                query.SelectTasks(Tasks);

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            if (WorkHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkHours)))
                query.SelectWorkHours(WorkHours);

            if (Workflows is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Workflows)))
                query.SelectWorkflows(Workflows);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ProjectFilterField> filter in Filters)
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
