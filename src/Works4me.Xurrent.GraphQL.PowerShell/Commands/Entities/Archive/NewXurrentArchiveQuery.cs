using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ArchiveQuery"/> object for building Xurrent <see cref="Archive"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Archive"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentArchiveQuery")]
    [OutputType(typeof(ArchiveQuery))]
    public class NewXurrentArchiveQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Archive"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Archive"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveField[] Properties { get; set; } = Array.Empty<ArchiveField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Archive"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Archive"/> view for the <see cref="ArchiveQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Archive"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Archive"/> results in the <see cref="ArchiveQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Archive"/> results.<br/>
        /// If omitted, the <see cref="ArchiveQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Archive"/> items returned per request in the <see cref="ArchiveQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ArchiveQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="ConfigurationItem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ArchivedAsConfigurationItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Person"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? ArchivedAsPerson { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? ArchivedAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Project"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery? ArchivedAsProject { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? ArchivedAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReleaseQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Release"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery? ArchivedAsRelease { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? ArchivedAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Risk"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery? ArchivedAsRisk { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="ShopOrderLine"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? ArchivedAsShopOrderLine { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeEntryQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="TimeEntry"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery? ArchivedAsTimeEntry { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="Workflow"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? ArchivedAsWorkflow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="ArchiveQuery"/>, allowing related Archived data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? ArchivedAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ArchiveQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? ArchivedBy { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ArchiveFilterField}"/> conditions to the <see cref="ArchiveQuery"/>.<br/>
        /// Filters restrict which <see cref="Archive"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ArchiveFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ArchiveQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Archive"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ArchiveQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ArchiveQuery query = new();

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

            if (ArchivedAsConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsConfigurationItem)))
                query.SelectArchived(ArchivedAsConfigurationItem);

            if (ArchivedAsPerson is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsPerson)))
                query.SelectArchived(ArchivedAsPerson);

            if (ArchivedAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsProblem)))
                query.SelectArchived(ArchivedAsProblem);

            if (ArchivedAsProject is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsProject)))
                query.SelectArchived(ArchivedAsProject);

            if (ArchivedAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsProjectTask)))
                query.SelectArchived(ArchivedAsProjectTask);

            if (ArchivedAsRelease is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsRelease)))
                query.SelectArchived(ArchivedAsRelease);

            if (ArchivedAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsRequest)))
                query.SelectArchived(ArchivedAsRequest);

            if (ArchivedAsRisk is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsRisk)))
                query.SelectArchived(ArchivedAsRisk);

            if (ArchivedAsShopOrderLine is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsShopOrderLine)))
                query.SelectArchived(ArchivedAsShopOrderLine);

            if (ArchivedAsTimeEntry is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsTimeEntry)))
                query.SelectArchived(ArchivedAsTimeEntry);

            if (ArchivedAsWorkflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsWorkflow)))
                query.SelectArchived(ArchivedAsWorkflow);

            if (ArchivedAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedAsWorkflowTask)))
                query.SelectArchived(ArchivedAsWorkflowTask);

            if (ArchivedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ArchivedBy)))
                query.SelectArchivedBy(ArchivedBy);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ArchiveFilterField> filter in Filters)
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
