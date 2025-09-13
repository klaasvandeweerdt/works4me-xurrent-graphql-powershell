using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TranslationQuery"/> object for building Xurrent <see cref="Translation"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Translation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTranslationQuery")]
    [OutputType(typeof(TranslationQuery))]
    public class NewXurrentTranslationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Translation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Translation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationField[] Properties { get; set; } = Array.Empty<TranslationField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Translation"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Translation"/> view for the <see cref="TranslationQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Translation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Translation"/> results in the <see cref="TranslationQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Translation"/> results.<br/>
        /// If omitted, the <see cref="TranslationQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Translation"/> items returned per request in the <see cref="TranslationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="TranslationQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountDesignQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="AccountDesign"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountDesignQuery? OwnerAsAccountDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ClosureCodeQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ClosureCode"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ClosureCodeQuery? OwnerAsClosureCode { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomCollectionElementQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="CustomCollectionElement"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomCollectionElementQuery? OwnerAsCustomCollectionElement { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EmailTemplateQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="EmailTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EmailTemplateQuery? OwnerAsEmailTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="KnowledgeArticleQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="KnowledgeArticle"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery? OwnerAsKnowledgeArticle { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PdfDesignQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="PdfDesign"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PdfDesignQuery? OwnerAsPdfDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductCategoryQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ProductCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductCategoryQuery? OwnerAsProductCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="RequestTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? OwnerAsRequestTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskSeverityQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="RiskSeverity"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskSeverityQuery? OwnerAsRiskSeverity { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceCategoryQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ServiceCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceCategoryQuery? OwnerAsServiceCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ServiceInstance"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? OwnerAsServiceInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="Service"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? OwnerAsService { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleCategoryQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ShopArticleCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryQuery? OwnerAsShopArticleCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="ShopArticle"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery? OwnerAsShopArticle { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="Survey"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuery? OwnerAsSurvey { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuestionQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="SurveyQuestion"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuestionQuery? OwnerAsSurveyQuestion { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeAllocationQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="TimeAllocation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationQuery? OwnerAsTimeAllocation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="UiExtension"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? OwnerAsUiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplatePhaseQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="WorkflowTemplatePhase"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseQuery? OwnerAsWorkflowTemplatePhase { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTypeQuery"/> in the <see cref="TranslationQuery"/>, allowing related Owner data, cast to <see cref="WorkflowType"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTypeQuery? OwnerAsWorkflowType { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{TranslationFilterField}"/> conditions to the <see cref="TranslationQuery"/>.<br/>
        /// Filters restrict which <see cref="Translation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TranslationFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="TranslationQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Translation"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="TranslationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TranslationQuery query = new();

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

            if (OwnerAsAccountDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsAccountDesign)))
                query.SelectOwner(OwnerAsAccountDesign);

            if (OwnerAsClosureCode is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsClosureCode)))
                query.SelectOwner(OwnerAsClosureCode);

            if (OwnerAsCustomCollectionElement is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsCustomCollectionElement)))
                query.SelectOwner(OwnerAsCustomCollectionElement);

            if (OwnerAsEmailTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsEmailTemplate)))
                query.SelectOwner(OwnerAsEmailTemplate);

            if (OwnerAsKnowledgeArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsKnowledgeArticle)))
                query.SelectOwner(OwnerAsKnowledgeArticle);

            if (OwnerAsPdfDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsPdfDesign)))
                query.SelectOwner(OwnerAsPdfDesign);

            if (OwnerAsProductCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsProductCategory)))
                query.SelectOwner(OwnerAsProductCategory);

            if (OwnerAsRequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsRequestTemplate)))
                query.SelectOwner(OwnerAsRequestTemplate);

            if (OwnerAsRiskSeverity is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsRiskSeverity)))
                query.SelectOwner(OwnerAsRiskSeverity);

            if (OwnerAsServiceCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsServiceCategory)))
                query.SelectOwner(OwnerAsServiceCategory);

            if (OwnerAsServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsServiceInstance)))
                query.SelectOwner(OwnerAsServiceInstance);

            if (OwnerAsService is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsService)))
                query.SelectOwner(OwnerAsService);

            if (OwnerAsShopArticleCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsShopArticleCategory)))
                query.SelectOwner(OwnerAsShopArticleCategory);

            if (OwnerAsShopArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsShopArticle)))
                query.SelectOwner(OwnerAsShopArticle);

            if (OwnerAsSurvey is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsSurvey)))
                query.SelectOwner(OwnerAsSurvey);

            if (OwnerAsSurveyQuestion is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsSurveyQuestion)))
                query.SelectOwner(OwnerAsSurveyQuestion);

            if (OwnerAsTimeAllocation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsTimeAllocation)))
                query.SelectOwner(OwnerAsTimeAllocation);

            if (OwnerAsUiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsUiExtension)))
                query.SelectOwner(OwnerAsUiExtension);

            if (OwnerAsWorkflowTemplatePhase is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowTemplatePhase)))
                query.SelectOwner(OwnerAsWorkflowTemplatePhase);

            if (OwnerAsWorkflowType is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OwnerAsWorkflowType)))
                query.SelectOwner(OwnerAsWorkflowType);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<TranslationFilterField> filter in Filters)
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
