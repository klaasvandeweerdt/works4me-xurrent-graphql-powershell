using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ReservationQuery"/> object for building Xurrent <see cref="Reservation"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Reservation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentReservationQuery")]
    [OutputType(typeof(ReservationQuery))]
    public class NewXurrentReservationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Reservation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Reservation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationField[] Properties { get; set; } = Array.Empty<ReservationField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Reservation"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Reservation"/> view for the <see cref="ReservationQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Reservation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Reservation"/> results in the <see cref="ReservationQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Reservation"/> results.<br/>
        /// If omitted, the <see cref="ReservationQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Reservation"/> items returned per request in the <see cref="ReservationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? CreatedBy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? DescriptionAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Person { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RecurrenceQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Recurrence"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RecurrenceQuery? Recurrence { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Request { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReservationOfferingQuery"/> in the <see cref="ReservationQuery"/>, allowing related <see cref="ReservationOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOfferingQuery? ReservationOffering { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ReservationFilterField}"/> conditions to the <see cref="ReservationQuery"/>.<br/>
        /// Filters restrict which <see cref="Reservation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ReservationFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ReservationQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Reservation"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ReservationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ReservationQuery query = new();

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

            if (ConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItem)))
                query.SelectConfigurationItem(ConfigurationItem);

            if (CreatedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CreatedBy)))
                query.SelectCreatedBy(CreatedBy);

            if (DescriptionAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                query.SelectDescriptionAttachments(DescriptionAttachments);

            if (Person is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Person)))
                query.SelectPerson(Person);

            if (Recurrence is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Recurrence)))
                query.SelectRecurrence(Recurrence);

            if (Request is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Request)))
                query.SelectRequest(Request);

            if (ReservationOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ReservationOffering)))
                query.SelectReservationOffering(ReservationOffering);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ReservationFilterField> filter in Filters)
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
