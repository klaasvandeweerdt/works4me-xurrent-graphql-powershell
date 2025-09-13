using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="RequestTemplate"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="RequestTemplateUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="RequestTemplateUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentRequestTemplate")]
    [OutputType(typeof(RequestTemplateUpdatePayload))]
    public class SetXurrentRequestTemplate : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// After selecting the request template in Self Service, the user needs to be able to select a configuration item in the Asset field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public bool? AssetSelection { get; set; }

        /// <summary>
        /// Whether the person who is registering a new request based on the template is selected in its Member field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? AssignToSelf { get; set; }

        /// <summary>
        /// The category that needs to be selected in the Category field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public RequestCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The completion reason that needs to be selected in the Completion reason field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public RequestCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// Identifier of the CI that needs to be copied to the Configuration item field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? ConfigurationItemId { get; set; }

        /// <summary>
        /// Whether the subject of the request template needs to become the subject of a request when the template is applied, provided that the Subject field of this request is empty.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public bool? CopySubjectToRequests { get; set; }

        /// <summary>
        /// Used to enter the number of minutes within which requests that are based on the request template are to be resolved.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public long? DesiredCompletion { get; set; }

        /// <summary>
        /// Whether the request template may not be used to help register new requests.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a request that is based on the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// Whether the request template is shown to end users in Self Service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public bool? EndUsers { get; set; }

        /// <summary>
        /// The impact level that needs to be selected in the Impact field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public RequestImpact? Impact { get; set; }

        /// <summary>
        /// Instructions for the support staff who will work on requests that are based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// A comma-separated list of words that can be used to find the request template using search.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? Keywords { get; set; }

        /// <summary>
        /// Identifier of the person who should be selected in the Member field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Note field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// The information that needs to be displayed after the template has been applied to a new or existing request. This field typically contains step-by-step instructions about how to complete the registration of a request that is based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? RegistrationHints { get; set; }

        /// <summary>
        /// Identifiers of reservation offerings related to the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string[]? ReservationOfferingIds { get; set; }

        /// <summary>
        /// Identifier of the service for which the request template is made available.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

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
        /// Whether the request template is shown to Specialists.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public bool? Specialists { get; set; }

        /// <summary>
        /// Used to select the status value that needs to be selected in the Status field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public RequestStatus? Status { get; set; }

        /// <summary>
        /// A short description that needs to be copied to the Subject field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that should be selected in the Supplier field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the calendar that is to be used to calculate the desired completion for requests that are based on the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursId { get; set; }

        /// <summary>
        /// Identifier of the team that should be selected in the Team field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The time zone that applies to the selected support hours.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether a new request that is created based on the template is to be marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public bool? Urgent { get; set; }

        /// <summary>
        /// Identifier of the Workflow Manager linked to the request template. _Required_ when a Workflow Template is defined, and the Service does not define a Workflow Manager.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// Identifier of the Workflow Template related to the request template. _Required_ when the _Status_ is set to _Workflow Pending_.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// Specifies the <see cref="RequestTemplateQuery"/> that defines which fields of the <see cref="RequestTemplateUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public RequestTemplateQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="RequestTemplateUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="RequestTemplateUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RequestTemplateUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssetSelection)))
                input.AssetSelection = AssetSelection;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignToSelf)))
                input.AssignToSelf = AssignToSelf;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category = Category;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CompletionReason)))
                input.CompletionReason = CompletionReason;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemId)))
                input.ConfigurationItemId = ConfigurationItemId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CopySubjectToRequests)))
                input.CopySubjectToRequests = CopySubjectToRequests;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DesiredCompletion)))
                input.DesiredCompletion = DesiredCompletion;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassId)))
                input.EffortClassId = EffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndUsers)))
                input.EndUsers = EndUsers;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact = Impact;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Instructions)))
                input.Instructions = Instructions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Keywords)))
                input.Keywords = Keywords;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.MemberId = MemberId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note = Note;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RegistrationHints)))
                input.RegistrationHints = RegistrationHints;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ReservationOfferingIds)))
                input.ReservationOfferingIds = ReservationOfferingIds is null ? new() : new(ReservationOfferingIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Specialists)))
                input.Specialists = Specialists;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.SupplierId = SupplierId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursId)))
                input.SupportHoursId = SupportHoursId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.TeamId = TeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Urgent)))
                input.Urgent = Urgent;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowManagerId)))
                input.WorkflowManagerId = WorkflowManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowTemplateId)))
                input.WorkflowTemplateId = WorkflowTemplateId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                RequestTemplateUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentRequestTemplate), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentRequestTemplate), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
