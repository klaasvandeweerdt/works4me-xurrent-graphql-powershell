using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="ConfigurationItem"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ConfigurationItemUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ConfigurationItemUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentConfigurationItem")]
    [OutputType(typeof(ConfigurationItemUpdatePayload))]
    public class SetXurrentConfigurationItem : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Alternate names the configuration item is also known by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string[]? AlternateNames { get; set; }

        /// <summary>
        /// Asset identifier of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? AssetID { get; set; }

        /// <summary>
        /// Identifiers of relations other configuration items to remove from the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string[]? CiRelationsToDelete { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the contracts of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string[]? ContractIds { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// The date at which the support for this configuration item ends.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? EndOfSupportDate { get; set; }
#else
                public DateTime? EndOfSupportDate { get; set; }
#endif

        /// <summary>
        /// Identifier of the internal organization which budget is used to pay for the configuration item. If the CI is leased or rented, the organization that pays the lease or rent is selected in this field. When creating a new CI and a value is not specified for this field, it is set to the financial owner of the CI's product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? FinancialOwnerId { get; set; }

        /// <summary>
        /// The date on which the expense for the configuration item (CI) was incurred or, if the CI is depreciated over time, the date on which the depreciation was started. This is typically the invoice date.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? InUseSince { get; set; }
#else
                public DateTime? InUseSince { get; set; }
#endif

        /// <summary>
        /// The label that is attached to the configuration item (CI). A label is automatically generated using the same prefix of other CIs of the same product category, followed by the next available number as the suffix.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? Label { get; set; }

        /// <summary>
        /// The date and time at which the configuration item was last seen.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public DateTime? LastSeenAt { get; set; }

        /// <summary>
        /// Identifiers of the sites at which the software that is covered by the license certificate may be used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? LicensedSiteIds { get; set; }

        /// <summary>
        /// The date through which the temporary software license certificate is valid. The license certificate expires at the end of this day.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? LicenseExpiryDate { get; set; }
#else
                public DateTime? LicenseExpiryDate { get; set; }
#endif

        /// <summary>
        /// The type of license that the license certificate covers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public CiLicenseType? LicenseType { get; set; }

        /// <summary>
        /// The name or number of the room in which the CI is located, if it concerns a hardware CI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Location { get; set; }

        /// <summary>
        /// The name of the configuration item (CI). When creating a new CI and a value is not specified for this field, it is set to the name of the CI's product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Relations to other configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public CiRelationInput[]? NewCiRelations { get; set; }

        /// <summary>
        /// The total number of processor cores that are installed in the server.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public long? NrOfCores { get; set; }

        /// <summary>
        /// The number of licenses that the license certificate covers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public long? NrOfLicenses { get; set; }

        /// <summary>
        /// The number of processors that are installed in the server.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public long? NrOfProcessors { get; set; }

        /// <summary>
        /// Identifier of the (software) configuration item representing the operating system of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? OperatingSystemId { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record. This may be a 'data URL', allowing the image to be supplied directly without requiring a separate upload first.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// Identifier of the related product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? ProductId { get; set; }

        /// <summary>
        /// The amount that was paid for the configuration item (this is normally equal to the invoice amount).
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public decimal? PurchaseValue { get; set; }

        /// <summary>
        /// The currency of the purchase value attributed to this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public Currency? PurchaseValueCurrency { get; set; }

        /// <summary>
        /// The amount of RAM (in GB) of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public decimal? RamAmount { get; set; }

        /// <summary>
        /// Recurrence for maintenance of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public RecurrenceInput? Recurrence { get; set; }

        /// <summary>
        /// Any additional information about the configuration item that might prove useful. When creating a new CI and a value is not specified for this field, it is set to the remarks of the CI's product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// The Rule set field is automatically set to the rule set of product category, except when the CI is a license certificate, in which case the rule set is license_certificate.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public ProductCategoryRuleSet? RuleSet { get; set; }

        /// <summary>
        /// Serial number of the configuration item. The concatenation of product's' brand and serialNr must be unique within a Xurrent account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string? SerialNr { get; set; }

        /// <summary>
        /// Which service instance(s) the configuration item is, or will be, a part of. When creating a new CI and a value is not specified for this field, it is set to the service of the CI's product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// Identifiers of the service instances of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public string[]? ServiceInstanceIds { get; set; }

        /// <summary>
        /// Where the CI is located, if it concerns a hardware CI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public string? SiteId { get; set; }

        /// <summary>
        /// true for license certificates that may only be used at one or more specific locations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public bool? SiteLicense { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The appropriate status for the configuration item (CI).
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public CiStatus? Status { get; set; }

        /// <summary>
        /// Identifier of the supplier from which the configuration item (CI) has been obtained. When creating a new CI and a value is not specified for this field, it is set to the supplier of the CI's product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team responsible for supporting the configuration item and maintaining its information in the configuration management database (CMDB). When creating a new CI and a value is not specified for this field, it is set to the support team of the CI's product. Optional when status of CI equals "Removed", required otherwise.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipelineByPropertyName = true)]
        public string? SupportTeamId { get; set; }

        /// <summary>
        /// System identifier of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipelineByPropertyName = true)]
        public string? SystemID { get; set; }

        /// <summary>
        /// true for license certificates that are not valid indefinitely.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipelineByPropertyName = true)]
        public bool? TemporaryLicense { get; set; }

        /// <summary>
        /// Identifiers of the users of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipelineByPropertyName = true)]
        public string[]? UserIds { get; set; }

        /// <summary>
        /// The date through which the warranty coverage for the configuration item is valid. The warranty expires at the end of this day.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? WarrantyExpiryDate { get; set; }
