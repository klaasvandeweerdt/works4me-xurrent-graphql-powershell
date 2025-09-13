using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Organization"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="OrganizationCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="OrganizationCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentOrganization")]
    [OutputType(typeof(OrganizationCreatePayload))]
    public class NewXurrentOrganization : XurrentCmdletBase
    {
        /// <summary>
        /// The full name of the organization.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Whether the organization needs to be treated as a separate entity from a reporting perspective. This checkbox is only available for internal organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public bool? BusinessUnit { get; set; }

        /// <summary>
        /// Refers to itself if the organization is a business unit, or refers to the business unit that the organization belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? BusinessUnitOrganizationId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Whether the organization may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Whether end users from this organization should be prevented from seeing information of other end users.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public bool? EndUserPrivacy { get; set; }

        /// <summary>
        /// The unique identifier by which the organization is known in the financial system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? FinancialID { get; set; }

        /// <summary>
        /// The manager of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// New or updated addresses of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public AddressInput[]? NewAddresses { get; set; }

        /// <summary>
        /// New or updated contacts of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public ContactInput[]? NewContacts { get; set; }

        /// <summary>
        /// The organization's parent organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? ParentId { get; set; }

        /// <summary>
        /// The external customer organizations which requests people in this organization are allowed to see. Only applicable if customer privacy is activated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? PermittedCustomerIds { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// Which region the organization belongs to. It is possible to select a previously entered region name or to enter a new one. The Region field of a business unit's child organizations cannot be modified, as it is automatically set to the same value as the Region field of the business unit.<br/>
        /// Examples of commonly used region names are:<br/>
        /// • Asia Pacific (APAC).<br/>
        /// • Europe, Middle East &amp; Africa (EMEA).<br/>
        /// • North America (NA).<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? Region { get; set; }

        /// <summary>
        /// Any additional information about the organization that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The person who acts as the substitute of the organization's manager.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? SubstituteId { get; set; }

        /// <summary>
        /// Time allocations of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string[]? TimeAllocationIds { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Specifies the <see cref="OrganizationQuery"/> that defines which fields of the <see cref="OrganizationCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public OrganizationQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="OrganizationCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="OrganizationCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            OrganizationCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(BusinessUnit)))
                input.BusinessUnit = BusinessUnit;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(BusinessUnitOrganizationId)))
                input.BusinessUnitOrganizationId = BusinessUnitOrganizationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndUserPrivacy)))
                input.EndUserPrivacy = EndUserPrivacy;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FinancialID)))
                input.FinancialID = FinancialID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ManagerId)))
                input.ManagerId = ManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAddresses)))
                input.NewAddresses = NewAddresses is null ? new() : new(NewAddresses);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewContacts)))
                input.NewContacts = NewContacts is null ? new() : new(NewContacts);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ParentId)))
                input.ParentId = ParentId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PermittedCustomerIds)))
                input.PermittedCustomerIds = PermittedCustomerIds is null ? new() : new(PermittedCustomerIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Region)))
                input.Region = Region;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SubstituteId)))
                input.SubstituteId = SubstituteId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocationIds)))
                input.TimeAllocationIds = TimeAllocationIds is null ? new() : new(TimeAllocationIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                OrganizationCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentOrganization), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentOrganization), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
