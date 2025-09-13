using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ShopArticleCategoryQuery"/> object for building Xurrent <see cref="ShopArticleCategory"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ShopArticleCategory"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentShopArticleCategoryQuery")]
    [OutputType(typeof(ShopArticleCategoryQuery))]
    public class NewXurrentShopArticleCategoryQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ShopArticleCategory"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ShopArticleCategory"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryField[] Properties { get; set; } = Array.Empty<ShopArticleCategoryField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ShopArticleCategory"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ShopArticleCategory"/> view for the <see cref="ShopArticleCategoryQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ShopArticleCategory"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ShopArticleCategory"/> results in the <see cref="ShopArticleCategoryQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ShopArticleCategory"/> results.<br/>
        /// If omitted, the <see cref="ShopArticleCategoryQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ShopArticleCategory"/> items returned per request in the <see cref="ShopArticleCategoryQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ShopArticleCategoryQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ShopArticleCategoryQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? FullDescriptionAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleCategoryQuery"/> in the <see cref="ShopArticleCategoryQuery"/>, allowing related <see cref="ShopArticleCategory"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryQuery? Parent { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="ShopArticleCategoryQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ShopArticleCategoryFilterField}"/> conditions to the <see cref="ShopArticleCategoryQuery"/>.<br/>
        /// Filters restrict which <see cref="ShopArticleCategory"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ShopArticleCategoryFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ShopArticleCategoryQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ShopArticleCategory"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ShopArticleCategoryQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ShopArticleCategoryQuery query = new();

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

            if (FullDescriptionAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FullDescriptionAttachments)))
                query.SelectFullDescriptionAttachments(FullDescriptionAttachments);

            if (Parent is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Parent)))
                query.SelectParent(Parent);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ShopArticleCategoryFilterField> filter in Filters)
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
