using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="FirstLineSupportAgreement"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="FirstLineSupportAgreementCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="FirstLineSupportAgreementCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentFirstLineSupportAgreement")]
    [OutputType(typeof(FirstLineSupportAgreementCreatePayload))]
    public class NewXurrentFirstLineSupportAgreement : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the organization that pays for the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// The name of the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the organization that provides the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ProviderId { get; set; } = string.Empty;

        /// <summary>
        /// The amounts that the customer will be charged for the first line support agreement. These can be recurring as well as one-off charges.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? Charges { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the customer representative.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? CustomerRepresentativeId { get; set; }

        /// <summary>
        /// The date through which the first line support agreement (FLSA) will be active. The FLSA expires at the end of this day if it is not renewed before then. When the FLSA has expired, its status will automatically be set to "Expired".
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? ExpiryDate { get; set; }
#else
                public DateTime? ExpiryDate { get; set; }
#endif

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team during their registration.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public long? FirstCallResolutions { get; set; }

        /// <summary>
        /// The last day on which the first line support provider organization can still be contacted to terminate the first line support agreement (FLSA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the FLSA is to expire on a specific date and no notice needs to be given to terminate it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? NoticeDate { get; set; }
#else
                public DateTime? NoticeDate { get; set; }
#endif

        /// <summary>
        /// The minimum percentage of requests that are to be picked up by the service desk team within the pickup target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public long? PickupsWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a new or existing request that has been assigned to the service desk team is assigned to a specific member within the service desk team, is assigned to another team, or is set to a status other than assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public long? PickupTarget { get; set; }

        /// <summary>
        /// The maximum percentage of requests that were reopened (i.e. which status in the account that is covered by the first line support agreement was updated from completed to another status).
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public long? RejectedSolutions { get; set; }

        /// <summary>
        /// Any additional information about the first line support agreement that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team without having been assigned to any other team within the account that is covered by the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public long? ServiceDeskOnlyResolutions { get; set; }

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public long? ServiceDeskResolutions { get; set; }

        /// <summary>
        /// Identifier of the specific team within the first line support provider organization that provides first line support for the users covered by the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? ServiceDeskTeamId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The first day during which the first line support agreement (FLSA) is active.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
                public DateOnly? StartDate { get; set; }
#else
                public DateTime? StartDate { get; set; }
#endif

        /// <summary>
        /// The current status of the first line support agreement (FLSA).
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public AgreementStatus? Status { get; set; }

        /// <summary>
        /// The number of minutes within which a new or existing chat request that has been assigned to the service desk team is assigned to a specific member within the service desk team, is assigned to another team, or is set to a status other than assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public long? SupportChatPickupTarget { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours during which the service desk team can be contacted for first line support.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursId { get; set; }

        /// <summary>
        /// A description of all the targets of the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? TargetDetails { get; set; }

        /// <summary>
        /// The time zone that applies to the start, notice and expiry dates, and to the support hours.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Specifies the <see cref="FirstLineSupportAgreementQuery"/> that defines which fields of the <see cref="FirstLineSupportAgreementCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public FirstLineSupportAgreementQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="FirstLineSupportAgreementCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="FirstLineSupportAgreementCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            FirstLineSupportAgreementCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerId)))
                input.CustomerId = CustomerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProviderId)))
                input.ProviderId = ProviderId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Charges)))
                input.Charges = Charges;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerRepresentativeId)))
                input.CustomerRepresentativeId = CustomerRepresentativeId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ExpiryDate)))
                input.ExpiryDate = ExpiryDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FirstCallResolutions)))
                input.FirstCallResolutions = FirstCallResolutions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoticeDate)))
                input.NoticeDate = NoticeDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PickupsWithinTarget)))
                input.PickupsWithinTarget = PickupsWithinTarget;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PickupTarget)))
                input.PickupTarget = PickupTarget;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RejectedSolutions)))
                input.RejectedSolutions = RejectedSolutions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceDeskOnlyResolutions)))
                input.ServiceDeskOnlyResolutions = ServiceDeskOnlyResolutions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceDeskResolutions)))
                input.ServiceDeskResolutions = ServiceDeskResolutions;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceDeskTeamId)))
                input.ServiceDeskTeamId = ServiceDeskTeamId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartDate)))
                input.StartDate = StartDate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportChatPickupTarget)))
                input.SupportChatPickupTarget = SupportChatPickupTarget;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursId)))
                input.SupportHoursId = SupportHoursId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TargetDetails)))
                input.TargetDetails = TargetDetails;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                FirstLineSupportAgreementCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentFirstLineSupportAgreement), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentFirstLineSupportAgreement), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
