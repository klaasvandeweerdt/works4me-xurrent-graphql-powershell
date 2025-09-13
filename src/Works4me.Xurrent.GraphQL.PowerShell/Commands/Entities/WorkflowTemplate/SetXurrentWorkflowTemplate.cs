using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="WorkflowTemplate"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="WorkflowTemplateUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="WorkflowTemplateUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentWorkflowTemplate")]
    [OutputType(typeof(WorkflowTemplateUpdatePayload))]
    public class SetXurrentWorkflowTemplate : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The category that needs to be selected in the Category field of a new workflow when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public WorkflowCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the workflow template may not be used to help register new workflows.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The information that needs to be shown when a new workflow is being created based on the template. This field typically contains instructions about how to register the workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// The justification that needs to be selected in the Justification field of a new workflow when it is being created based on the template. This field is required when there are request templates linked to the workflow template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public WorkflowJustification? Justification { get; set; }

        /// <summary>
        /// Task template relations of the workflow template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public WorkflowTemplateTaskTemplateInput[]? NewTaskTemplateRelations { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Note field of a new workflow when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Recurrence for the workflow template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public RecurrenceInput? Recurrence { get; set; }

        /// <summary>
        /// The service that should be selected in the Service field of a new workflow when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Short description that needs to be copied to the Subject field of a new workflow when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifiers of task template relations to remove from the workflow template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? TaskTemplateRelationsToDelete { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// The type that needs to be selected in the Type field of a new workflow when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTypeId { get; set; }

        /// <summary>
        /// Specifies the <see cref="WorkflowTemplateQuery"/> that defines which fields of the <see cref="WorkflowTemplateUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public WorkflowTemplateQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="WorkflowTemplateUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="WorkflowTemplateUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowTemplateUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Instructions)))
                input.Instructions = Instructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Justification)))
                input.Justification = Justification;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewTaskTemplateRelations)))
                input.NewTaskTemplateRelations = NewTaskTemplateRelations is null ? new() : new(NewTaskTemplateRelations);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Recurrence)))
                input.Recurrence = Recurrence;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TaskTemplateRelationsToDelete)))
                input.TaskTemplateRelationsToDelete = TaskTemplateRelationsToDelete is null ? new() : new(TaskTemplateRelationsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManagerId)))
                input.WorkflowManagerId = WorkflowManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTypeId)))
                input.WorkflowTypeId = WorkflowTypeId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                WorkflowTemplateUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentWorkflowTemplate), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentWorkflowTemplate), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
