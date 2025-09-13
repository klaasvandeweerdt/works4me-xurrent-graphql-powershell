using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WorkflowTask"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="WorkflowTaskCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="WorkflowTaskCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWorkflowTask")]
    [OutputType(typeof(WorkflowTaskCreatePayload))]
    public class NewXurrentWorkflowTask : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the workflow to which the task belongs.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string WorkflowId { get; set; } = string.Empty;

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
        /// Automatically set to the current date and time when the task is assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public DateTime? AssignedAt { get; set; }

        /// <summary>
        /// The category of the task. Risk &amp; impact tasks are used to help plan workflows. Approval tasks are used to collect approvals for workflows. These can be used at various stages in the life of the workflow. Implementation tasks are added to workflows for development, installation, configuration, test, transfer and administrative work that needs to be completed for the implementation of the workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public TaskCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the configuration items of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string[]? ConfigurationItemIds { get; set; }

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
        /// Automatically set to the date and time at which the task is saved with the status "Failed", "Rejected", "Completed", "Approved" or "Canceled".
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// The extent to which the service instances related to the task will be impacted by the completion of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public TaskImpact? Impact { get; set; }

        /// <summary>
        /// Used to provide instructions for the person to whom the task will be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// The attachments used in the instructions field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? InstructionsAttachments { get; set; }

        /// <summary>
        /// Identifier of the person to whom the task is to be assigned. This field's value is null in case of an approval task with multiple approvers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Approvals of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public TaskApprovalInput[]? NewApprovals { get; set; }

        /// <summary>
        /// Used to provide information for the person to whom the task is assigned. It is also used to provide a summary of the actions that have been taken to date and the results of these actions.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// The attachments used in the note field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? NoteAttachments { get; set; }

        /// <summary>
        /// Identifier of the PDF design associated with the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// Identifier of the phase of the workflow to which the task belongs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? PhaseId { get; set; }

        /// <summary>
        /// The number of minutes it is expected to take for the task to be completed following its assignment, or following its fixed start date and time if the Start no earlier than field is filled out.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public long? PlannedDuration { get; set; }

        /// <summary>
        /// The number of minutes the member is expected to spend working on the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// Identifiers of predecessors of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string[]? PredecessorIds { get; set; }

        /// <summary>
        /// The identifier of the service instance that should be used to create the request for this task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? RequestServiceInstanceId { get; set; }

        /// <summary>
        /// The identifier of the request template that should be used to create the request for this task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? RequestTemplateId { get; set; }

        /// <summary>
        /// The number of approvers who need to have provided their approval before the status of the task gets updated to "Approved".
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Identifiers of service instances of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string[]? ServiceInstanceIds { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Only used when work on the task may not start before a specific date and time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The Status field is used to select the current status of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public WorkflowTaskStatus? Status { get; set; }

        /// <summary>
        /// A short description of the objective of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifiers of successors of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string[]? SuccessorIds { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that has been asked to assist with the completion of the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request to help with the execution of the task has been registered at the supplier organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// Identifier of the team to which the task is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// Identifier of the task template that was used to register the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// The justification of the time spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public string? TimeEntryDescription { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// Whether the task has been marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// The date and time at which the status of the task is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// When set to true, the completion target of the task is calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipelineByPropertyName = true)]
        public bool? WorkHoursAre24x7 { get; set; }

        /// <summary>
        /// Specifies the <see cref="WorkflowTaskQuery"/> that defines which fields of the <see cref="WorkflowTaskCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipelineByPropertyName = true)]
        public WorkflowTaskQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="WorkflowTaskCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="WorkflowTaskCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTaskCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowId)))
                input.WorkflowId = WorkflowId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnId)))
                input.AgileBoardColumnId = AgileBoardColumnId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnPosition)))
                input.AgileBoardColumnPosition = AgileBoardColumnPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardId)))
                input.AgileBoardId = AgileBoardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignedAt)))
                input.AssignedAt = AssignedAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemIds)))
                input.ConfigurationItemIds = ConfigurationItemIds is null ? new() : new(ConfigurationItemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FinishedAt)))
                input.FinishedAt = FinishedAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact = Impact;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Instructions)))
                input.Instructions = Instructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InstructionsAttachments)))
                input.InstructionsAttachments = InstructionsAttachments is null ? new() : new(InstructionsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.MemberId = MemberId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewApprovals)))
                input.NewApprovals = NewApprovals is null ? new() : new(NewApprovals);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoteAttachments)))
                input.NoteAttachments = NoteAttachments is null ? new() : new(NoteAttachments);

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

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestServiceInstanceId)))
                input.RequestServiceInstanceId = RequestServiceInstanceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplateId)))
                input.RequestTemplateId = RequestTemplateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequiredApprovals)))
                input.RequiredApprovals = RequiredApprovals;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceIds)))
                input.ServiceInstanceIds = ServiceInstanceIds is null ? new() : new(ServiceInstanceIds);

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
                WorkflowTaskCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentWorkflowTask), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentWorkflowTask), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
