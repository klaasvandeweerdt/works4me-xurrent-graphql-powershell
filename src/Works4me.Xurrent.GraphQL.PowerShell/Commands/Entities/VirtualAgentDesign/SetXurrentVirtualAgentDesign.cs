using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="VirtualAgentDesign"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="VirtualAgentDesignUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="VirtualAgentDesignUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentVirtualAgentDesign")]
    [OutputType(typeof(VirtualAgentDesignUpdatePayload))]
    public class SetXurrentVirtualAgentDesign : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Instructions for the virtual agent in markdown format.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? AgentInstructions { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="VirtualAgentDesignQuery"/> that defines which fields of the <see cref="VirtualAgentDesignUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public VirtualAgentDesignQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="VirtualAgentDesignUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="VirtualAgentDesignUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            VirtualAgentDesignUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgentInstructions)))
                input.AgentInstructions = AgentInstructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                VirtualAgentDesignUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentVirtualAgentDesign), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentVirtualAgentDesign), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
