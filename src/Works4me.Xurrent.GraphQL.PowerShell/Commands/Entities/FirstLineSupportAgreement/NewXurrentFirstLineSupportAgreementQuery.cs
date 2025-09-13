using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="FirstLineSupportAgreementQuery"/> object for building Xurrent <see cref="FirstLineSupportAgreement"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="FirstLineSupportAgreement"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentFirstLineSupportAgreementQuery")]
    [OutputType(typeof(FirstLineSupportAgreementQuery))]
    public class NewXurrentFirstLineSupportAgreementQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="FirstLineSupportAgreement"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="FirstLineSupportAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementField[] Properties { get; set; } = Array.Empty<FirstLineSupportAgreementField>();

        /// <summary>
        /// Filters the query to return only the <see cref="FirstLineSupportAgreement"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="FirstLineSupportAgreement"/> view for the <see cref="FirstLineSupportAgreementQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="FirstLineSupportAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="FirstLineSupportAgreement"/> results in the <see cref="FirstLineSupportAgreementQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="FirstLineSupportAgreement"/> results.<br/>
        /// If omitted, the <see cref="FirstLineSupportAgreementQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="FirstLineSupportAgreement"/> items returned per request in the <see cref="FirstLineSupportAgreementQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? ChargesAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Customer { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? CustomerAccount { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? CustomerRepresentative { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InvoiceQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Invoice"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery? Invoices { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? MajorIncidentManagers { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Provider { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? RemarksAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? ServiceDeskTeam { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHours { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="FirstLineSupportAgreementQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? TargetDetailsAttachments { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{FirstLineSupportAgreementFilterField}"/> conditions to the <see cref="FirstLineSupportAgreementQuery"/>.<br/>
        /// Filters restrict which <see cref="FirstLineSupportAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<FirstLineSupportAgreementFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="FirstLineSupportAgreementQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="FirstLineSupportAgreement"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="FirstLineSupportAgreementQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            FirstLineSupportAgreementQuery query = new();

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

            if (Customer is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Customer)))
                query.SelectCustomer(Customer);

            if (CustomerAccount is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomerAccount)))
                query.SelectCustomerAccount(CustomerAccount);

            if (CustomerRepresentative is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomerRepresentative)))
                query.SelectCustomerRepresentative(CustomerRepresentative);

            if (Invoices is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Invoices)))
                query.SelectInvoices(Invoices);

            if (MajorIncidentManagers is not null && MyInvocation.BoundParameters.ContainsKey(nameof(MajorIncidentManagers)))
                query.SelectMajorIncidentManagers(MajorIncidentManagers);

            if (Provider is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Provider)))
                query.SelectProvider(Provider);

            if (RemarksAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                query.SelectRemarksAttachments(RemarksAttachments);

            if (ServiceDeskTeam is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceDeskTeam)))
                query.SelectServiceDeskTeam(ServiceDeskTeam);

            if (SupportHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHours)))
                query.SelectSupportHours(SupportHours);

            if (TargetDetailsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TargetDetailsAttachments)))
                query.SelectTargetDetailsAttachments(TargetDetailsAttachments);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<FirstLineSupportAgreementFilterField> filter in Filters)
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