#else
                public DateTime? WarrantyExpiryDate { get; set; }
#endif

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 46, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// The workflow template that is used to periodically maintain the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// Specifies the <see cref="ConfigurationItemQuery"/> that defines which fields of the <see cref="ConfigurationItemUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 48, ValueFromPipelineByPropertyName = true)]
        public ConfigurationItemQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 49, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ConfigurationItemUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ConfigurationItemUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ConfigurationItemUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AlternateNames)))
                input.AlternateNames = AlternateNames is null ? new() : new(AlternateNames);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssetID)))
                input.AssetID = AssetID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CiRelationsToDelete)))
                input.CiRelationsToDelete = CiRelationsToDelete is null ? new() : new(CiRelationsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ContractIds)))
                input.ContractIds = ContractIds is null ? new() : new(ContractIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndOfSupportDate)))
                input.EndOfSupportDate = EndOfSupportDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FinancialOwnerId)))
                input.FinancialOwnerId = FinancialOwnerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InUseSince)))
                input.InUseSince = InUseSince;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Label)))
                input.Label = Label;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(LastSeenAt)))
                input.LastSeenAt = LastSeenAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(LicensedSiteIds)))
                input.LicensedSiteIds = LicensedSiteIds is null ? new() : new(LicensedSiteIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(LicenseExpiryDate)))
                input.LicenseExpiryDate = LicenseExpiryDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(LicenseType)))
                input.LicenseType = LicenseType;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                input.Location = Location;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewCiRelations)))
                input.NewCiRelations = NewCiRelations is null ? new() : new(NewCiRelations);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NrOfCores)))
                input.NrOfCores = NrOfCores;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NrOfLicenses)))
                input.NrOfLicenses = NrOfLicenses;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NrOfProcessors)))
                input.NrOfProcessors = NrOfProcessors;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OperatingSystemId)))
                input.OperatingSystemId = OperatingSystemId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductId)))
                input.ProductId = ProductId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseValue)))
                input.PurchaseValue = PurchaseValue;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseValueCurrency)))
                input.PurchaseValueCurrency = PurchaseValueCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RamAmount)))
                input.RamAmount = RamAmount;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Recurrence)))
                input.Recurrence = Recurrence;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RuleSet)))
                input.RuleSet = RuleSet;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SerialNr)))
                input.SerialNr = SerialNr;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceIds)))
                input.ServiceInstanceIds = ServiceInstanceIds is null ? new() : new(ServiceInstanceIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SiteId)))
                input.SiteId = SiteId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SiteLicense)))
                input.SiteLicense = SiteLicense;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportTeamId)))
                input.SupportTeamId = SupportTeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SystemID)))
                input.SystemID = SystemID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TemporaryLicense)))
                input.TemporaryLicense = TemporaryLicense;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UserIds)))
                input.UserIds = UserIds is null ? new() : new(UserIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyExpiryDate)))
                input.WarrantyExpiryDate = WarrantyExpiryDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManagerId)))
                input.WorkflowManagerId = WorkflowManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplateId)))
                input.WorkflowTemplateId = WorkflowTemplateId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ConfigurationItemUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentConfigurationItem), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentConfigurationItem), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
