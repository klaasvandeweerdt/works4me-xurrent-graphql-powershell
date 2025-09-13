using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ConfigurationItemQuery"/> object for building Xurrent <see cref="ConfigurationItem"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ConfigurationItem"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentConfigurationItemQuery")]
    [OutputType(typeof(ConfigurationItemQuery))]
    public class NewXurrentConfigurationItemQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ConfigurationItem"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ConfigurationItem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemField[] Properties { get; set; } = Array.Empty<ConfigurationItemField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ConfigurationItem"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ConfigurationItem"/> view for the <see cref="ConfigurationItemQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ConfigurationItem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ConfigurationItem"/> results in the <see cref="ConfigurationItemQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ConfigurationItem"/> results.<br/>
        /// If omitted, the <see cref="ConfigurationItemQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ConfigurationItem"/> items returned per request in the <see cref="ConfigurationItemQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemRelationQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="ConfigurationItemRelation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemRelationQuery? CiRelations { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ContractQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Contract"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContractQuery? Contracts { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? FinancialOwner { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InvoiceQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Invoice"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery? Invoices { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Site"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? LicensedSites { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? OperatingSystem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Problem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? Problems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProductQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Product"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductQuery? Product { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RecurrenceQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Recurrence"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RecurrenceQuery? Recurrence { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? RemarksAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Request"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? Requests { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstances { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Site"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? Site { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Supplier { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? SupportAccount { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? SupportTeam { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Users { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? WorkflowManager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTemplateQuery"/> in the <see cref="ConfigurationItemQuery"/>, allowing related <see cref="WorkflowTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery? WorkflowTemplate { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ConfigurationItemFilterField}"/> conditions to the <see cref="ConfigurationItemQuery"/>.<br/>
        /// Filters restrict which <see cref="ConfigurationItem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ConfigurationItemFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ConfigurationItemQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ConfigurationItem"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="ConfigurationItem"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/configurationitemcustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ConfigurationItemQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ConfigurationItemQuery query = new();

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

            if (CiRelations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CiRelations)))
                query.SelectCiRelations(CiRelations);

            if (Contracts is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Contracts)))
                query.SelectContracts(Contracts);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (FinancialOwner is not null && MyInvocation.BoundParameters.ContainsKey(nameof(FinancialOwner)))
                query.SelectFinancialOwner(FinancialOwner);

            if (Invoices is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Invoices)))
                query.SelectInvoices(Invoices);

            if (LicensedSites is not null && MyInvocation.BoundParameters.ContainsKey(nameof(LicensedSites)))
                query.SelectLicensedSites(LicensedSites);

            if (OperatingSystem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OperatingSystem)))
                query.SelectOperatingSystem(OperatingSystem);

            if (Problems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Problems)))
                query.SelectProblems(Problems);

            if (Product is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Product)))
                query.SelectProduct(Product);

            if (Recurrence is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Recurrence)))
                query.SelectRecurrence(Recurrence);

            if (RemarksAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                query.SelectRemarksAttachments(RemarksAttachments);

            if (Requests is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Requests)))
                query.SelectRequests(Requests);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (ServiceInstances is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstances)))
                query.SelectServiceInstances(ServiceInstances);

            if (Site is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Site)))
                query.SelectSite(Site);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                query.SelectSupplier(Supplier);

            if (SupportAccount is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportAccount)))
                query.SelectSupportAccount(SupportAccount);

            if (SupportTeam is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportTeam)))
                query.SelectSupportTeam(SupportTeam);

            if (Users is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Users)))
                query.SelectUsers(Users);

            if (WorkflowManager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManager)))
                query.SelectWorkflowManager(WorkflowManager);

            if (WorkflowTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplate)))
                query.SelectWorkflowTemplate(WorkflowTemplate);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ConfigurationItemFilterField> filter in Filters)
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
