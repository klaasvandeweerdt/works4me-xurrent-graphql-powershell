using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Product"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ProductCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ProductCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProduct")]
    [OutputType(typeof(ProductCreatePayload))]
    public class NewXurrentProduct : XurrentCmdletBase
    {
        /// <summary>
        /// The brand name is typically the name of the product's manufacturer.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// The appropriate product category for the product.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The name of the product. Fill out the Brand, Model, Product ID (optional) and Category fields to automatically generate a name based on the values entered in these fields.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

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
        /// Used to specify whether or not configuration items that are based on the product are typically depreciated and if so, which depreciation method is normally applied. Valid values are:<br/>
        /// • not_depreciated: Not Depreciated.<br/>
        /// • double_declining_balance: Double Declining Balance.<br/>
        /// • reducing_balance: Reducing Balance (or Diminishing Value).<br/>
        /// • straight_line: Straight Line (or Prime Cost).<br/>
        /// • sum_of_the_years_digits: Sum of the Year's Digits.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public ProductDepreciationMethod? DepreciationMethod { get; set; }

        /// <summary>
        /// Whether the product may no longer be used to register new configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Identifier of the internal organization which budget is normally used to obtain the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? FinancialOwnerId { get; set; }

        /// <summary>
        /// The model of the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? Model { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// The unique identifier of the product that is used by the manufacturer. The concatenation of brand and productID must be unique within a Xurrent account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? ProductID { get; set; }

        /// <summary>
        /// The yearly rate that should normally be applied to calculate the depreciation of configuration items that are based on the product using the reducing balance (or diminishing value) method.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public long? Rate { get; set; }

        /// <summary>
        /// Recurrence for maintenance of configuration items created from the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public RecurrenceInput? Recurrence { get; set; }

        /// <summary>
        /// Any additional information about the product that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// The value of this configuration item at the end of its useful life (i.e. at the end of its depreciation period). When a value is not specified for this field, it is set to zero.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public decimal? SalvageValue { get; set; }

        /// <summary>
        /// The currency of the salvage value attributed to this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public Currency? SalvageValueCurrency { get; set; }

        /// <summary>
        /// Identifier of the Service which Service Instances would typically include the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the organization from which the product is typically obtained. If the product is developed internally, select the internal organization that develops it. Note that a lease company should be selected in this field if the product is normally leased.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team responsible for maintaining the product's information in the configuration management database (CMDB).
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? SupportTeamId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The number of years within which configuration items that are based on the product are typically depreciated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public long? UsefulLife { get; set; }

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// The workflow template that is used to periodically maintain configuration items created from the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProductQuery"/> that defines which fields of the <see cref="ProductCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public ProductQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ProductCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ProductCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProductCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Brand)))
                input.Brand = Brand;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DepreciationMethod)))
                input.DepreciationMethod = DepreciationMethod;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FinancialOwnerId)))
                input.FinancialOwnerId = FinancialOwnerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
                input.Model = Model;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductID)))
                input.ProductID = ProductID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Rate)))
                input.Rate = Rate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Recurrence)))
                input.Recurrence = Recurrence;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SalvageValue)))
                input.SalvageValue = SalvageValue;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SalvageValueCurrency)))
                input.SalvageValueCurrency = SalvageValueCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportTeamId)))
                input.SupportTeamId = SupportTeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UsefulLife)))
                input.UsefulLife = UsefulLife;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManagerId)))
                input.WorkflowManagerId = WorkflowManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplateId)))
                input.WorkflowTemplateId = WorkflowTemplateId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ProductCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProduct), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProduct), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
