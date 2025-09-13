using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Deletes an existing <see cref="AppOfferingAutomationRule"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="AppOfferingAutomationRuleDeleteMutationInput"/> from the provided parameters, executes the operation, and returns a <see cref="AppOfferingAutomationRuleDeleteMutationPayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "XurrentAppOfferingAutomationRule")]
    [OutputType(typeof(AppOfferingAutomationRuleDeleteMutationPayload))]
    public class RemoveXurrentAppOfferingAutomationRule : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to delete.
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
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="AppOfferingAutomationRuleDeleteMutationInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="AppOfferingAutomationRuleDeleteMutationPayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingAutomationRuleDeleteMutationInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AppOfferingAutomationRuleDeleteMutationPayload result = client.Client.MutationAsync(input).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(RemoveXurrentAppOfferingAutomationRule), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(RemoveXurrentAppOfferingAutomationRule), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
