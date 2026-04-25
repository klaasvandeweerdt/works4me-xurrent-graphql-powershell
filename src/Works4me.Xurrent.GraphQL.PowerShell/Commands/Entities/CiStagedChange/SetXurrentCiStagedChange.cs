using System;
using System.Management.Automation;
using System.Text.Json;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="CiStagedChange"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="CiStagedChangeUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="CiStagedChangeUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentCiStagedChange")]
    [OutputType(typeof(CiStagedChangeUpdatePayload))]
    public class SetXurrentCiStagedChange : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the CI staged change to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The new status for the staged change (approved or rejected).
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CiStagedChangeStatus Status { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Optional JSON object with edited proposed values. Only used when approving. Keys must be a subset of the original proposed values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public JsonElement? ProposedValues { get; set; }

        /// <summary>
        /// Optional note from the reviewer explaining the decision.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ReviewerNote { get; set; }

        /// <summary>
        /// Specifies the <see cref="CiStagedChangeQuery"/> that defines which fields of the <see cref="CiStagedChangeUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public CiStagedChangeQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="CiStagedChangeUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="CiStagedChangeUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CiStagedChangeUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProposedValues)))
                input.ProposedValues = ProposedValues;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ReviewerNote)))
                input.ReviewerNote = ReviewerNote;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                CiStagedChangeUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentCiStagedChange), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentCiStagedChange), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
