using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Team"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="TeamCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="TeamCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTeam")]
    [OutputType(typeof(TeamCreatePayload))]
    public class NewXurrentTeam : XurrentCmdletBase
    {
        /// <summary>
        /// The name of the team.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Used to automatically link records to the agile board when they are assigned to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// Whether requests are auto-assigned to a team member.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? AutoAssign { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The person who maintains the information about the configuration items that the team supports.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ConfigurationManagerId { get; set; }

        /// <summary>
        /// The current team coordinator for the team. Only members of the team can be selected in this field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? CoordinatorId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Whether the team may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Used to specify an email address for the team. When an email is sent to this email address, a new request gets generated and assigned to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? InboundEmailLocalPart { get; set; }

        /// <summary>
        /// The manager or supervisor of the team. This person is able to maintain the information about the team. The manager of a team does not need to be a member of the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// People that are linked as member to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string[]? MemberIds { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// Any additional information about the team that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The time zone that applies to the selected work hours.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The calendar that defines the work hours during which the team is available for work on all types of assignments.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// Specifies the <see cref="TeamQuery"/> that defines which fields of the <see cref="TeamCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public TeamQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="TeamCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="TeamCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TeamCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardId)))
                input.AgileBoardId = AgileBoardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AutoAssign)))
                input.AutoAssign = AutoAssign;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationManagerId)))
                input.ConfigurationManagerId = ConfigurationManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CoordinatorId)))
                input.CoordinatorId = CoordinatorId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InboundEmailLocalPart)))
                input.InboundEmailLocalPart = InboundEmailLocalPart;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ManagerId)))
                input.ManagerId = ManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MemberIds)))
                input.MemberIds = MemberIds is null ? new() : new(MemberIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkHoursId)))
                input.WorkHoursId = WorkHoursId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                TeamCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTeam), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTeam), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
