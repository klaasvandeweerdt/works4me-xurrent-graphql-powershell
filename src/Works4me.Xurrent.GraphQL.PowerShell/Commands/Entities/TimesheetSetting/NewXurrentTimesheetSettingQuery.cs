using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TimesheetSettingQuery"/> object for building Xurrent <see cref="TimesheetSetting"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="TimesheetSetting"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTimesheetSettingQuery")]
    [OutputType(typeof(TimesheetSettingQuery))]
    public class NewXurrentTimesheetSettingQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="TimesheetSetting"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="TimesheetSetting"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimesheetSettingField[] Properties { get; set; } = Array.Empty<TimesheetSettingField>();

        /// <summary>
        /// Filters the query to return only the <see cref="TimesheetSetting"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="TimesheetSetting"/> view for the <see cref="TimesheetSettingQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="TimesheetSetting"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="TimesheetSetting"/> results in the <see cref="TimesheetSettingQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="TimesheetSetting"/> results.<br/>
        /// If omitted, the <see cref="TimesheetSettingQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="TimesheetSetting"/> items returned per request in the <see cref="TimesheetSettingQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClasses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organizations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? ProblemEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? ProjectTaskEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? RequestEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? TaskEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimesheetSettingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? TimeAllocationEffortClass { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{TimesheetSettingFilterField}"/> conditions to the <see cref="TimesheetSettingQuery"/>.<br/>
        /// Filters restrict which <see cref="TimesheetSetting"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TimesheetSettingFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="TimesheetSettingQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TimesheetSettingQuery query = new();

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

            if (EffortClasses is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClasses)))
                query.SelectEffortClasses(EffortClasses);

            if (Organizations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organizations)))
                query.SelectOrganizations(Organizations);

            if (ProblemEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProblemEffortClass)))
                query.SelectProblemEffortClass(ProblemEffortClass);

            if (ProjectTaskEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProjectTaskEffortClass)))
                query.SelectProjectTaskEffortClass(ProjectTaskEffortClass);

            if (RequestEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestEffortClass)))
                query.SelectRequestEffortClass(RequestEffortClass);

            if (TaskEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TaskEffortClass)))
                query.SelectTaskEffortClass(TaskEffortClass);

            if (TimeAllocationEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocationEffortClass)))
                query.SelectTimeAllocationEffortClass(TimeAllocationEffortClass);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<TimesheetSettingFilterField> filter in Filters)
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

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
