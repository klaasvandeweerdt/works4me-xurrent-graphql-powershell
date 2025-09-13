using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Translation"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="TranslationCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="TranslationCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTranslation")]
    [OutputType(typeof(TranslationCreatePayload))]
    public class NewXurrentTranslation : XurrentCmdletBase
    {
        /// <summary>
        /// The field of the record from which the translation is obtained.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Field { get; set; } = string.Empty;

        /// <summary>
        /// The language in which the text is specified.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// The record from which the translation is obtained.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// The text of the translation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="TranslationQuery"/> that defines which fields of the <see cref="TranslationCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public TranslationQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="TranslationCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="TranslationCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TranslationCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Field)))
                input.Field = Field;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Language)))
                input.Language = Language;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OwnerId)))
                input.OwnerId = OwnerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Text)))
                input.Text = Text;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                TranslationCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTranslation), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentTranslation), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
