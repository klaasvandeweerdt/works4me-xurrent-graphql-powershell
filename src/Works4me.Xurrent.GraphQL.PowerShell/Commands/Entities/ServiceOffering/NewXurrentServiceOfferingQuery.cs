using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ServiceOfferingQuery"/> object for building Xurrent <see cref="ServiceOffering"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ServiceOffering"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentServiceOfferingQuery")]
    [OutputType(typeof(ServiceOfferingQuery))]
    public class NewXurrentServiceOfferingQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ServiceOffering"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ServiceOffering"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingField[] Properties { get; set; } = Array.Empty<ServiceOfferingField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ServiceOffering"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ServiceOffering"/> view for the <see cref="ServiceOfferingQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ServiceOffering"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ServiceOffering"/> results in the <see cref="ServiceOfferingQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ServiceOffering"/> results.<br/>
        /// If omitted, the <see cref="ServiceOfferingQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ServiceOffering"/> items returned per request in the <see cref="ServiceOfferingQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? ChargesAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? ContinuityAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? DefaultEffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassRateQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="EffortClassRate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateQuery? EffortClassRates { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClasses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? LimitationsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? PenaltiesAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? PerformanceAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? PrerequisitesAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResolutionTargetNotificationSchemeHigh { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResolutionTargetNotificationSchemeLow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResolutionTargetNotificationSchemeMedium { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResolutionTargetNotificationSchemeTop { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResponseTargetNotificationSchemeHigh { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResponseTargetNotificationSchemeLow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResponseTargetNotificationSchemeMedium { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResponseTargetNotificationSchemeTop { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? ServiceHours { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceLevelAgreementQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="ServiceLevelAgreement"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery? ServiceLevelAgreements { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopArticleQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="ShopArticle"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery? ShopArticles { get; set; }

        /// <summary>
        /// Includes a nested <see cref="StandardServiceRequestQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="StandardServiceRequest"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery? StandardServiceRequests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? SummaryAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursCase { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursHigh { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursLow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursMedium { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursRfc { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursRfi { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHoursTop { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? TerminationAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WaitingForCustomerFollowUpQuery"/> in the <see cref="ServiceOfferingQuery"/>, allowing related <see cref="WaitingForCustomerFollowUp"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WaitingForCustomerFollowUpQuery? WaitingForCustomerFollowUp { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ServiceOfferingFilterField}"/> conditions to the <see cref="ServiceOfferingQuery"/>.<br/>
        /// Filters restrict which <see cref="ServiceOffering"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ServiceOfferingFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ServiceOfferingQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ServiceOffering"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ServiceOfferingQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ServiceOfferingQuery query = new();

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

            if (ChargesAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ChargesAttachments)))
                query.SelectChargesAttachments(ChargesAttachments);

            if (ContinuityAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ContinuityAttachments)))
                query.SelectContinuityAttachments(ContinuityAttachments);

            if (DefaultEffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DefaultEffortClass)))
                query.SelectDefaultEffortClass(DefaultEffortClass);

            if (EffortClassRates is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassRates)))
                query.SelectEffortClassRates(EffortClassRates);

            if (EffortClasses is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClasses)))
                query.SelectEffortClasses(EffortClasses);

            if (LimitationsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(LimitationsAttachments)))
                query.SelectLimitationsAttachments(LimitationsAttachments);

            if (PenaltiesAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(PenaltiesAttachments)))
                query.SelectPenaltiesAttachments(PenaltiesAttachments);

            if (PerformanceAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(PerformanceAttachments)))
                query.SelectPerformanceAttachments(PerformanceAttachments);

            if (PrerequisitesAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(PrerequisitesAttachments)))
                query.SelectPrerequisitesAttachments(PrerequisitesAttachments);

            if (ResolutionTargetNotificationSchemeHigh is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetNotificationSchemeHigh)))
                query.SelectResolutionTargetNotificationSchemeHigh(ResolutionTargetNotificationSchemeHigh);

            if (ResolutionTargetNotificationSchemeLow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetNotificationSchemeLow)))
                query.SelectResolutionTargetNotificationSchemeLow(ResolutionTargetNotificationSchemeLow);

            if (ResolutionTargetNotificationSchemeMedium is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetNotificationSchemeMedium)))
                query.SelectResolutionTargetNotificationSchemeMedium(ResolutionTargetNotificationSchemeMedium);

            if (ResolutionTargetNotificationSchemeTop is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetNotificationSchemeTop)))
                query.SelectResolutionTargetNotificationSchemeTop(ResolutionTargetNotificationSchemeTop);

            if (ResponseTargetNotificationSchemeHigh is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetNotificationSchemeHigh)))
                query.SelectResponseTargetNotificationSchemeHigh(ResponseTargetNotificationSchemeHigh);

            if (ResponseTargetNotificationSchemeLow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetNotificationSchemeLow)))
                query.SelectResponseTargetNotificationSchemeLow(ResponseTargetNotificationSchemeLow);

            if (ResponseTargetNotificationSchemeMedium is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetNotificationSchemeMedium)))
                query.SelectResponseTargetNotificationSchemeMedium(ResponseTargetNotificationSchemeMedium);

            if (ResponseTargetNotificationSchemeTop is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetNotificationSchemeTop)))
                query.SelectResponseTargetNotificationSchemeTop(ResponseTargetNotificationSchemeTop);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (ServiceHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceHours)))
                query.SelectServiceHours(ServiceHours);

            if (ServiceLevelAgreements is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceLevelAgreements)))
                query.SelectServiceLevelAgreements(ServiceLevelAgreements);

            if (ShopArticles is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ShopArticles)))
                query.SelectShopArticles(ShopArticles);

            if (StandardServiceRequests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(StandardServiceRequests)))
                query.SelectStandardServiceRequests(StandardServiceRequests);

            if (SummaryAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SummaryAttachments)))
                query.SelectSummaryAttachments(SummaryAttachments);

            if (SupportHoursCase is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursCase)))
                query.SelectSupportHoursCase(SupportHoursCase);

            if (SupportHoursHigh is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursHigh)))
                query.SelectSupportHoursHigh(SupportHoursHigh);

            if (SupportHoursLow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursLow)))
                query.SelectSupportHoursLow(SupportHoursLow);

            if (SupportHoursMedium is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursMedium)))
                query.SelectSupportHoursMedium(SupportHoursMedium);

            if (SupportHoursRfc is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursRfc)))
                query.SelectSupportHoursRfc(SupportHoursRfc);

            if (SupportHoursRfi is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursRfi)))
                query.SelectSupportHoursRfi(SupportHoursRfi);

            if (SupportHoursTop is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursTop)))
                query.SelectSupportHoursTop(SupportHoursTop);

            if (TerminationAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TerminationAttachments)))
                query.SelectTerminationAttachments(TerminationAttachments);

            if (WaitingForCustomerFollowUp is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WaitingForCustomerFollowUp)))
                query.SelectWaitingForCustomerFollowUp(WaitingForCustomerFollowUp);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ServiceOfferingFilterField> filter in Filters)
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
