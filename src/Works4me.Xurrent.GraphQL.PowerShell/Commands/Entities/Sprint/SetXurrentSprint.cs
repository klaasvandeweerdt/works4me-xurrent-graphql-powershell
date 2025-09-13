using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="Sprint"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="SprintUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="SprintUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentSprint")]
    [OutputType(typeof(SprintUpdatePayload))]
    public class SetXurrentSprint : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
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
        /// Description of this sprint (e.g. goal of the sprint).
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? DescriptionAttachments { get; set; }

        /// <summary>
        /// The date and time the sprint ended, or will end.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Sprint backlog items of this sprint.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public SprintBacklogItemInput[]? NewSprintBacklogItems { get; set; }

        /// <summary>
        /// Sequence number of this sprint.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public long? Number { get; set; }

        /// <summary>
        /// Identifier of scrum workspace this sprint belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? ScrumWorkspaceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifiers of sprint backlog items to remove from the sprint.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string[]? SprintBacklogItemsToDelete { get; set; }

        /// <summary>
        /// The date and time the sprint started, or will start.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The current status of the sprint.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public SprintStatus? Status { get; set; }

        /// <summary>
        /// Specifies the <see cref="SprintQuery"/> that defines which fields of the <see cref="SprintUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public SprintQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="SprintUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="SprintUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SprintUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                input.DescriptionAttachments = DescriptionAttachments is null ? new() : new(DescriptionAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndAt)))
                input.EndAt = EndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewSprintBacklogItems)))
                input.NewSprintBacklogItems = NewSprintBacklogItems is null ? new() : new(NewSprintBacklogItems);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Number)))
                input.Number = Number;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ScrumWorkspaceId)))
                input.ScrumWorkspaceId = ScrumWorkspaceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SprintBacklogItemsToDelete)))
                input.SprintBacklogItemsToDelete = SprintBacklogItemsToDelete is null ? new() : new(SprintBacklogItemsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                SprintUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentSprint), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentSprint), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
