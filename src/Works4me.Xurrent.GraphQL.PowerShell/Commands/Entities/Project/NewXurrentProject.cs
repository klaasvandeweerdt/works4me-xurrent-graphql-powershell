using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Project"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ProjectCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ProjectCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProject")]
    [OutputType(typeof(ProjectCreatePayload))]
    public class NewXurrentProject : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the organization for which the project is to be implemented.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// The reason why the project should be considered for implementation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectJustification Justification { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the implementation of the project.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ManagerId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service for which the project will be implemented.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// A short description of the objective of the project.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Whether the project has been approved and no longer needs to be considered for funding by portfolio management.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public bool? BudgetAllocated { get; set; }

        /// <summary>
        /// The category of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The appropriate completion reason for the project when it has been completed. It is automatically set to "Complete" when all tasks related to the project have reached the status "Completed", "Approved" or "Canceled".
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public ProjectCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// The estimated cost of the effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public decimal? CostOfEffort { get; set; }

        /// <summary>
        /// The estimated cost of all purchases (for equipment, consulting effort, licenses, etc.) needed to implement the project. Recurring costs that will be incurred following the implementation of the project are to be included for the entire ROI calculation period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public decimal? CostOfPurchases { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// The estimated number of hours of effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public long? Effort { get; set; }

        /// <summary>
        /// Phases of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public ProjectPhaseInput[]? NewPhases { get; set; }

        /// <summary>
        /// High-level description of the project. It is also used to add any information that could prove useful for anyone involved in the project, including the people whose approval is needed and the people who are helping to implement it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifiers of the problems of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string[]? ProblemIds { get; set; }

        /// <summary>
        /// Used to indicate which program the project is a part of.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Program { get; set; }

        /// <summary>
        /// Identifiers of the requests of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string[]? RequestIds { get; set; }

        /// <summary>
        /// The risk level of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? RiskLevel { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Automatically set based on the status of the project's tasks.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public ProjectStatus? Status { get; set; }

        /// <summary>
        /// The time zone that applies to the selected work hours.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The estimated financial value that the implementation of the project will deliver for the entire ROI calculation period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public decimal? Value { get; set; }

        /// <summary>
        /// Identifiers of the workflows of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string[]? WorkflowIds { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the work hours that are to be used to calculate the anticipated assignment and completion target for the tasks of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProjectQuery"/> that defines which fields of the <see cref="ProjectCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public ProjectQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ProjectCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ProjectCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerId)))
                input.CustomerId = CustomerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Justification)))
                input.Justification = Justification;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ManagerId)))
                input.ManagerId = ManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(BudgetAllocated)))
                input.BudgetAllocated = BudgetAllocated;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CompletionReason)))
                input.CompletionReason = CompletionReason;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CostOfEffort)))
                input.CostOfEffort = CostOfEffort;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CostOfPurchases)))
                input.CostOfPurchases = CostOfPurchases;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Effort)))
                input.Effort = Effort;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewPhases)))
                input.NewPhases = NewPhases is null ? new() : new(NewPhases);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProblemIds)))
                input.ProblemIds = ProblemIds is null ? new() : new(ProblemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Program)))
                input.Program = Program;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestIds)))
                input.RequestIds = RequestIds is null ? new() : new(RequestIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RiskLevel)))
                input.RiskLevel = RiskLevel;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Value)))
                input.Value = Value;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowIds)))
                input.WorkflowIds = WorkflowIds is null ? new() : new(WorkflowIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkHoursId)))
                input.WorkHoursId = WorkHoursId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ProjectCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProject), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProject), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
