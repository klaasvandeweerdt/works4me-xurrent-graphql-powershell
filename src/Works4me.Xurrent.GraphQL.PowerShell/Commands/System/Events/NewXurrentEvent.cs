using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an new event creation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentEvent")]
    [OutputType(typeof(Request))]
    public class NewXurrentEvent : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the request <see cref="RequestCategory"/> (Category field).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestCategory? Category { get; set; }

        /// <summary>
        /// Configuration item by label or name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? ConfigurationItemName { get; set; }

        /// <summary>
        /// Configuration item identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? ConfigurationItemId { get; set; }

        /// <summary>
        /// Configuration item source (used with <see cref="ConfigurationItemSourceID"/> in the <c>ConfigurationItemBySource</c> parameter set).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "ConfigurationItemBySource")]
        [ValidateNotNullOrEmpty]
        public string? ConfigurationItemSource { get; set; }

        /// <summary>
        /// Configuration item source identifier (used with <see cref="ConfigurationItemSource"/> in the <c>ConfigurationItemBySource</c> parameter set).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "ConfigurationItemBySource")]
        [ValidateNotNullOrEmpty]
        public string? ConfigurationItemSourceID { get; set; }

        /// <summary>
        /// Configuration item object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItem? ConfigurationItem { get; set; }

        /// <summary>
        /// Completion reason (used when the request status is <see cref="RequestStatus.Completed"/>).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// Desired completion timestamp (UTC recommended).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime? DesiredCompletionAt { get; set; }

        /// <summary>
        /// Outage end timestamp (UTC recommended).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime? DownTimeEndAt { get; set; }

        /// <summary>
        /// Outage start timestamp (UTC recommended).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime? DownTimeStartAt { get; set; }

        /// <summary>
        /// Request impact.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestImpact? Impact { get; set; }

        /// <summary>
        /// Internal note (private).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? InternalNote { get; set; }

        /// <summary>
        /// Assignee by member primary email address.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? MemberPrimaryEmail { get; set; }

        /// <summary>
        /// Assignee by member identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? MemberId { get; set; }

        /// <summary>
        /// Assignee person object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person? Member { get; set; }

        /// <summary>
        /// Public note.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? Note { get; set; }

        /// <summary>
        /// Related problem identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? ProblemId { get; set; }

        /// <summary>
        /// Related problem object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Problem? Problem { get; set; }

        /// <summary>
        /// Requested-by person primary email address.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? RequestedByPrimaryEmailAddress { get; set; }

        /// <summary>
        /// Requested-by person identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? RequestedById { get; set; }

        /// <summary>
        /// Requested-by person object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person? RequestedBy { get; set; }

        /// <summary>
        /// Requested-for person identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? RequestedForId { get; set; }

        /// <summary>
        /// Requested-for person primary email address.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? RequestedForPrimaryEmailAddress { get; set; }

        /// <summary>
        /// Requested-for person object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person? RequestedFor { get; set; }

        /// <summary>
        /// Service instance by name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? ServiceInstanceName { get; set; }

        /// <summary>
        /// Service instance identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? ServiceInstanceId { get; set; }

        /// <summary>
        /// Service instance object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstance? ServiceInstance { get; set; }

        /// <summary>
        /// Integration source name (system/application).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? Source { get; set; }

        /// <summary>
        /// Unique source identifier in the external system.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? SourceID { get; set; }

        /// <summary>
        /// Request status.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestStatus? Status { get; set; }

        /// <summary>
        /// Request subject/title.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? Subject { get; set; }

        /// <summary>
        /// Supplier organization by name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? SupplierName { get; set; }

        /// <summary>
        /// Supplier organization identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public long? SupplierId { get; set; }

        /// <summary>
        /// Supplier organization object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Organization? Supplier { get; set; }

        /// <summary>
        /// Support-domain account identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? SupportDomainAccountId { get; set; }

        /// <summary>
        /// Support-domain account object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Account? SupportDomain { get; set; }

        /// <summary>
        /// Team by name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? TeamName { get; set; }

        /// <summary>
        /// Team identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? TeamId { get; set; }

        /// <summary>
        /// Team object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Team? Team { get; set; }

        /// <summary>
        /// Request template identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? RequestTemplateId { get; set; }

        /// <summary>
        /// Request template object.<br/>
        /// If provided, this takes precedence over <see cref="RequestTemplateId"/>.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplate? RequestTemplate { get; set; }

        /// <summary>
        /// Wait-until timestamp (UTC recommended).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// Workflow identifier.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long? WorkflowId { get; set; }

        /// <summary>
        /// Workflow object.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Workflow? Workflow { get; set; }

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the event creation process by constructing a <see cref="RequestEventCreateInput"/> from the bound parameters, 
        /// submitting it to the Xurrent API using the provided or default client, and writing the resulting <see cref="Request"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RequestEventCreateInput input = new();

            if (Category is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                input.Category(Category.Value);

            if (ConfigurationItemName is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemName)))
                input.ConfigurationItem(ConfigurationItemName);

            if (ConfigurationItemId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemId)))
                input.ConfigurationItem(ConfigurationItemId.Value);

            if (ConfigurationItemSource is not null && ConfigurationItemSourceID is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemSource)) && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemSourceID)))
                input.ConfigurationItem(ConfigurationItemSource, ConfigurationItemSourceID);

            if (ConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItem)))
                input.ConfigurationItem(ConfigurationItem);

            if (CompletionReason is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CompletionReason)))
                input.CompletionReason(CompletionReason.Value);

            if (DesiredCompletionAt is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DesiredCompletionAt)))
                input.DesiredCompletionAt(DesiredCompletionAt.Value);

            if (DownTimeEndAt is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DownTimeEndAt)))
                input.DownTimeEndAt(DownTimeEndAt.Value);

            if (DownTimeStartAt is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DownTimeStartAt)))
                input.DownTimeStartAt(DownTimeStartAt.Value);

            if (Impact is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Impact)))
                input.Impact(Impact.Value);

            if (InternalNote is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InternalNote)))
                input.InternalNote(InternalNote);

            if (MemberPrimaryEmail is not null && MyInvocation.BoundParameters.ContainsKey(nameof(MemberPrimaryEmail)))
                input.Member(MemberPrimaryEmail);

            if (MemberId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(MemberId)))
                input.Member(MemberId.Value);

            if (Member is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Member)))
                input.Member(Member);

            if (Note is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                input.Note(Note);

            if (ProblemId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProblemId)))
                input.Problem(ProblemId.Value);

            if (Problem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Problem)))
                input.Problem(Problem);

            if (RequestedByPrimaryEmailAddress is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedByPrimaryEmailAddress)))
                input.RequestedBy(RequestedByPrimaryEmailAddress);

            if (RequestedById is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedById)))
                input.RequestedBy(RequestedById.Value);

            if (RequestedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedBy)))
                input.RequestedBy(RequestedBy);

            if (RequestedForPrimaryEmailAddress is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedForPrimaryEmailAddress)))
                input.RequestedFor(RequestedForPrimaryEmailAddress);

            if (RequestedForId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedForId)))
                input.RequestedFor(RequestedForId.Value);

            if (RequestedFor is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedFor)))
                input.RequestedFor(RequestedFor);

            if (ServiceInstanceName is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceName)))
                input.ServiceInstance(ServiceInstanceName);

            if (ServiceInstanceId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceId)))
                input.ServiceInstance(ServiceInstanceId.Value);

            if (ServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstance)))
                input.ServiceInstance(ServiceInstance);

            if (Source is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source(Source);

            if (SourceID is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID(SourceID);

            if (Status is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status(Status.Value);

            if (Subject is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject(Subject);

            if (SupplierName is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupplierName)))
                input.Supplier(SupplierName);

            if (SupplierId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupplierId)))
                input.Supplier(SupplierId.Value);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                input.Supplier(Supplier);

            if (SupportDomainAccountId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportDomainAccountId)))
                input.SupportDomain(SupportDomainAccountId);

            if (SupportDomain is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportDomain)))
                input.SupportDomain(SupportDomain);

            if (TeamName is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TeamName)))
                input.Team(TeamName);

            if (TeamId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TeamId)))
                input.Team(TeamId.Value);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                input.Team(Team);

            if (RequestTemplateId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplateId)))
                input.RequestTemplate(RequestTemplateId.Value);

            if (RequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplate)))
                input.RequestTemplate(RequestTemplate);

            if (WaitingUntil is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WaitingUntil)))
                input.WaitingUntil(WaitingUntil.Value);

            if (WorkflowId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WorkflowId)))
                input.Workflow(WorkflowId.Value);

            if (Workflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Workflow)))
                input.Workflow(Workflow);

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                Request result = client.Client.CreateEventAsync(input).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentEvent), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentEvent), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
