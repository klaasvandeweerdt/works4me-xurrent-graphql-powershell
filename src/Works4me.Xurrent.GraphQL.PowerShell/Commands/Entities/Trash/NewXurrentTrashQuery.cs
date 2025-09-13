using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TrashQuery"/> object for building Xurrent <see cref="Trash"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Trash"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTrashQuery")]
    [OutputType(typeof(TrashQuery))]
    public class NewXurrentTrashQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Trash"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Trash"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashField[] Properties { get; set; } = Array.Empty<TrashField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Trash"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Trash"/> view for the <see cref="TrashQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Trash"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Trash"/> results in the <see cref="TrashQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Trash"/> results.<br/>
        /// If omitted, the <see cref="TrashQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Trash"/> items returned per request in the <see cref="TrashQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="TrashQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="ConfigurationItem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? TrashedAsConfigurationItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Person"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? TrashedAsPerson { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? TrashedAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Project"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery? TrashedAsProject { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? TrashedAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReleaseQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Release"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery? TrashedAsRelease { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? TrashedAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Risk"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery? TrashedAsRisk { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="ShopOrderLine"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? TrashedAsShopOrderLine { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeEntryQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="TimeEntry"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery? TrashedAsTimeEntry { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="Workflow"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? TrashedAsWorkflow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="TrashQuery"/>, allowing related Trashed data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? TrashedAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="TrashQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? TrashedBy { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{TrashFilterField}"/> conditions to the <see cref="TrashQuery"/>.<br/>
        /// Filters restrict which <see cref="Trash"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TrashFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="TrashQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Trash"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="TrashQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TrashQuery query = new();

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

            if (TrashedAsConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsConfigurationItem)))
                query.SelectTrashed(TrashedAsConfigurationItem);

            if (TrashedAsPerson is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsPerson)))
                query.SelectTrashed(TrashedAsPerson);

            if (TrashedAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsProblem)))
                query.SelectTrashed(TrashedAsProblem);

            if (TrashedAsProject is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsProject)))
                query.SelectTrashed(TrashedAsProject);

            if (TrashedAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsProjectTask)))
                query.SelectTrashed(TrashedAsProjectTask);

            if (TrashedAsRelease is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsRelease)))
                query.SelectTrashed(TrashedAsRelease);

            if (TrashedAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsRequest)))
                query.SelectTrashed(TrashedAsRequest);

            if (TrashedAsRisk is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsRisk)))
                query.SelectTrashed(TrashedAsRisk);

            if (TrashedAsShopOrderLine is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsShopOrderLine)))
                query.SelectTrashed(TrashedAsShopOrderLine);

            if (TrashedAsTimeEntry is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsTimeEntry)))
                query.SelectTrashed(TrashedAsTimeEntry);

            if (TrashedAsWorkflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsWorkflow)))
                query.SelectTrashed(TrashedAsWorkflow);

            if (TrashedAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedAsWorkflowTask)))
                query.SelectTrashed(TrashedAsWorkflowTask);

            if (TrashedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TrashedBy)))
                query.SelectTrashedBy(TrashedBy);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<TrashFilterField> filter in Filters)
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
