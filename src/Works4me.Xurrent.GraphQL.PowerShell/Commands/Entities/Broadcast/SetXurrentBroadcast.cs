using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="Broadcast"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="BroadcastUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="BroadcastUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentBroadcast")]
    [OutputType(typeof(BroadcastUpdatePayload))]
    public class SetXurrentBroadcast : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The body for the email broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? Body { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The customer organizations when the broadcast is to be displayed for the specialists of the account in requests that were received from the selected organizations. This is available only when the "Specialists in requests from the following customers" visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string[]? CustomerIds { get; set; }

        /// <summary>
        /// Whether the message should not be broadcasted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The id of the email template used for the email broadcast. This email template needs to be of the type Send Email from Broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? EmailTemplateId { get; set; }

        /// <summary>
        /// The end date and time of the broadcast. This field is left empty when the message is to be broadcasted until the Disabled box is checked. (If the broadcast should end at midnight at the end of a day, specify 12:00am or 24:00.).
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Message that is to be broadcasted in the language of the account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Message { get; set; }

        /// <summary>
        /// The appropriate icon for the message. The selected icon is displayed alongside the message when the broadcast is presented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public BroadcastMessageType? MessageType { get; set; }

        /// <summary>
        /// The ids of the organizations, to which people belong, that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string[]? OrganizationIds { get; set; }

        /// <summary>
        /// Any additional information about the broadcast that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// Files and inline images linked to the Remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// The request group to which end users can subscribe when they are also affected by the issue for which the broadcast was created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? RequestId { get; set; }

        /// <summary>
        /// The service instances for which the people, who are covered for them by an active SLA, need to see the broadcast. This is available only when the "People covered for the following service instance(s)" visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? ServiceInstanceIds { get; set; }

        /// <summary>
        /// The ids of the sites to which people belong and that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string[]? SiteIds { get; set; }

        /// <summary>
        /// The ids of the skill pools to which people belong and that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string[]? SkillPoolIds { get; set; }

        /// <summary>
        /// The ids of the service level agreements for which the customer representatives will receive the email broadcast. This is only available for broadcasts when the message type "email" is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string[]? SlaIds { get; set; }

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
        /// The start date and time of the broadcast. (If the broadcast should start at midnight at the start of a day, specify 00:00.).
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The subject for the email broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// The teams which members need to see the broadcast. This is available only when the "Members of the following team(s)" visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string[]? TeamIds { get; set; }

        /// <summary>
        /// The time zone that applies to the dates and times specified in the Start and End fields.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Identifiers of translations to remove from this broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string[]? TranslationsToDelete { get; set; }

        /// <summary>
        /// Defines the target audience of the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public BroadcastVisibility? Visibility { get; set; }

        /// <summary>
        /// Specifies the <see cref="BroadcastQuery"/> that defines which fields of the <see cref="BroadcastUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public BroadcastQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="BroadcastUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="BroadcastUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            BroadcastUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Body)))
                input.Body = Body;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomerIds)))
                input.CustomerIds = CustomerIds is null ? new() : new(CustomerIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EmailTemplateId)))
                input.EmailTemplateId = EmailTemplateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndAt)))
                input.EndAt = EndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Message)))
                input.Message = Message;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MessageType)))
                input.MessageType = MessageType;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrganizationIds)))
                input.OrganizationIds = OrganizationIds is null ? new() : new(OrganizationIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Remarks)))
                input.Remarks = Remarks;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                input.RemarksAttachments = RemarksAttachments is null ? new() : new(RemarksAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestId)))
                input.RequestId = RequestId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceIds)))
                input.ServiceInstanceIds = ServiceInstanceIds is null ? new() : new(ServiceInstanceIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SiteIds)))
                input.SiteIds = SiteIds is null ? new() : new(SiteIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SkillPoolIds)))
                input.SkillPoolIds = SkillPoolIds is null ? new() : new(SkillPoolIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SlaIds)))
                input.SlaIds = SlaIds is null ? new() : new(SlaIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subject)))
                input.Subject = Subject;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamIds)))
                input.TeamIds = TeamIds is null ? new() : new(TeamIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TranslationsToDelete)))
                input.TranslationsToDelete = TranslationsToDelete is null ? new() : new(TranslationsToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Visibility)))
                input.Visibility = Visibility;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                BroadcastUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentBroadcast), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentBroadcast), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
