using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Problem"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ProblemCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ProblemCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProblem")]
    [OutputType(typeof(ProblemCreatePayload))]
    public class NewXurrentProblem : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the service in which instance(s) the problem resides.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// A short description of the symptoms that the problem causes.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// ID of the column this item is placed in.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardColumnId { get; set; }

        /// <summary>
        /// The (one based) position of this item in its column.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public long? AgileBoardColumnPosition { get; set; }

        /// <summary>
        /// ID of the board this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// Used to specify when the current assignee needs to have completed the root cause analysis of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public DateTime? AnalysisTargetAt { get; set; }

        /// <summary>
        /// The category of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public ProblemCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of configuration items of this problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string[]? ConfigurationItemIds { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Used to select the extent to which the service is impacted when an incident occurs that is caused by the problem. Defaults to none.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public ProblemImpact? Impact { get; set; }

        /// <summary>
        /// Identifier of the knowledge article which instructions should be followed to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? KnowledgeArticleId { get; set; }

        /// <summary>
        /// Whether the underlying cause of the problem has been found and a temporary workaround has been proposed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public bool? KnownError { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the problem through root cause analysis, the proposal of a structural solution and ultimately its closure. Defaults to the current authenticated person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// Identifier of the person to whom the problem is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Detailed description of the symptoms that are caused by the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Estimate of the relative size of this item on the product backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogEstimate { get; set; }

        /// <summary>
        /// Identifier of the product backlog this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? ProductBacklogId { get; set; }

        /// <summary>
        /// The (one based) position of this item on the backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogPosition { get; set; }

        /// <summary>
        /// Identifier of the project to link the problem to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Identifiers of requests of this problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string[]? RequestIds { get; set; }

        /// <summary>
        /// Identifiers of service instances of this problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string[]? ServiceInstanceIds { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The current status of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public ProblemStatus? Status { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that has been asked for a solution to the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request to help with the solution of the problem has been registered at the supplier organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// Identifier of the team to which the problem is to be assigned. Defaults to the support team of the service if no team or member is present.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The justification of the time spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? TimeEntryDescription { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether the problem has been marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// The date and time at which the status of the problem is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// Used to describe the temporary workaround that should be applied to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public string? Workaround { get; set; }

        /// <summary>
        /// Identifier of the workflow that will implement the proposed permanent solution for the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowId { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProblemQuery"/> that defines which fields of the <see cref="ProblemCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public ProblemQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ProblemCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ProblemCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProblemCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnId)))
                input.AgileBoardColumnId = AgileBoardColumnId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnPosition)))
                input.AgileBoardColumnPosition = AgileBoardColumnPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardId)))
                input.AgileBoardId = AgileBoardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AnalysisTargetAt)))
                input.AnalysisTargetAt = AnalysisTargetAt;

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

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact = Impact;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(KnowledgeArticleId)))
                input.KnowledgeArticleId = KnowledgeArticleId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(KnownError)))
                input.KnownError = KnownError;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ManagerId)))
                input.ManagerId = ManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.MemberId = MemberId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogEstimate)))
                input.ProductBacklogEstimate = ProductBacklogEstimate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogId)))
                input.ProductBacklogId = ProductBacklogId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogPosition)))
                input.ProductBacklogPosition = ProductBacklogPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProjectId)))
                input.ProjectId = ProjectId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestIds)))
                input.RequestIds = RequestIds is null ? new() : new(RequestIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceIds)))
                input.ServiceInstanceIds = ServiceInstanceIds is null ? new() : new(ServiceInstanceIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierRequestID)))
                input.SupplierRequestID = SupplierRequestID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.TeamId = TeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeEntryDescription)))
                input.TimeEntryDescription = TimeEntryDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeSpent)))
                input.TimeSpent = TimeSpent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeSpentEffortClassId)))
                input.TimeSpentEffortClassId = TimeSpentEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Urgent)))
                input.Urgent = Urgent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WaitingUntil)))
                input.WaitingUntil = WaitingUntil;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Workaround)))
                input.Workaround = Workaround;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowId)))
                input.WorkflowId = WorkflowId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ProblemCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProblem), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentProblem), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
