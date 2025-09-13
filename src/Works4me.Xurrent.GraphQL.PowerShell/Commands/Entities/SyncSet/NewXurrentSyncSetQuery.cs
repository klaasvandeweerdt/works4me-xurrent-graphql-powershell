using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SyncSetQuery"/> object for building Xurrent <see cref="SyncSet"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="SyncSet"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSyncSetQuery")]
    [OutputType(typeof(SyncSetQuery))]
    public class NewXurrentSyncSetQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SyncSet"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SyncSet"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SyncSetField[] Properties { get; set; } = Array.Empty<SyncSetField>();

        /// <summary>
        /// Filters the query to return only the <see cref="SyncSet"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="SyncSet"/> view for the <see cref="SyncSetQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="SyncSet"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="SyncSet"/> results in the <see cref="SyncSetQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="SyncSet"/> results.<br/>
        /// If omitted, the <see cref="SyncSetQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="SyncSet"/> items returned per request in the <see cref="SyncSetQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SyncSetQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="SyncSetQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? DescriptionAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SnapshotQuery"/> in the <see cref="SyncSetQuery"/>, allowing related <see cref="Snapshot"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SnapshotQuery? LastSnapshot { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountDesignQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AccountDesign"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountDesignQuery? SelectedRecordsAsAccountDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardColumnQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AgileBoardColumn"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery? SelectedRecordsAsAgileBoardColumn { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AgileBoard"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery? SelectedRecordsAsAgileBoard { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AppInstanceQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AppInstance"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppInstanceQuery? SelectedRecordsAsAppInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AppOfferingAutomationRuleQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AppOfferingAutomationRule"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingAutomationRuleQuery? SelectedRecordsAsAppOfferingAutomationRule { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AppOfferingQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AppOffering"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingQuery? SelectedRecordsAsAppOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="AutomationRule"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? SelectedRecordsAsAutomationRule { get; set; }

        /// <summary>
        /// Includes a nested <see cref="BroadcastQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Broadcast"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public BroadcastQuery? SelectedRecordsAsBroadcast { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Calendar"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SelectedRecordsAsCalendar { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ClosureCodeQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ClosureCode"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ClosureCodeQuery? SelectedRecordsAsClosureCode { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ConfigurationItem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? SelectedRecordsAsConfigurationItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ContractQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Contract"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContractQuery? SelectedRecordsAsContract { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomCollectionElementQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="CustomCollectionElement"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomCollectionElementQuery? SelectedRecordsAsCustomCollectionElement { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomCollectionQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="CustomCollection"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomCollectionQuery? SelectedRecordsAsCustomCollection { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="EffortClass"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? SelectedRecordsAsEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EmailTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="EmailTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EmailTemplateQuery? SelectedRecordsAsEmailTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="FirstLineSupportAgreementQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="FirstLineSupportAgreement"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementQuery? SelectedRecordsAsFirstLineSupportAgreement { get; set; }

        /// <summary>
        /// Includes a nested <see cref="HolidayQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Holiday"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public HolidayQuery? SelectedRecordsAsHoliday { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InvoiceQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Invoice"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery? SelectedRecordsAsInvoice { get; set; }

        /// <summary>
        /// Includes a nested <see cref="KnowledgeArticleQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="KnowledgeArticle"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery? SelectedRecordsAsKnowledgeArticle { get; set; }

        /// <summary>
        /// Includes a nested <see cref="KnowledgeArticleTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="KnowledgeArticleTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleTemplateQuery? SelectedRecordsAsKnowledgeArticleTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Organization"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? SelectedRecordsAsOrganization { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OutOfOfficePeriodQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="OutOfOfficePeriod"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OutOfOfficePeriodQuery? SelectedRecordsAsOutOfOfficePeriod { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PdfDesignQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="PdfDesign"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PdfDesignQuery? SelectedRecordsAsPdfDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Person"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? SelectedRecordsAsPerson { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? SelectedRecordsAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductBacklogQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProductBacklog"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductBacklogQuery? SelectedRecordsAsProductBacklog { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductCategoryQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProductCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductCategoryQuery? SelectedRecordsAsProductCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Product"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductQuery? SelectedRecordsAsProduct { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectCategoryQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProjectCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectCategoryQuery? SelectedRecordsAsProjectCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Project"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery? SelectedRecordsAsProject { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectRiskLevelQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProjectRiskLevel"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectRiskLevelQuery? SelectedRecordsAsProjectRiskLevel { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? SelectedRecordsAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProjectTaskTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateQuery? SelectedRecordsAsProjectTaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ProjectTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTemplateQuery? SelectedRecordsAsProjectTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReleaseQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Release"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery? SelectedRecordsAsRelease { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? SelectedRecordsAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="RequestTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? SelectedRecordsAsRequestTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReservationOfferingQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ReservationOffering"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOfferingQuery? SelectedRecordsAsReservationOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReservationQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Reservation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationQuery? SelectedRecordsAsReservation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Risk"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery? SelectedRecordsAsRisk { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskSeverityQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="RiskSeverity"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskSeverityQuery? SelectedRecordsAsRiskSeverity { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ScrumWorkspaceQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ScrumWorkspace"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ScrumWorkspaceQuery? SelectedRecordsAsScrumWorkspace { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceCategoryQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ServiceCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceCategoryQuery? SelectedRecordsAsServiceCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ServiceInstance"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? SelectedRecordsAsServiceInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceLevelAgreementQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ServiceLevelAgreement"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery? SelectedRecordsAsServiceLevelAgreement { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceOfferingQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ServiceOffering"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery? SelectedRecordsAsServiceOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Service"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? SelectedRecordsAsService { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleCategoryQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ShopArticleCategory"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryQuery? SelectedRecordsAsShopArticleCategory { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ShopArticle"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery? SelectedRecordsAsShopArticle { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ShopOrderLine"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? SelectedRecordsAsShopOrderLine { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShortUrlQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="ShortUrl"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShortUrlQuery? SelectedRecordsAsShortUrl { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Site"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? SelectedRecordsAsSite { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SkillPoolQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SkillPool"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery? SelectedRecordsAsSkillPool { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaCoverageGroupQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SlaCoverageGroup"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaCoverageGroupQuery? SelectedRecordsAsSlaCoverageGroup { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SlaNotificationScheme"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? SelectedRecordsAsSlaNotificationScheme { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SprintBacklogItemQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SprintBacklogItem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintBacklogItemQuery? SelectedRecordsAsSprintBacklogItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SprintQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Sprint"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintQuery? SelectedRecordsAsSprint { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyAnswerQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SurveyAnswer"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyAnswerQuery? SelectedRecordsAsSurveyAnswer { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Survey"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuery? SelectedRecordsAsSurvey { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuestionQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SurveyQuestion"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuestionQuery? SelectedRecordsAsSurveyQuestion { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyResponseQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SurveyResponse"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyResponseQuery? SelectedRecordsAsSurveyResponse { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SyncSetQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="SyncSet"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SyncSetQuery? SelectedRecordsAsSyncSet { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TagQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Tag"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TagQuery? SelectedRecordsAsTag { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Team"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? SelectedRecordsAsTeam { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeAllocationQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="TimeAllocation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationQuery? SelectedRecordsAsTimeAllocation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeEntryQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="TimeEntry"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery? SelectedRecordsAsTimeEntry { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimesheetSettingQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="TimesheetSetting"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimesheetSettingQuery? SelectedRecordsAsTimesheetSetting { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Translation"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? SelectedRecordsAsTranslation { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="UiExtension"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? SelectedRecordsAsUiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WaitingForCustomerFollowUpQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WaitingForCustomerFollowUp"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WaitingForCustomerFollowUpQuery? SelectedRecordsAsWaitingForCustomerFollowUp { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WebhookPolicyQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WebhookPolicy"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookPolicyQuery? SelectedRecordsAsWebhookPolicy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WebhookQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Webhook"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookQuery? SelectedRecordsAsWebhook { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="Workflow"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? SelectedRecordsAsWorkflow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? SelectedRecordsAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WorkflowTaskTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateQuery? SelectedRecordsAsWorkflowTaskTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplateQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WorkflowTemplate"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery? SelectedRecordsAsWorkflowTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTypeQuery"/> in the <see cref="SyncSetQuery"/>, allowing related SelectedRecords data, cast to <see cref="WorkflowType"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTypeQuery? SelectedRecordsAsWorkflowType { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{SyncSetFilterField}"/> conditions to the <see cref="SyncSetQuery"/>.<br/>
        /// Filters restrict which <see cref="SyncSet"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<SyncSetFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SyncSetQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SyncSetQuery query = new();

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

            if (DescriptionAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                query.SelectDescriptionAttachments(DescriptionAttachments);

            if (LastSnapshot is not null && MyInvocation.BoundParameters.ContainsKey(nameof(LastSnapshot)))
                query.SelectLastSnapshot(LastSnapshot);

            if (SelectedRecordsAsAccountDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAccountDesign)))
                query.SelectSelectedRecords(SelectedRecordsAsAccountDesign);

            if (SelectedRecordsAsAgileBoardColumn is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAgileBoardColumn)))
                query.SelectSelectedRecords(SelectedRecordsAsAgileBoardColumn);

            if (SelectedRecordsAsAgileBoard is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAgileBoard)))
                query.SelectSelectedRecords(SelectedRecordsAsAgileBoard);

            if (SelectedRecordsAsAppInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAppInstance)))
                query.SelectSelectedRecords(SelectedRecordsAsAppInstance);

            if (SelectedRecordsAsAppOfferingAutomationRule is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAppOfferingAutomationRule)))
                query.SelectSelectedRecords(SelectedRecordsAsAppOfferingAutomationRule);

            if (SelectedRecordsAsAppOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAppOffering)))
                query.SelectSelectedRecords(SelectedRecordsAsAppOffering);

            if (SelectedRecordsAsAutomationRule is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsAutomationRule)))
                query.SelectSelectedRecords(SelectedRecordsAsAutomationRule);

            if (SelectedRecordsAsBroadcast is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsBroadcast)))
                query.SelectSelectedRecords(SelectedRecordsAsBroadcast);

            if (SelectedRecordsAsCalendar is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsCalendar)))
                query.SelectSelectedRecords(SelectedRecordsAsCalendar);

            if (SelectedRecordsAsClosureCode is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsClosureCode)))
                query.SelectSelectedRecords(SelectedRecordsAsClosureCode);

            if (SelectedRecordsAsConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsConfigurationItem)))
                query.SelectSelectedRecords(SelectedRecordsAsConfigurationItem);

            if (SelectedRecordsAsContract is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsContract)))
                query.SelectSelectedRecords(SelectedRecordsAsContract);

            if (SelectedRecordsAsCustomCollectionElement is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsCustomCollectionElement)))
                query.SelectSelectedRecords(SelectedRecordsAsCustomCollectionElement);

            if (SelectedRecordsAsCustomCollection is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsCustomCollection)))
                query.SelectSelectedRecords(SelectedRecordsAsCustomCollection);

            if (SelectedRecordsAsEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsEffortClass)))
                query.SelectSelectedRecords(SelectedRecordsAsEffortClass);

            if (SelectedRecordsAsEmailTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsEmailTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsEmailTemplate);

            if (SelectedRecordsAsFirstLineSupportAgreement is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsFirstLineSupportAgreement)))
                query.SelectSelectedRecords(SelectedRecordsAsFirstLineSupportAgreement);

            if (SelectedRecordsAsHoliday is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsHoliday)))
                query.SelectSelectedRecords(SelectedRecordsAsHoliday);

            if (SelectedRecordsAsInvoice is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsInvoice)))
                query.SelectSelectedRecords(SelectedRecordsAsInvoice);

            if (SelectedRecordsAsKnowledgeArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsKnowledgeArticle)))
                query.SelectSelectedRecords(SelectedRecordsAsKnowledgeArticle);

            if (SelectedRecordsAsKnowledgeArticleTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsKnowledgeArticleTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsKnowledgeArticleTemplate);

            if (SelectedRecordsAsOrganization is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsOrganization)))
                query.SelectSelectedRecords(SelectedRecordsAsOrganization);

            if (SelectedRecordsAsOutOfOfficePeriod is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsOutOfOfficePeriod)))
                query.SelectSelectedRecords(SelectedRecordsAsOutOfOfficePeriod);

            if (SelectedRecordsAsPdfDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsPdfDesign)))
                query.SelectSelectedRecords(SelectedRecordsAsPdfDesign);

            if (SelectedRecordsAsPerson is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsPerson)))
                query.SelectSelectedRecords(SelectedRecordsAsPerson);

            if (SelectedRecordsAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProblem)))
                query.SelectSelectedRecords(SelectedRecordsAsProblem);

            if (SelectedRecordsAsProductBacklog is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProductBacklog)))
                query.SelectSelectedRecords(SelectedRecordsAsProductBacklog);

            if (SelectedRecordsAsProductCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProductCategory)))
                query.SelectSelectedRecords(SelectedRecordsAsProductCategory);

            if (SelectedRecordsAsProduct is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProduct)))
                query.SelectSelectedRecords(SelectedRecordsAsProduct);

            if (SelectedRecordsAsProjectCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProjectCategory)))
                query.SelectSelectedRecords(SelectedRecordsAsProjectCategory);

            if (SelectedRecordsAsProject is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProject)))
                query.SelectSelectedRecords(SelectedRecordsAsProject);

            if (SelectedRecordsAsProjectRiskLevel is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProjectRiskLevel)))
                query.SelectSelectedRecords(SelectedRecordsAsProjectRiskLevel);

            if (SelectedRecordsAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProjectTask)))
                query.SelectSelectedRecords(SelectedRecordsAsProjectTask);

            if (SelectedRecordsAsProjectTaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProjectTaskTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsProjectTaskTemplate);

            if (SelectedRecordsAsProjectTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsProjectTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsProjectTemplate);

            if (SelectedRecordsAsRelease is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsRelease)))
                query.SelectSelectedRecords(SelectedRecordsAsRelease);

            if (SelectedRecordsAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsRequest)))
                query.SelectSelectedRecords(SelectedRecordsAsRequest);

            if (SelectedRecordsAsRequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsRequestTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsRequestTemplate);

            if (SelectedRecordsAsReservationOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsReservationOffering)))
                query.SelectSelectedRecords(SelectedRecordsAsReservationOffering);

            if (SelectedRecordsAsReservation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsReservation)))
                query.SelectSelectedRecords(SelectedRecordsAsReservation);

            if (SelectedRecordsAsRisk is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsRisk)))
                query.SelectSelectedRecords(SelectedRecordsAsRisk);

            if (SelectedRecordsAsRiskSeverity is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsRiskSeverity)))
                query.SelectSelectedRecords(SelectedRecordsAsRiskSeverity);

            if (SelectedRecordsAsScrumWorkspace is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsScrumWorkspace)))
                query.SelectSelectedRecords(SelectedRecordsAsScrumWorkspace);

            if (SelectedRecordsAsServiceCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsServiceCategory)))
                query.SelectSelectedRecords(SelectedRecordsAsServiceCategory);

            if (SelectedRecordsAsServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsServiceInstance)))
                query.SelectSelectedRecords(SelectedRecordsAsServiceInstance);

            if (SelectedRecordsAsServiceLevelAgreement is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsServiceLevelAgreement)))
                query.SelectSelectedRecords(SelectedRecordsAsServiceLevelAgreement);

            if (SelectedRecordsAsServiceOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsServiceOffering)))
                query.SelectSelectedRecords(SelectedRecordsAsServiceOffering);

            if (SelectedRecordsAsService is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsService)))
                query.SelectSelectedRecords(SelectedRecordsAsService);

            if (SelectedRecordsAsShopArticleCategory is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsShopArticleCategory)))
                query.SelectSelectedRecords(SelectedRecordsAsShopArticleCategory);

            if (SelectedRecordsAsShopArticle is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsShopArticle)))
                query.SelectSelectedRecords(SelectedRecordsAsShopArticle);

            if (SelectedRecordsAsShopOrderLine is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsShopOrderLine)))
                query.SelectSelectedRecords(SelectedRecordsAsShopOrderLine);

            if (SelectedRecordsAsShortUrl is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsShortUrl)))
                query.SelectSelectedRecords(SelectedRecordsAsShortUrl);

            if (SelectedRecordsAsSite is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSite)))
                query.SelectSelectedRecords(SelectedRecordsAsSite);

            if (SelectedRecordsAsSkillPool is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSkillPool)))
                query.SelectSelectedRecords(SelectedRecordsAsSkillPool);

            if (SelectedRecordsAsSlaCoverageGroup is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSlaCoverageGroup)))
                query.SelectSelectedRecords(SelectedRecordsAsSlaCoverageGroup);

            if (SelectedRecordsAsSlaNotificationScheme is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSlaNotificationScheme)))
                query.SelectSelectedRecords(SelectedRecordsAsSlaNotificationScheme);

            if (SelectedRecordsAsSprintBacklogItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSprintBacklogItem)))
                query.SelectSelectedRecords(SelectedRecordsAsSprintBacklogItem);

            if (SelectedRecordsAsSprint is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSprint)))
                query.SelectSelectedRecords(SelectedRecordsAsSprint);

            if (SelectedRecordsAsSurveyAnswer is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSurveyAnswer)))
                query.SelectSelectedRecords(SelectedRecordsAsSurveyAnswer);

            if (SelectedRecordsAsSurvey is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSurvey)))
                query.SelectSelectedRecords(SelectedRecordsAsSurvey);

            if (SelectedRecordsAsSurveyQuestion is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSurveyQuestion)))
                query.SelectSelectedRecords(SelectedRecordsAsSurveyQuestion);

            if (SelectedRecordsAsSurveyResponse is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSurveyResponse)))
                query.SelectSelectedRecords(SelectedRecordsAsSurveyResponse);

            if (SelectedRecordsAsSyncSet is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsSyncSet)))
                query.SelectSelectedRecords(SelectedRecordsAsSyncSet);

            if (SelectedRecordsAsTag is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTag)))
                query.SelectSelectedRecords(SelectedRecordsAsTag);

            if (SelectedRecordsAsTeam is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTeam)))
                query.SelectSelectedRecords(SelectedRecordsAsTeam);

            if (SelectedRecordsAsTimeAllocation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTimeAllocation)))
                query.SelectSelectedRecords(SelectedRecordsAsTimeAllocation);

            if (SelectedRecordsAsTimeEntry is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTimeEntry)))
                query.SelectSelectedRecords(SelectedRecordsAsTimeEntry);

            if (SelectedRecordsAsTimesheetSetting is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTimesheetSetting)))
                query.SelectSelectedRecords(SelectedRecordsAsTimesheetSetting);

            if (SelectedRecordsAsTranslation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsTranslation)))
                query.SelectSelectedRecords(SelectedRecordsAsTranslation);

            if (SelectedRecordsAsUiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsUiExtension)))
                query.SelectSelectedRecords(SelectedRecordsAsUiExtension);

            if (SelectedRecordsAsWaitingForCustomerFollowUp is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWaitingForCustomerFollowUp)))
                query.SelectSelectedRecords(SelectedRecordsAsWaitingForCustomerFollowUp);

            if (SelectedRecordsAsWebhookPolicy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWebhookPolicy)))
                query.SelectSelectedRecords(SelectedRecordsAsWebhookPolicy);

            if (SelectedRecordsAsWebhook is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWebhook)))
                query.SelectSelectedRecords(SelectedRecordsAsWebhook);

            if (SelectedRecordsAsWorkflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWorkflow)))
                query.SelectSelectedRecords(SelectedRecordsAsWorkflow);

            if (SelectedRecordsAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWorkflowTask)))
                query.SelectSelectedRecords(SelectedRecordsAsWorkflowTask);

            if (SelectedRecordsAsWorkflowTaskTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWorkflowTaskTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsWorkflowTaskTemplate);

            if (SelectedRecordsAsWorkflowTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWorkflowTemplate)))
                query.SelectSelectedRecords(SelectedRecordsAsWorkflowTemplate);

            if (SelectedRecordsAsWorkflowType is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SelectedRecordsAsWorkflowType)))
                query.SelectSelectedRecords(SelectedRecordsAsWorkflowType);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<SyncSetFilterField> filter in Filters)
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
