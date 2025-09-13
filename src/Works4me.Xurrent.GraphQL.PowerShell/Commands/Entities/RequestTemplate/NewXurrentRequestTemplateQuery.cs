using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RequestTemplateQuery"/> object for building Xurrent <see cref="RequestTemplate"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="RequestTemplate"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRequestTemplateQuery")]
    [OutputType(typeof(RequestTemplateQuery))]
    public class NewXurrentRequestTemplateQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="RequestTemplate"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="RequestTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateField[] Properties { get; set; } = Array.Empty<RequestTemplateField>();

        /// <summary>
        /// Filters the query to return only the <see cref="RequestTemplate"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="RequestTemplate"/> view for the <see cref="RequestTemplateQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="RequestTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="RequestTemplate"/> results in the <see cref="RequestTemplateQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="RequestTemplate"/> results.<br/>
        /// If omitted, the <see cref="RequestTemplateQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="RequestTemplate"/> items returned per request in the <see cref="RequestTemplateQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRules { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InstructionsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Member { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? NoteAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organizations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? RegistrationHintsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Requests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReservationOfferingQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="ReservationOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOfferingQuery? ReservationOfferings { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="StandardServiceRequestQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="StandardServiceRequest"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery? StandardServiceRequests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Supplier { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHours { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? WorkflowManager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplateQuery"/> in the <see cref="RequestTemplateQuery"/>, allowing related <see cref="WorkflowTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery? WorkflowTemplate { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{RequestTemplateFilterField}"/> conditions to the <see cref="RequestTemplateQuery"/>.<br/>
        /// Filters restrict which <see cref="RequestTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<RequestTemplateFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="RequestTemplateQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="RequestTemplate"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RequestTemplateQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RequestTemplateQuery query = new();

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

            if (AutomationRules is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRules)))
                query.SelectAutomationRules(AutomationRules);

            if (ConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItem)))
                query.SelectConfigurationItem(ConfigurationItem);

            if (EffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClass)))
                query.SelectEffortClass(EffortClass);

            if (InstructionsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InstructionsAttachments)))
                query.SelectInstructionsAttachments(InstructionsAttachments);

            if (Member is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Member)))
                query.SelectMember(Member);

            if (NoteAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(NoteAttachments)))
                query.SelectNoteAttachments(NoteAttachments);

            if (Organizations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organizations)))
                query.SelectOrganizations(Organizations);

            if (RegistrationHintsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RegistrationHintsAttachments)))
                query.SelectRegistrationHintsAttachments(RegistrationHintsAttachments);

            if (Requests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Requests)))
                query.SelectRequests(Requests);

            if (ReservationOfferings is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ReservationOfferings)))
                query.SelectReservationOfferings(ReservationOfferings);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (StandardServiceRequests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(StandardServiceRequests)))
                query.SelectStandardServiceRequests(StandardServiceRequests);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                query.SelectSupplier(Supplier);

            if (SupportHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHours)))
                query.SelectSupportHours(SupportHours);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            if (WorkflowManager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManager)))
                query.SelectWorkflowManager(WorkflowManager);

            if (WorkflowTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplate)))
                query.SelectWorkflowTemplate(WorkflowTemplate);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<RequestTemplateFilterField> filter in Filters)
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
