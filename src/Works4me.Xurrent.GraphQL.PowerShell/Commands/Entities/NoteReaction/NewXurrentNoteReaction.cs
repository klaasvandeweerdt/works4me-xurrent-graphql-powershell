using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="NoteReaction"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="NoteReactionCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="NoteReactionCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentNoteReaction")]
    [OutputType(typeof(NoteReactionCreatePayload))]
    public class NewXurrentNoteReaction : XurrentCmdletBase
    {
        /// <summary>
        /// The identifier of the note you want to add a reaction to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NoteId { get; set; } = string.Empty;

        /// <summary>
        /// The type of reaction to add to the note. Valid values are:<br/>
        /// • 👍.<br/>
        /// • 👎.<br/>
        /// • 😀.<br/>
        /// • 😕.<br/>
        /// • 🎉.<br/>
        /// • ❤️.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Reaction { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="NoteReactionQuery"/> that defines which fields of the <see cref="NoteReactionCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public NoteReactionQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="NoteReactionCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="NoteReactionCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            NoteReactionCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NoteId)))
                input.NoteId = NoteId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reaction)))
                input.Reaction = Reaction;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                NoteReactionCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentNoteReaction), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentNoteReaction), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
