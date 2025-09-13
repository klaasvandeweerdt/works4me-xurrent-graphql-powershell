using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Site"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="SiteCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="SiteCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSite")]
    [OutputType(typeof(SiteCreatePayload))]
    public class NewXurrentSite : XurrentCmdletBase
    {
        /// <summary>
        /// The name of the site or facility.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Default: false - Whether the site may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// New or updated addresses of the site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public AddressInput[]? NewAddresses { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// Any additional information about the site that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? RemarksAttachments { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The time zone in which the site is located.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Specifies the <see cref="SiteQuery"/> that defines which fields of the <see cref="SiteCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public SiteQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="SiteCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="SiteCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SiteCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAddresses)))
                input.NewAddresses = NewAddresses is null ? new() : new(NewAddresses);

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

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                SiteCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentSite), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentSite), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
