using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Person"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="PersonCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="PersonCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentPerson")]
    [OutputType(typeof(PersonCreatePayload))]
    public class NewXurrentPerson : XurrentCmdletBase
    {
        /// <summary>
        /// The name of the person.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The email address to which email notifications are to be sent. This email address acts as the unique identifier for the person within the Xurrent account. This primary email address also acts as the person's login name if he/she is a user of the Xurrent service.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PrimaryEmail { get; set; } = string.Empty;

        /// <summary>
        /// Uniquely identify the user for Single Sign-On.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? AuthenticationID { get; set; }

        /// <summary>
        /// Whether the person should be offered translations for texts that are written in languages other than the ones selected in the Language (language) and the Do not translate (do_not_translate_languages) arguments. Such texts are translated automatically into the language selected in the Language (language) argument.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? AutoTranslation { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Configuration items this person is related to as a user.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string[]? ConfigurationItemIds { get; set; }

        /// <summary>
        /// The person's estimated total cost per work hour for the service provider organization. The value in this argument should include the costs of the person's salary (or rate in case of a long-term contractor), office space, service subscriptions, training, etc.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public decimal? CostPerHour { get; set; }

        /// <summary>
        /// The currency of the cost per hour value attributed to this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public Currency? CostPerHourCurrency { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// true when the person may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The languages that should not be translated automatically for the person. Translations will not be offered to the person for texts in any of these languages. Supported language codes are: en, nl, de, fr, es, pt, it, da, fi, sv, pl, cs, tr, ru, ar, id, fa, no, zh, ja, ko, he, hi, ms.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string[]? DoNotTranslateLanguages { get; set; }

        /// <summary>
        /// The unique identifier for a person typically based on order of hire or association with an organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? EmployeeID { get; set; }

        /// <summary>
        /// Whether team notifications should be excluded from all notifications.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public bool? ExcludeTeamNotifications { get; set; }

        /// <summary>
        /// Any additional information about the person that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? Information { get; set; }

        /// <summary>
        /// The attachments used in the information field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? InformationAttachments { get; set; }

        /// <summary>
        /// The person's job title.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? JobTitle { get; set; }

        /// <summary>
        /// The language preference of the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Language { get; set; }

        /// <summary>
        /// The name or number of the room, cubicle or area where the person has his/her primary work space.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? Location { get; set; }

        /// <summary>
        /// The manager or supervisor to whom the person reports.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// Permissions for specific accounts of this person to add or update. Permissions for other accounts will not be altered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public PermissionInput[]? NewAccountPermissions { get; set; }

        /// <summary>
        /// New or updated addresses of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public AddressInput[]? NewAddresses { get; set; }

        /// <summary>
        /// New or updated contacts of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public ContactInput[]? NewContacts { get; set; }

        /// <summary>
        /// An enabled OAuth person is mentionable and visible in suggest fields, just like a real person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public bool? OauthPersonEnablement { get; set; }

        /// <summary>
        /// The organization for which the person works as an employee or long-term contractor.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Permissions of this person. These will overwrite all existing permissions of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public PermissionInput[]? Permissions { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record. This may be a 'data URL', allowing the image to be supplied directly without requiring a separate upload first.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// Indicates when to send email notifications to the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public PersonSendEmailNotifications? SendEmailNotifications { get; set; }

        /// <summary>
        /// Indicates when to show a notification popup to the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public PersonShowNotificationPopup? ShowNotificationPopup { get; set; }

        /// <summary>
        /// Where the person is stationed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public string? SiteId { get; set; }

        /// <summary>
        /// Skill pools this person belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public string[]? SkillPoolIds { get; set; }

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
        /// A number or code that a service desk analyst can ask the person for when the person contacts the service desk for support.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public string? SupportID { get; set; }

        /// <summary>
        /// Teams this person belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public string[]? TeamIds { get; set; }

        /// <summary>
        /// Whether the person prefers to see times displayed within the Xurrent service in the 24-hour format or not (in which case the 12-hour format is applied).
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public bool? TimeFormat24h { get; set; }

        /// <summary>
        /// The time zone in which the person normally resides.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether the person is a very important person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public bool? Vip { get; set; }

        /// <summary>
        /// Calendar that represents the work hours of the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// Specifies the <see cref="PersonQuery"/> that defines which fields of the <see cref="PersonCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        public PersonQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="PersonCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="PersonCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            PersonCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PrimaryEmail)))
                input.PrimaryEmail = PrimaryEmail;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AuthenticationID)))
                input.AuthenticationID = AuthenticationID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AutoTranslation)))
                input.AutoTranslation = AutoTranslation;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemIds)))
                input.ConfigurationItemIds = ConfigurationItemIds is null ? new() : new(ConfigurationItemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CostPerHour)))
                input.CostPerHour = CostPerHour;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CostPerHourCurrency)))
                input.CostPerHourCurrency = CostPerHourCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DoNotTranslateLanguages)))
                input.DoNotTranslateLanguages = DoNotTranslateLanguages is null ? new() : new(DoNotTranslateLanguages);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EmployeeID)))
                input.EmployeeID = EmployeeID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ExcludeTeamNotifications)))
                input.ExcludeTeamNotifications = ExcludeTeamNotifications;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Information)))
                input.Information = Information;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InformationAttachments)))
                input.InformationAttachments = InformationAttachments is null ? new() : new(InformationAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(JobTitle)))
                input.JobTitle = JobTitle;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Language)))
                input.Language = Language;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                input.Location = Location;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ManagerId)))
                input.ManagerId = ManagerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAccountPermissions)))
                input.NewAccountPermissions = NewAccountPermissions is null ? new() : new(NewAccountPermissions);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAddresses)))
                input.NewAddresses = NewAddresses is null ? new() : new(NewAddresses);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewContacts)))
                input.NewContacts = NewContacts is null ? new() : new(NewContacts);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OauthPersonEnablement)))
                input.OauthPersonEnablement = OauthPersonEnablement;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrganizationId)))
                input.OrganizationId = OrganizationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Permissions)))
                input.Permissions = Permissions is null ? new() : new(Permissions);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SendEmailNotifications)))
                input.SendEmailNotifications = SendEmailNotifications;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ShowNotificationPopup)))
                input.ShowNotificationPopup = ShowNotificationPopup;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SiteId)))
                input.SiteId = SiteId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SkillPoolIds)))
                input.SkillPoolIds = SkillPoolIds is null ? new() : new(SkillPoolIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportID)))
                input.SupportID = SupportID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TeamIds)))
                input.TeamIds = TeamIds is null ? new() : new(TeamIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeFormat24h)))
                input.TimeFormat24h = TimeFormat24h;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Vip)))
                input.Vip = Vip;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WorkHoursId)))
                input.WorkHoursId = WorkHoursId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                PersonCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentPerson), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentPerson), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
