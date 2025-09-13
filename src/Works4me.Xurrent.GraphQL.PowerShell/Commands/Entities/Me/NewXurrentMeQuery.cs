using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="MeQuery"/> object for building Xurrent <see cref="Person"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Person"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentMeQuery")]
    [OutputType(typeof(MeQuery))]
    public class NewXurrentMeQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Person"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Person"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonField[] Properties { get; set; } = Array.Empty<PersonField>();

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AddressQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Address"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AddressQuery? Addresses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ShopOrderLineQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="ShopOrderLine"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery? Cart { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItems { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ContactQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Contact"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContactQuery? Contacts { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CustomFieldQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="CustomField"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery? CustomFields { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InformationAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Manager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organization { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OutOfOfficePeriodQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="OutOfOfficePeriod"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OutOfOfficePeriodQuery? OutOfOfficePeriods { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PermissionQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Permission"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PermissionQuery? Permissions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SiteQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Site"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery? Site { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SkillPoolQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="SkillPool"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery? SkillPools { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Teams { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="MeQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? WorkHours { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="MeQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            MeQuery query = new();

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

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
