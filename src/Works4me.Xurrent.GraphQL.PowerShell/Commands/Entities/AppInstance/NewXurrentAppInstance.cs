using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AppInstance"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="AppInstanceCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="AppInstanceCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAppInstance")]
    [OutputType(typeof(AppInstanceCreatePayload))]
    public class NewXurrentAppInstance : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the app offering to create an instance of.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AppOfferingId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the account this app instance is for.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerAccountId { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the contact person of customer regarding this app instance.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? CustomerRepresentativeId { get; set; }

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
        /// Whether the app instance is currently enabled for this customer.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Whether the customer has enabled this app instance.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public bool? EnabledByCustomer { get; set; }

        /// <summary>
        /// Whether the app instance is currently suspended for this customer.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public bool? Suspended { get; set; }

        /// <summary>
        /// Extra information why the app instance is currently suspended for this customer.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? SuspensionComment { get; set; }

        /// <summary>
        /// Specifies the <see cref="AppInstanceQuery"/> that defines which fields of the <see cref="AppInstanceCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public AppInstanceQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="AppInstanceCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="AppInstanceCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppInstanceCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AppOfferingId)))
                input.AppOfferingId = AppOfferingId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerAccountId)))
                input.CustomerAccountId = CustomerAccountId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerRepresentativeId)))
                input.CustomerRepresentativeId = CustomerRepresentativeId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EnabledByCustomer)))
                input.EnabledByCustomer = EnabledByCustomer;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Suspended)))
                input.Suspended = Suspended;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SuspensionComment)))
                input.SuspensionComment = SuspensionComment;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AppInstanceCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAppInstance), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAppInstance), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
