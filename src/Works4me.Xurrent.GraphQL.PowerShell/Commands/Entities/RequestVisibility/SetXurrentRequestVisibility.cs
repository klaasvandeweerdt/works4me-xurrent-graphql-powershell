using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="Request"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="RequestUpdateVisibilityInput"/> from the provided parameters, executes the operation, and returns a <see cref="RequestUpdateVisibilityPayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentRequestVisibility")]
    [OutputType(typeof(RequestUpdateVisibilityPayload))]
    public class SetXurrentRequestVisibility : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The identifier of the request account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? AccountID { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Indicates whether the request should be visible within the supplied request account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? Visible { get; set; }

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="RequestUpdateVisibilityInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="RequestUpdateVisibilityPayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RequestUpdateVisibilityInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AccountID)))
                input.AccountID = AccountID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Visible)))
                input.Visible = Visible;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                RequestUpdateVisibilityPayload result = client.Client.MutationAsync(input).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentRequestVisibility), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentRequestVisibility), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
