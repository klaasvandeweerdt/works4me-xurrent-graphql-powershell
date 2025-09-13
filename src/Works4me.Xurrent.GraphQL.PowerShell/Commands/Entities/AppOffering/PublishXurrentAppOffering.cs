using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Publishes the <see cref="AppOffering"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="AppOfferingPublishMutationInput"/> from the provided parameters, executes the operation, and returns a <see cref="AppOfferingPublishMutationPayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet("Publish", "XurrentAppOffering")]
    [OutputType(typeof(AppOfferingPublishMutationPayload))]
    public class PublishXurrentAppOffering : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the draft app offering that should be copied to created a new published app offering version.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="AppOfferingQuery"/> that defines which fields of the <see cref="AppOfferingPublishMutationPayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public AppOfferingQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="AppOfferingPublishMutationInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="AppOfferingPublishMutationPayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingPublishMutationInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AppOfferingPublishMutationPayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(PublishXurrentAppOffering), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(PublishXurrentAppOffering), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
