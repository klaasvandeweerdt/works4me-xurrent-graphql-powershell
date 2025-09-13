using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="ProjectTask"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ProjectTaskUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ProjectTaskUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentProjectTask")]
    [OutputType(typeof(ProjectTaskUpdatePayload))]
    public class SetXurrentProjectTask : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// ID of the column this item is placed in.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardColumnId { get; set; }

        /// <summary>
        /// The (one based) position of this item in its column.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public long? AgileBoardColumnPosition { get; set; }

        /// <summary>
        /// ID of the board this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// Automatically set to the current date and time when the project task is assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public DateTime? AssignedAt { get; set; }

        /// <summary>
        /// Identifiers of assignments to remove from the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string[]? AssignmentsToDelete { get; set; }

        /// <summary>
        /// The category of the project task. Activity tasks are used to assign project-related work to people. Approval tasks are used to collect approvals for projects. Milestones are used to mark specific points along a project's implementation plan.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// The date and time at which the milestone needs to have been reached.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// Used to provide instructions for the person(s) to whom the project task will be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// Assignments of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskAssignmentInput[]? NewAssignments { get; set; }

        /// <summary>
        /// Used to provide information for the person to whom the project task is assigned. It is also used to provide a summary of the actions that have been taken to date and the results of these actions.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifier of the PDF design to link to the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// Identifier of the phase of the project to which the project task belongs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? PhaseId { get; set; }

        /// <summary>
        /// The number of minutes it is expected to take for the project task to be completed following its assignment, or following its fixed start date and time if the Start no earlier than field is filled out.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public long? PlannedDuration { get; set; }

        /// <summary>
        /// The number of minutes the team is expected to spend working on the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// Identifiers of the predecessors of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string[]? PredecessorIds { get; set; }

        /// <summary>
        /// The number of assignees who need to have provided their approval before the status of the project task gets updated to "Approved".
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Skill pool that represents the specific expertise needed to complete the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? SkillPoolId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Only used when work on the project task may not start before a specific date and time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The current status of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskStatus? Status { get; set; }

        /// <summary>
        /// A short description of the objective of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifiers of the successors of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string[]? SuccessorIds { get; set; }

        /// <summary>
        /// The supplier organization that has been asked to assist with the completion of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request to help with the execution of the project task has been registered at the supplier organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// The team to which the project task is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The project task template that was used to register the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// The justification of the time spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? TimeEntryDescription { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// Whether the project task is urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// The date and time at which the status of the project task is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// When set to true, the completion target of the project task is calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public bool? WorkHoursAre24x7 { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProjectTaskQuery"/> that defines which fields of the <see cref="ProjectTaskUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ProjectTaskUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ProjectTaskUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectTaskUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnId)))
                input.AgileBoardColumnId = AgileBoardColumnId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnPosition)))
                input.AgileBoardColumnPosition = AgileBoardColumnPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardId)))
                input.AgileBoardId = AgileBoardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignedAt)))
                input.AssignedAt = AssignedAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentsToDelete)))
                input.AssignmentsToDelete = AssignmentsToDelete is null ? new() : new(AssignmentsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Deadline)))
                input.Deadline = Deadline;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Instructions)))
                input.Instructions = Instructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAssignments)))
                input.NewAssignments = NewAssignments is null ? new() : new(NewAssignments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PdfDesignId)))
                input.PdfDesignId = PdfDesignId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PhaseId)))
                input.PhaseId = PhaseId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedDuration)))
                input.PlannedDuration = PlannedDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffort)))
                input.PlannedEffort = PlannedEffort;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PredecessorIds)))
                input.PredecessorIds = PredecessorIds is null ? new() : new(PredecessorIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequiredApprovals)))
                input.RequiredApprovals = RequiredApprovals;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SkillPoolId)))
                input.SkillPoolId = SkillPoolId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SuccessorIds)))
                input.SuccessorIds = SuccessorIds is null ? new() : new(SuccessorIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierRequestID)))
                input.SupplierRequestID = SupplierRequestID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.TeamId = TeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TemplateId)))
                input.TemplateId = TemplateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeEntryDescription)))
                input.TimeEntryDescription = TimeEntryDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeSpent)))
                input.TimeSpent = TimeSpent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeSpentEffortClassId)))
                input.TimeSpentEffortClassId = TimeSpentEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Urgent)))
                input.Urgent = Urgent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WaitingUntil)))
                input.WaitingUntil = WaitingUntil;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkHoursAre24x7)))
                input.WorkHoursAre24x7 = WorkHoursAre24x7;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ProjectTaskUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentProjectTask), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentProjectTask), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
