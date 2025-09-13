using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WebhookPolicy"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="WebhookPolicyCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="WebhookPolicyCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWebhookPolicy")]
    [OutputType(typeof(WebhookPolicyCreatePayload))]
    public class NewXurrentWebhookPolicy : XurrentCmdletBase
    {
        /// <summary>
        /// The algorithm to use for cryptographic signing of webhook messages.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookPolicyJwtAlg JwtAlg { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the webhook policy will be applied.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The audience claim identifies the recipients that the encrypted message is intended for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? JwtAudience { get; set; }

        /// <summary>
        /// The number of minutes within which the claim expires.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public long? JwtClaimExpiresIn { get; set; }

        /// <summary>
        /// Specifies the <see cref="WebhookPolicyCreateResponseQuery"/> that defines which fields of the <see cref="WebhookPolicyCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public WebhookPolicyCreateResponseQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="WebhookPolicyCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="WebhookPolicyCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WebhookPolicyCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(JwtAlg)))
                input.JwtAlg = JwtAlg;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(JwtAudience)))
                input.JwtAudience = JwtAudience;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(JwtClaimExpiresIn)))
                input.JwtClaimExpiresIn = JwtClaimExpiresIn;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                WebhookPolicyCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentWebhookPolicy), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentWebhookPolicy), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
