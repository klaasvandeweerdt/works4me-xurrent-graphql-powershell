using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="CalendarQuery"/> object for building Xurrent <see cref="Calendar"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Calendar"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentCalendarQuery")]
    [OutputType(typeof(CalendarQuery))]
    public class NewXurrentCalendarQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Calendar"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Calendar"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarField[] Properties { get; set; } = Array.Empty<CalendarField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Calendar"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Calendar"/> view for the <see cref="CalendarQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Calendar"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Calendar"/> results in the <see cref="CalendarQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Calendar"/> results.<br/>
        /// If omitted, the <see cref="CalendarQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Calendar"/> items returned per request in the <see cref="CalendarQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="CalendarQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarHourQuery"/> in the <see cref="CalendarQuery"/>, allowing related <see cref="CalendarHour"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarHourQuery? CalendarHours { get; set; }

        /// <summary>
        /// Includes a nested <see cref="HolidayQuery"/> in the <see cref="CalendarQuery"/>, allowing related <see cref="Holiday"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public HolidayQuery? Holidays { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{CalendarFilterField}"/> conditions to the <see cref="CalendarQuery"/>.<br/>
        /// Filters restrict which <see cref="Calendar"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<CalendarFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="CalendarQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CalendarQuery query = new();

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

            if (CalendarHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CalendarHours)))
                query.SelectCalendarHours(CalendarHours);

            if (Holidays is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Holidays)))
                query.SelectHolidays(Holidays);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<CalendarFilterField> filter in Filters)
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
