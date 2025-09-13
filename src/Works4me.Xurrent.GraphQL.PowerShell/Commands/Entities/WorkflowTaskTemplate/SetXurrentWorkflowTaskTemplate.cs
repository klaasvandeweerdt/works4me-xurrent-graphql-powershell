using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="WorkflowTaskTemplate"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="WorkflowTaskTemplateUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="WorkflowTaskTemplateUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentWorkflowTaskTemplate")]
    [OutputType(typeof(WorkflowTaskTemplateUpdatePayload))]
    public class SetXurrentWorkflowTaskTemplate : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Identifiers of approvals to delete.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string[]? ApprovalsToDelete { get; set; }

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Requested for field of the request for which the workflow is being generated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToRequester { get; set; }

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the business unit to which the organization belongs that is linked to the person who is selected in the Requested for field of the request for which the workflow is being generated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToRequesterBusinessUnitManager { get; set; }

        /// <summary>
        /// Whether the manager of the requester of the first related request is to be selected in the Approver field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToRequesterManager { get; set; }

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Service owner field of the service that is linked to the workflow that the new task is a part of.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToServiceOwner { get; set; }

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the workflow to which the task belongs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToWorkflowManager { get; set; }

        /// <summary>
        /// The category that needs to be selected in the Category field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public TaskCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the configuration items of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string[]? ConfigurationItemIds { get; set; }

        /// <summary>
        /// Whether the Copy note to workflow box of tasks that were created based on the template needs to be checked by default. (The Copy notes to workflow checkbox is called "Copy notes to workflow by default" when the task template is in Edit mode.).
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public bool? CopyNotesToWorkflow { get; set; }

        /// <summary>
        /// Whether the task template may not be used to help register new tasks.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a task created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// The impact level that needs to be selected in the Impact field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public TaskImpact? Impact { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Instructions field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// Identifier of the person who should be selected in the Member field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Approvals of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public TaskTemplateApprovalInput[]? NewApprovals { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Note field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifier of the PDF design that needs to be copied to the PDF design field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// The number of minutes that should be entered in the Planned duration field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public long? PlannedDuration { get; set; }

        /// <summary>
        /// The number of minutes the member is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// The number of minutes the person, who is selected in the Requested for field of the first related request, is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequester { get; set; }

        /// <summary>
        /// The number of minutes the business unit manager of the requester of the first related request is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterBusinessUnitManager { get; set; }

        /// <summary>
        /// The number of minutes the manager of the requester of the first related request is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterManager { get; set; }

        /// <summary>
        /// The number of minutes the owner of the service of the related to the workflow is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortServiceOwner { get; set; }

        /// <summary>
        /// The number of minutes the workflow manager is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortWorkflowManager { get; set; }

        /// <summary>
        /// Default: false - Whether the provider indicates not to be accountable for the affected SLAs linked to the requests that are linked to the workflow of a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public bool? ProviderNotAccountable { get; set; }

        /// <summary>
        /// Identifier of the service instance that should be selected in the Request service instance field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? RequestServiceInstanceId { get; set; }

        /// <summary>
        /// Identifier of the request template that should be selected in the Request template field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public string? RequestTemplateId { get; set; }

        /// <summary>
        /// The number that needs to be specified in the Required approvals field of a new approval task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Identifiers of the service instances of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public string[]? ServiceInstanceIds { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// A short description that needs to be copied to the Subject field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that should be selected in the Supplier field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team that should be selected in the Team field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether a new task that is created based on the template is to be marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// Whether the completion target of tasks created based on the template are calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public bool? WorkHoursAre24x7 { get; set; }

        /// <summary>
        /// Specifies the <see cref="WorkflowTaskTemplateQuery"/> that defines which fields of the <see cref="WorkflowTaskTemplateUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public WorkflowTaskTemplateQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="WorkflowTaskTemplateUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="WorkflowTaskTemplateUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTaskTemplateUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ApprovalsToDelete)))
                input.ApprovalsToDelete = ApprovalsToDelete is null ? new() : new(ApprovalsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToRequester)))
                input.AssignToRequester = AssignToRequester;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToRequesterBusinessUnitManager)))
                input.AssignToRequesterBusinessUnitManager = AssignToRequesterBusinessUnitManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToRequesterManager)))
                input.AssignToRequesterManager = AssignToRequesterManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToServiceOwner)))
                input.AssignToServiceOwner = AssignToServiceOwner;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToWorkflowManager)))
                input.AssignToWorkflowManager = AssignToWorkflowManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemIds)))
                input.ConfigurationItemIds = ConfigurationItemIds is null ? new() : new(ConfigurationItemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CopyNotesToWorkflow)))
                input.CopyNotesToWorkflow = CopyNotesToWorkflow;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassId)))
                input.EffortClassId = EffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact = Impact;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Instructions)))
                input.Instructions = Instructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.MemberId = MemberId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewApprovals)))
                input.NewApprovals = NewApprovals is null ? new() : new(NewApprovals);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PdfDesignId)))
                input.PdfDesignId = PdfDesignId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedDuration)))
                input.PlannedDuration = PlannedDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffort)))
                input.PlannedEffort = PlannedEffort;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffortRequester)))
                input.PlannedEffortRequester = PlannedEffortRequester;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffortRequesterBusinessUnitManager)))
                input.PlannedEffortRequesterBusinessUnitManager = PlannedEffortRequesterBusinessUnitManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffortRequesterManager)))
                input.PlannedEffortRequesterManager = PlannedEffortRequesterManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffortServiceOwner)))
                input.PlannedEffortServiceOwner = PlannedEffortServiceOwner;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlannedEffortWorkflowManager)))
                input.PlannedEffortWorkflowManager = PlannedEffortWorkflowManager;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProviderNotAccountable)))
                input.ProviderNotAccountable = ProviderNotAccountable;

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

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.TeamId = TeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Urgent)))
                input.Urgent = Urgent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkHoursAre24x7)))
                input.WorkHoursAre24x7 = WorkHoursAre24x7;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                WorkflowTaskTemplateUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentWorkflowTaskTemplate), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentWorkflowTaskTemplate), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
