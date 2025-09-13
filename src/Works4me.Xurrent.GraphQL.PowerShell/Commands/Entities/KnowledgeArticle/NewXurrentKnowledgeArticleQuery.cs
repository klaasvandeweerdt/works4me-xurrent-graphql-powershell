using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="KnowledgeArticleQuery"/> object for building Xurrent <see cref="KnowledgeArticle"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="KnowledgeArticle"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentKnowledgeArticleQuery")]
    [OutputType(typeof(KnowledgeArticleQuery))]
    public class NewXurrentKnowledgeArticleQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="KnowledgeArticle"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="KnowledgeArticle"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleField[] Properties { get; set; } = Array.Empty<KnowledgeArticleField>();

        /// <summary>
        /// Filters the query to return only the <see cref="KnowledgeArticle"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="KnowledgeArticle"/> view for the <see cref="KnowledgeArticleQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="KnowledgeArticle"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="KnowledgeArticle"/> results in the <see cref="KnowledgeArticleQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="KnowledgeArticle"/> results.<br/>
        /// If omitted, the <see cref="KnowledgeArticleQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="KnowledgeArticle"/> items returned per request in the <see cref="KnowledgeArticleQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? CreatedBy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? DescriptionAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InstructionsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Requests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstances { get; set; }

        /// <summary>
        /// Includes a nested <see cref="KnowledgeArticleTemplateQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="KnowledgeArticleTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleTemplateQuery? Template { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="KnowledgeArticleQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? UpdatedBy { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{KnowledgeArticleFilterField}"/> conditions to the <see cref="KnowledgeArticleQuery"/>.<br/>
        /// Filters restrict which <see cref="KnowledgeArticle"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<KnowledgeArticleFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="KnowledgeArticleQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="KnowledgeArticle"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="KnowledgeArticle"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/knowledgearticlecustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="KnowledgeArticleQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            KnowledgeArticleQuery query = new();

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

            if (CreatedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CreatedBy)))
                query.SelectCreatedBy(CreatedBy);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (DescriptionAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                query.SelectDescriptionAttachments(DescriptionAttachments);

            if (InstructionsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InstructionsAttachments)))
                query.SelectInstructionsAttachments(InstructionsAttachments);

            if (Requests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Requests)))
                query.SelectRequests(Requests);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (ServiceInstances is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstances)))
                query.SelectServiceInstances(ServiceInstances);

            if (Template is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Template)))
                query.SelectTemplate(Template);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            if (UpdatedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UpdatedBy)))
                query.SelectUpdatedBy(UpdatedBy);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<KnowledgeArticleFilterField> filter in Filters)
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
