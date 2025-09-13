using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ServiceLevelAgreement"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ServiceLevelAgreementCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ServiceLevelAgreementCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentServiceLevelAgreement")]
    [OutputType(typeof(ServiceLevelAgreementCreatePayload))]
    public class NewXurrentServiceLevelAgreement : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the organization that pays for the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// The name of the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service offering that specifies the conditions that apply to the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceOfferingId { get; set; } = string.Empty;

        /// <summary>
        /// The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider. This contains the activityIDs related to request categories.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public ActivityIDInput? ActivityID { get; set; }

        /// <summary>
        /// The Agreement ID is the unique identifier by which all the activities that are performed through the coverage of the SLA are known in the billing system of the service provider.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? AgreementID { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Used to specify how people who are to be covered by the service level agreement are to be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public SlaCoverage? Coverage { get; set; }

        /// <summary>
        /// Identifier of the account which service level managers are allowed to update the parts of the SLA that are intended to be maintained by the service level managers of the customer. More importantly, this field is used to specify whether specialists of the customer are allowed to see the requests that include this SLA in their Affected SLAs section.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? CustomerAccountId { get; set; }

        /// <summary>
        /// Identifiers of the people who represents the customer organization for the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string[]? CustomerRepresentativeIds { get; set; }

        /// <summary>
        /// The date through which the service level agreement (SLA) will be active. The SLA expires at the end of this day if it is not renewed before then. When the SLA has expired, its status will automatically be set to "Expired".
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? ExpiryDate { get; set; }
#else
                public DateTime? ExpiryDate { get; set; }
#endif

        /// <summary>
        /// The Rate IDs are the unique identifiers by which an effort class that is linked to a time entry when an activity was performed through the coverage of the SLA is known in the billing system of the service provider.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public EffortClassRateIDInput[]? NewEffortClassRateIDs { get; set; }

        /// <summary>
        /// Represents the activityIDs for standard service requests. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public StandardServiceRequestActivityIDInput[]? NewStandardServiceRequestActivityIDs { get; set; }

        /// <summary>
        /// The last day on which the service provider organization can still be contacted to terminate the service level agreement (SLA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the SLA is to expire on a specific date and no notice needs to be given to terminate it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? NoticeDate { get; set; }
#else
                public DateTime? NoticeDate { get; set; }
#endif

        /// <summary>
        /// Identifiers of the organizations of the service level agreement. Only available for service level agreements where the coverage field is set to organizations_and_descendants, organizations or organizations_and_sites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? OrganizationIds { get; set; }

        /// <summary>
        /// Identifiers of the people of the service level agreement. Only available for service level agreements where the coverage field is set to people.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string[]? PersonIds { get; set; }

        /// <summary>
        /// Any additional information about the service level agreement that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// Identifier of the service instance that will be used to provide the service to the customer of the service level agreement. Only service instances that are linked to the same service as the selected service offering can be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// Identifier of the person of the service provider organization who acts as the service level manager for the customer of the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? ServiceLevelManagerId { get; set; }

        /// <summary>
        /// Identifiers of the sites of the service level agreement. Only available for service level agreements where the coverage field is set to sites or organizations_and_sites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string[]? SiteIds { get; set; }

        /// <summary>
        /// Identifiers of the skill pools of the service level agreement. Only available for service level agreements where the coverage field is set to skill_pools.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string[]? SkillPoolIds { get; set; }

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
        /// The first day during which the service level agreement (SLA) is active.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? StartDate { get; set; }
#else
                public DateTime? StartDate { get; set; }
#endif

        /// <summary>
        /// The current status of the service level agreement (SLA).
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public AgreementStatus? Status { get; set; }

        /// <summary>
        /// Whether knowledge articles from the service provider should be exposed to the people covered by the service instances related to the service level agreement. Only available for service level agreements where the coverage field is set to service_instances.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public bool? UseKnowledgeFromServiceProvider { get; set; }

        /// <summary>
        /// Specifies the <see cref="ServiceLevelAgreementQuery"/> that defines which fields of the <see cref="ServiceLevelAgreementCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public ServiceLevelAgreementQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ServiceLevelAgreementCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ServiceLevelAgreementCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ServiceLevelAgreementCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerId)))
                input.CustomerId = CustomerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceOfferingId)))
                input.ServiceOfferingId = ServiceOfferingId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ActivityID)))
                input.ActivityID = ActivityID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgreementID)))
                input.AgreementID = AgreementID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Coverage)))
                input.Coverage = Coverage;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerAccountId)))
                input.CustomerAccountId = CustomerAccountId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerRepresentativeIds)))
                input.CustomerRepresentativeIds = CustomerRepresentativeIds is null ? new() : new(CustomerRepresentativeIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ExpiryDate)))
                input.ExpiryDate = ExpiryDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewEffortClassRateIDs)))
                input.NewEffortClassRateIDs = NewEffortClassRateIDs is null ? new() : new(NewEffortClassRateIDs);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewStandardServiceRequestActivityIDs)))
                input.NewStandardServiceRequestActivityIDs = NewStandardServiceRequestActivityIDs is null ? new() : new(NewStandardServiceRequestActivityIDs);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoticeDate)))
                input.NoticeDate = NoticeDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrganizationIds)))
                input.OrganizationIds = OrganizationIds is null ? new() : new(OrganizationIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PersonIds)))
                input.PersonIds = PersonIds is null ? new() : new(PersonIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceId)))
                input.ServiceInstanceId = ServiceInstanceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceLevelManagerId)))
                input.ServiceLevelManagerId = ServiceLevelManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SiteIds)))
                input.SiteIds = SiteIds is null ? new() : new(SiteIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SkillPoolIds)))
                input.SkillPoolIds = SkillPoolIds is null ? new() : new(SkillPoolIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartDate)))
                input.StartDate = StartDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UseKnowledgeFromServiceProvider)))
                input.UseKnowledgeFromServiceProvider = UseKnowledgeFromServiceProvider;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ServiceLevelAgreementCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentServiceLevelAgreement), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentServiceLevelAgreement), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
