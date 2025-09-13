using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="PersonQuery"/> object for building Xurrent <see cref="Person"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="Person"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentPersonQuery")]
    [OutputType(typeof(PersonQuery))]
    public class NewXurrentPersonQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Person"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Person"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonField[] Properties { get; set; } = Array.Empty<PersonField>();

        /// <summary>
        /// Filters the query to return only the <see cref="Person"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="Person"/> view for the <see cref="PersonQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="Person"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="Person"/> results in the <see cref="PersonQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="Person"/> results.<br/>
        /// If omitted, the <see cref="PersonQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="Person"/> items returned per request in the <see cref="PersonQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AddressQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Address"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AddressQuery? Addresses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="ShopOrderLine"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? Cart { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ContactQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Contact"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContactQuery? Contacts { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InformationAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Manager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organization { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OutOfOfficePeriodQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="OutOfOfficePeriod"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OutOfOfficePeriodQuery? OutOfOfficePeriods { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PermissionQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Permission"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PermissionQuery? Permissions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Site"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? Site { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SkillPoolQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="SkillPool"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery? SkillPools { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Teams { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="PersonQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? WorkHours { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{PersonFilterField}"/> conditions to the <see cref="PersonQuery"/>.<br/>
        /// Filters restrict which <see cref="Person"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<PersonFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="PersonQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="Person"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Filters the <see cref="Person"/> by custom fields marked as "Filterable" in their UI Extension.<br/>
        /// See the <see href="https://developer.xurrent.com/graphql/input_object/personcustomfilter/">Xurrent developer</see> site for details.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[]? CustomFilters { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="PersonQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            PersonQuery query = new();

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

            if (Cart is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Cart)))
                query.SelectCart(Cart);

            if (ConfigurationItems is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItems)))
                query.SelectConfigurationItems(ConfigurationItems);

            if (Contacts is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Contacts)))
                query.SelectContacts(Contacts);

            if (CustomFields is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                query.SelectCustomFields(CustomFields);

            if (CustomFieldsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                query.SelectCustomFieldsAttachments(CustomFieldsAttachments);

            if (InformationAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InformationAttachments)))
                query.SelectInformationAttachments(InformationAttachments);

            if (Manager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                query.SelectManager(Manager);

            if (Organization is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organization)))
                query.SelectOrganization(Organization);

            if (OutOfOfficePeriods is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OutOfOfficePeriods)))
                query.SelectOutOfOfficePeriods(OutOfOfficePeriods);

            if (Permissions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Permissions)))
                query.SelectPermissions(Permissions);

            if (Site is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Site)))
                query.SelectSite(Site);

            if (SkillPools is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SkillPools)))
                query.SelectSkillPools(SkillPools);

            if (Teams is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Teams)))
                query.SelectTeams(Teams);

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            if (WorkHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkHours)))
                query.SelectWorkHours(WorkHours);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<PersonFilterField> filter in Filters)
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
