using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Request"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="RequestCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="RequestCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRequest")]
    [OutputType(typeof(RequestCreatePayload))]
    public class NewXurrentRequest : XurrentCmdletBase
    {
        /// <summary>
        /// Default: false - When the Satisfaction field of the request is set to 'Dissatisfied', a person who has the Service Desk Manager role, can check the Addressed box to indicate that the requester has been conciliated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true)]
        public bool? Addressed { get; set; }

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
        /// The Category field is used to select the category of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public RequestCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// reference of the closure code to be selected for the request when it has been completed. Generally this reference is the snake-cased version of the name (eg. resolved_by_workaround for "Resolved by Workaround").
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? ClosureCode { get; set; }

        /// <summary>
        /// The appropriate completion reason for the request when it has been completed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public RequestCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// Identifiers of the configuration items to relate to the request. When this field is used to update an existing request, all configuration items that were linked to this request will be replaced by the supplied configuration items.
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
        /// The date and time that has been agreed on for the completion of the request. The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA's resolution target. By default, the person selected in the Requested by field receives a notification based on the 'Desired Completion Set for Request' email template whenever the value in the Desired completion field is set, updated or removed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public DateTime? DesiredCompletionAt { get; set; }

        /// <summary>
        /// Used to specify the actual date and time at which the service became available again.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public DateTime? DowntimeEndAt { get; set; }

        /// <summary>
        /// Used to specify the actual date and time at which the service outage started.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public DateTime? DowntimeStartAt { get; set; }

        /// <summary>
        /// ID of the request group that is used to group the requests that have been submitted for the resolution of exactly the same incident, for the implementation of exactly the same change, for the provision of exactly the same information, etc.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? GroupedIntoId { get; set; }

        /// <summary>
        /// Used to select the extent to which the service instance is impacted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public RequestImpact? Impact { get; set; }

        /// <summary>
        /// Used to provide information that is visible only for people who have the Auditor, Specialist or Account Administrator role of the account for which the internal note is intended. The x-xurrent-account header sent determines the account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? InternalNote { get; set; }

        /// <summary>
        /// The attachments used in the internalNote field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? InternalNoteAttachments { get; set; }

        /// <summary>
        /// Knowledge articles applied to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string[]? KnowledgeArticleIds { get; set; }

        /// <summary>
        /// Used to indicate the status in the major incident management process.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public RequestMajorIncidentStatus? MajorIncidentStatus { get; set; }

        /// <summary>
        /// ID of the person to whom the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Tags to be added to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public TagInput[]? NewTags { get; set; }

        /// <summary>
        /// New or updated watches.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public WatchInput[]? NewWatches { get; set; }

        /// <summary>
        /// Any additional information that could prove useful for resolving the request and/or to provide a summary of the actions that have been taken since the last entry.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// The attachments used in the note field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? NoteAttachments { get; set; }

        /// <summary>
        /// ID of problem to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public string? ProblemId { get; set; }

        /// <summary>
        /// Estimate of the relative size of this item on the product backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogEstimate { get; set; }

        /// <summary>
        /// Identifier of the product backlog this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? ProductBacklogId { get; set; }

        /// <summary>
        /// The (one based) position of this item on the backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogPosition { get; set; }

        /// <summary>
        /// ID of project to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Default: false - Whether the provider currently indicates not to be accountable.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public bool? ProviderNotAccountable { get; set; }

        /// <summary>
        /// ID of the person who submitted the request. Defaults to the Requested for field if its value was explicitely provided, otherwise it defaults to the current authenticated person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? RequestedById { get; set; }

        /// <summary>
        /// ID of the person for whom the request was submitted. The person selected in the Requested by field is automatically selected in this field, but another person can be selected if the request is submitted for another person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string? RequestedForId { get; set; }

        /// <summary>
        /// Default: false - A request can be marked as reviewed by the problem manager of the service of the service instance that is linked to the request. Marking a request as reviewed excludes it from the 'Requests for Problem Identification' view.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public bool? Reviewed { get; set; }

        /// <summary>
        /// ID of the service instance in which the cause of the incident resides, for which the change is requested, or about which information is needed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Default: assigned - Used to select the current status of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public RequestStatus? Status { get; set; }

        /// <summary>
        /// A short description of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// ID of the supplier organization that has been asked to assist with the request. The supplier organization is automatically selected in this field after a service instance has been selected that is provided by an external service provider organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request has been registered at the supplier organization. If the supplier provided a link to the request, enter the entire URL in this field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// Used to specify the support domain account ID in which the request is to be registered. This parameter needs to be specified when the current user's Person record is registered in a directory account. The ID of a Xurrent account can be found in the 'Account Overview' section of the Settings console.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipelineByPropertyName = true)]
        public string? SupportDomain { get; set; }

        /// <summary>
        /// ID of the team to which the request is to be assigned. By default, the first line team of the service instance that is related to the request will be selected. If a first line team has not been specified for the service instance, the support team of the service instance will be selected instead.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// ID of the request template to apply to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// The justification of the time spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipelineByPropertyName = true)]
        public string? TimeEntryDescription { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 46, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// Setting to true marks request as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// The date and time at which the status of the request is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 48, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// ID of workflow to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 49, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowId { get; set; }

        /// <summary>
        /// Specifies the <see cref="RequestQuery"/> that defines which fields of the <see cref="RequestCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 50, ValueFromPipelineByPropertyName = true)]
        public RequestQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 51, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="RequestCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="RequestCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RequestCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Addressed)))
                input.Addressed = Addressed;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnId)))
                input.AgileBoardColumnId = AgileBoardColumnId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumnPosition)))
                input.AgileBoardColumnPosition = AgileBoardColumnPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardId)))
                input.AgileBoardId = AgileBoardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClosureCode)))
                input.ClosureCode = ClosureCode;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CompletionReason)))
                input.CompletionReason = CompletionReason;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemIds)))
                input.ConfigurationItemIds = ConfigurationItemIds is null ? new() : new(ConfigurationItemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DesiredCompletionAt)))
                input.DesiredCompletionAt = DesiredCompletionAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DowntimeEndAt)))
                input.DowntimeEndAt = DowntimeEndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DowntimeStartAt)))
                input.DowntimeStartAt = DowntimeStartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(GroupedIntoId)))
                input.GroupedIntoId = GroupedIntoId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact = Impact;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InternalNote)))
                input.InternalNote = InternalNote;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InternalNoteAttachments)))
                input.InternalNoteAttachments = InternalNoteAttachments is null ? new() : new(InternalNoteAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(KnowledgeArticleIds)))
                input.KnowledgeArticleIds = KnowledgeArticleIds is null ? new() : new(KnowledgeArticleIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MajorIncidentStatus)))
                input.MajorIncidentStatus = MajorIncidentStatus;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.MemberId = MemberId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewTags)))
                input.NewTags = NewTags is null ? new() : new(NewTags);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewWatches)))
                input.NewWatches = NewWatches is null ? new() : new(NewWatches);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoteAttachments)))
                input.NoteAttachments = NoteAttachments is null ? new() : new(NoteAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProblemId)))
                input.ProblemId = ProblemId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogEstimate)))
                input.ProductBacklogEstimate = ProductBacklogEstimate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogId)))
                input.ProductBacklogId = ProductBacklogId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductBacklogPosition)))
                input.ProductBacklogPosition = ProductBacklogPosition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProjectId)))
                input.ProjectId = ProjectId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProviderNotAccountable)))
                input.ProviderNotAccountable = ProviderNotAccountable;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestedById)))
                input.RequestedById = RequestedById;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestedForId)))
                input.RequestedForId = RequestedForId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reviewed)))
                input.Reviewed = Reviewed;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceId)))
                input.ServiceInstanceId = ServiceInstanceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierRequestID)))
                input.SupplierRequestID = SupplierRequestID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportDomain)))
                input.SupportDomain = SupportDomain;

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

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowId)))
                input.WorkflowId = WorkflowId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                RequestCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentRequest), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentRequest), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
