using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ServiceLevelAgreementQuery"/> object for building Xurrent <see cref="ServiceLevelAgreement"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ServiceLevelAgreement"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentServiceLevelAgreementQuery")]
    [OutputType(typeof(ServiceLevelAgreementQuery))]
    public class NewXurrentServiceLevelAgreementQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ServiceLevelAgreement"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ServiceLevelAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementField[] Properties { get; set; } = Array.Empty<ServiceLevelAgreementField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ServiceLevelAgreement"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ServiceLevelAgreement"/> view for the <see cref="ServiceLevelAgreementQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ServiceLevelAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ServiceLevelAgreement"/> results in the <see cref="ServiceLevelAgreementQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ServiceLevelAgreement"/> results.<br/>
        /// If omitted, the <see cref="ServiceLevelAgreementQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ServiceLevelAgreement"/> items returned per request in the <see cref="ServiceLevelAgreementQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ActivityIDQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="ActivityID"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ActivityIDQuery? ActivityID { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaCoverageGroupQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="SlaCoverageGroup"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaCoverageGroupQuery? CoverageGroups { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Customer { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? CustomerAccount { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? CustomerRepresentatives { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassRateIDQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="EffortClassRateID"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateIDQuery? EffortClassRateIDs { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InvoiceQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Invoice"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery? Invoices { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organizations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? People { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? RemarksAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ParentServiceInstanceQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="ParentServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ParentServiceInstanceQuery? ServiceInstances { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? ServiceLevelManager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceOfferingQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="ServiceOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery? ServiceOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Site"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? Sites { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SkillPoolQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="SkillPool"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery? SkillPools { get; set; }

        /// <summary>
        /// Includes a nested <see cref="StandardServiceRequestActivityIDQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="StandardServiceRequestActivityID"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestActivityIDQuery? StandardServiceRequestActivityIDs { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ServiceLevelAgreementQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? SupportDomain { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ServiceLevelAgreementFilterField}"/> conditions to the <see cref="ServiceLevelAgreementQuery"/>.<br/>
        /// Filters restrict which <see cref="ServiceLevelAgreement"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ServiceLevelAgreementFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ServiceLevelAgreementQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ServiceLevelAgreement"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ServiceLevelAgreementQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ServiceLevelAgreementQuery query = new();

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

            if (ActivityID is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ActivityID)))
                query.SelectActivityID(ActivityID);

            if (CoverageGroups is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CoverageGroups)))
                query.SelectCoverageGroups(CoverageGroups);

            if (Customer is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Customer)))
                query.SelectCustomer(Customer);

            if (CustomerAccount is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomerAccount)))
                query.SelectCustomerAccount(CustomerAccount);

            if (CustomerRepresentatives is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomerRepresentatives)))
                query.SelectCustomerRepresentatives(CustomerRepresentatives);

            if (EffortClassRateIDs is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassRateIDs)))
                query.SelectEffortClassRateIDs(EffortClassRateIDs);

            if (Invoices is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Invoices)))
                query.SelectInvoices(Invoices);

            if (Organizations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organizations)))
                query.SelectOrganizations(Organizations);

            if (People is not null && MyInvocation.BoundParameters.ContainsKey(nameof(People)))
                query.SelectPeople(People);

            if (RemarksAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                query.SelectRemarksAttachments(RemarksAttachments);

            if (ServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstance)))
                query.SelectServiceInstance(ServiceInstance);

            if (ServiceInstances is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstances)))
                query.SelectServiceInstances(ServiceInstances);

            if (ServiceLevelManager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceLevelManager)))
                query.SelectServiceLevelManager(ServiceLevelManager);

            if (ServiceOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceOffering)))
                query.SelectServiceOffering(ServiceOffering);

            if (Sites is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Sites)))
                query.SelectSites(Sites);

            if (SkillPools is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SkillPools)))
                query.SelectSkillPools(SkillPools);

            if (StandardServiceRequestActivityIDs is not null && MyInvocation.BoundParameters.ContainsKey(nameof(StandardServiceRequestActivityIDs)))
                query.SelectStandardServiceRequestActivityIDs(StandardServiceRequestActivityIDs);

            if (SupportDomain is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportDomain)))
                query.SelectSupportDomain(SupportDomain);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ServiceLevelAgreementFilterField> filter in Filters)
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
