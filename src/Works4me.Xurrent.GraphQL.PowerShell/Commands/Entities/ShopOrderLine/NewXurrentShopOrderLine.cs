using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ShopOrderLine"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ShopOrderLineCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ShopOrderLineCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentShopOrderLine")]
    [OutputType(typeof(ShopOrderLineCreatePayload))]
    public class NewXurrentShopOrderLine : XurrentCmdletBase
    {
        /// <summary>
        /// The number units ordered.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long Quantity { get; set; } = 0;

        /// <summary>
        /// The person for whom the shop order line was submitted.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RequestedForId { get; set; } = string.Empty;

        /// <summary>
        /// The shop article that is ordered.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShopArticleId { get; set; } = string.Empty;

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
        /// New or updated addresses of the shop order line.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public AddressInput[]? NewAddresses { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="ShopOrderLineQuery"/> that defines which fields of the <see cref="ShopOrderLineCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public ShopOrderLineQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ShopOrderLineCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ShopOrderLineCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ShopOrderLineCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                input.Quantity = Quantity;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestedForId)))
                input.RequestedForId = RequestedForId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ShopArticleId)))
                input.ShopArticleId = ShopArticleId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAddresses)))
                input.NewAddresses = NewAddresses is null ? new() : new(NewAddresses);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ShopOrderLineCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShopOrderLine), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShopOrderLine), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
