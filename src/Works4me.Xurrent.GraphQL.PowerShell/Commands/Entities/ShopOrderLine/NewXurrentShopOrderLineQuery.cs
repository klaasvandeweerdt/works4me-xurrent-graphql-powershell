using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ShopOrderLineQuery"/> object for building Xurrent <see cref="ShopOrderLine"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ShopOrderLine"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentShopOrderLineQuery")]
    [OutputType(typeof(ShopOrderLineQuery))]
    public class NewXurrentShopOrderLineQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ShopOrderLine"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ShopOrderLine"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineField[] Properties { get; set; } = Array.Empty<ShopOrderLineField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ShopOrderLine"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ShopOrderLine"/> view for the <see cref="ShopOrderLineQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ShopOrderLine"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ShopOrderLine"/> results in the <see cref="ShopOrderLineQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ShopOrderLine"/> results.<br/>
        /// If omitted, the <see cref="ShopOrderLineQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ShopOrderLine"/> items returned per request in the <see cref="ShopOrderLineQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AddressQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Address"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AddressQuery? Addresses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? FulfillmentRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="WorkflowTask"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? FulfillmentTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="RequestTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? FulfillmentTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Order { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProviderShopOrderLineQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="ProviderShopOrderLine"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProviderShopOrderLineQuery? ProviderOrderLine { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? RequestedBy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? RequestedFor { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleQuery"/> in the <see cref="ShopOrderLineQuery"/>, allowing related <see cref="ShopArticle"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery? ShopArticle { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ShopOrderLineFilterField}"/> conditions to the <see cref="ShopOrderLineQuery"/>.<br/>
        /// Filters restrict which <see cref="ShopOrderLine"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ShopOrderLineFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ShopOrderLineQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ShopOrderLine"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ShopOrderLineQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ShopOrderLineQuery query = new();

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

            if (Addresses is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Addresses)))
                query.SelectAddresses(Addresses);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (FulfillmentRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FulfillmentRequest)))
                query.SelectFulfillmentRequest(FulfillmentRequest);

            if (FulfillmentTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FulfillmentTask)))
                query.SelectFulfillmentTask(FulfillmentTask);

            if (FulfillmentTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FulfillmentTemplate)))
                query.SelectFulfillmentTemplate(FulfillmentTemplate);

            if (Order is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Order)))
                query.SelectOrder(Order);

            if (ProviderOrderLine is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProviderOrderLine)))
                query.SelectProviderOrderLine(ProviderOrderLine);

            if (RequestedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedBy)))
                query.SelectRequestedBy(RequestedBy);

            if (RequestedFor is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedFor)))
                query.SelectRequestedFor(RequestedFor);

            if (ShopArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ShopArticle)))
                query.SelectShopArticle(ShopArticle);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ShopOrderLineFilterField> filter in Filters)
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
