using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TimeEntry"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="TimeEntryCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="TimeEntryCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTimeEntry")]
    [OutputType(typeof(TimeEntryCreatePayload))]
    public class NewXurrentTimeEntry : XurrentCmdletBase
    {
        /// <summary>
        /// The number of minutes that was spent on the selected time allocation. The number of minutes is allowed to be negative only when the correction field is set to true.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long TimeSpent { get; set; } = 0;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the time entry should be considered a correction for a time entry that was registered for a date that has already been locked.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? Correction { get; set; }

        /// <summary>
        /// Identifier of the organization for which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? CustomerId { get; set; }

        /// <summary>
        /// The date on which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? Date { get; set; }
#else
                public DateTime? Date { get; set; }
#endif

        /// <summary>
        /// Automatically checked after the time entry has been deleted. The data of a deleted time entry that is older than 3 months can no longer be retrieved.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// A short description of the time spent. This field is available and required only when the Description required box is checked in the selected time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Identifier of the effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// Identifier of the note the time entry is linked to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? NoteId { get; set; }

        /// <summary>
        /// Identifier of the organization to which the person was linked when the time entry was created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Identifier of the person who spent the time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? PersonId { get; set; }

        /// <summary>
        /// Identifier of the service for which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The start time of the work.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Identifier of the team the person of the time entry was a member of while the work was performed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// Identifier of the time allocation on which the time was spent. Only the time allocations that are linked to the person’s organization can be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="TimeEntryQuery"/> that defines which fields of the <see cref="TimeEntryCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public TimeEntryQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="TimeEntryCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="TimeEntryCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TimeEntryCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeSpent)))
                input.TimeSpent = TimeSpent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Correction)))
                input.Correction = Correction;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerId)))
                input.CustomerId = CustomerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Date)))
                input.Date = Date;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Deleted)))
                input.Deleted = Deleted;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassId)))
                input.EffortClassId = EffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoteId)))
                input.NoteId = NoteId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrganizationId)))
                input.OrganizationId = OrganizationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PersonId)))
                input.PersonId = PersonId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartedAt)))
                input.StartedAt = StartedAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.TeamId = TeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocationId)))
                input.TimeAllocationId = TimeAllocationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                TimeEntryCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTimeEntry), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTimeEntry), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
