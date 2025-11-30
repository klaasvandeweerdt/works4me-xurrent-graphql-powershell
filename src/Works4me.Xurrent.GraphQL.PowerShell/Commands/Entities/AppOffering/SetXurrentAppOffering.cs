using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="AppOffering"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="AppOfferingUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="AppOfferingUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentAppOffering")]
    [OutputType(typeof(AppOfferingUpdatePayload))]
    public class SetXurrentAppOffering : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Short description of the app offering to be shown on the card in the App store.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? CardDescription { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Compliance description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? Compliance { get; set; }

        /// <summary>
        /// The attachments used in the compliance field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? ComplianceAttachments { get; set; }

        /// <summary>
        /// The URI where the app can be configured. The placeholder {account} can be used to include the customer account id in the URI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public Uri? ConfigurationUriTemplate { get; set; }

        /// <summary>
        /// Description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? DescriptionAttachments { get; set; }

        /// <summary>
        /// Whether the app offering may not be used for new instances.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Feature description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? Features { get; set; }

        /// <summary>
        /// The attachments used in the features field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? FeaturesAttachments { get; set; }

        /// <summary>
        /// Name of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Scopes of this app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public AppOfferingScopeInput[]? NewScopes { get; set; }

        /// <summary>
        /// The endpoints for the OAuth application that will be created for this app to use in the Authorization Code Grant flow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string[]? OauthAuthorizationEndpoints { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record. This may be a 'data URL', allowing the image to be supplied directly without requiring a separate upload first.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// The algorithm used for generating the policy for the app offering's webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public WebhookPolicyJwtAlg? PolicyJwtAlg { get; set; }

        /// <summary>
        /// The audience for the policy for the app offering's webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? PolicyJwtAudience { get; set; }

        /// <summary>
        /// The claim expiry time for the policy for the app offering's webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public long? PolicyJwtClaimExpiresIn { get; set; }

        /// <summary>
        /// This reference can be used to link the app offering to an instance using the Xurrent APIs or the Xurrent Import functionality.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? Reference { get; set; }

        /// <summary>
        /// This app requires an enabled OAuth person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public bool? RequiresEnabledOauthPerson { get; set; }

        /// <summary>
        /// Identifiers of scopes to remove from the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string[]? ScopesToDelete { get; set; }

        /// <summary>
        /// Identifier of the the service instance this app offering is linked to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Identifier of the UI extension version that is linked to the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionVersionId { get; set; }

        /// <summary>
        /// The URI for the app offering's webhook. The placeholder {account} can be used to include the customer account id in the URI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public Uri? WebhookUriTemplate { get; set; }

        /// <summary>
        /// Specifies the <see cref="AppOfferingQuery"/> that defines which fields of the <see cref="AppOfferingUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public AppOfferingQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="AppOfferingUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="AppOfferingUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CardDescription)))
                input.CardDescription = CardDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Compliance)))
                input.Compliance = Compliance;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ComplianceAttachments)))
                input.ComplianceAttachments = ComplianceAttachments is null ? new() : new(ComplianceAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationUriTemplate)))
                input.ConfigurationUriTemplate = ConfigurationUriTemplate;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                input.DescriptionAttachments = DescriptionAttachments is null ? new() : new(DescriptionAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Features)))
                input.Features = Features;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FeaturesAttachments)))
                input.FeaturesAttachments = FeaturesAttachments is null ? new() : new(FeaturesAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewScopes)))
                input.NewScopes = NewScopes is null ? new() : new(NewScopes);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OauthAuthorizationEndpoints)))
                input.OauthAuthorizationEndpoints = OauthAuthorizationEndpoints is null ? new() : new(OauthAuthorizationEndpoints);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PolicyJwtAlg)))
                input.PolicyJwtAlg = PolicyJwtAlg;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PolicyJwtAudience)))
                input.PolicyJwtAudience = PolicyJwtAudience;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PolicyJwtClaimExpiresIn)))
                input.PolicyJwtClaimExpiresIn = PolicyJwtClaimExpiresIn;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reference)))
                input.Reference = Reference;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequiresEnabledOauthPerson)))
                input.RequiresEnabledOauthPerson = RequiresEnabledOauthPerson;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ScopesToDelete)))
                input.ScopesToDelete = ScopesToDelete is null ? new() : new(ScopesToDelete);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceId)))
                input.ServiceInstanceId = ServiceInstanceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionVersionId)))
                input.UiExtensionVersionId = UiExtensionVersionId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WebhookUriTemplate)))
                input.WebhookUriTemplate = WebhookUriTemplate;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AppOfferingUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentAppOffering), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentAppOffering), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
