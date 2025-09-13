using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Note"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="NoteCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="NoteCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentNote")]
    [OutputType(typeof(NoteCreatePayload))]
    public class NewXurrentNote : XurrentCmdletBase
    {
        /// <summary>
        /// The record that the note should be added to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Text of the note.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The attachments used in the note field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? Attachments { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the note should be visible only for people who have the Auditor, Specialist or Account Administrator role of the account. Internal notes are only available for Requests.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? Internal { get; set; }

        /// <summary>
        /// Whether Note Added notifications for this note should be suppressed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public bool? SuppressNoteAddedNotifications { get; set; }

        /// <summary>
        /// Specifies the <see cref="NoteQuery"/> that defines which fields of the <see cref="NoteCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public NoteQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="NoteCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="NoteCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            NoteCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OwnerId)))
                input.OwnerId = OwnerId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Text)))
                input.Text = Text;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Attachments)))
                input.Attachments = Attachments is null ? new() : new(Attachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Internal)))
                input.Internal = Internal;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SuppressNoteAddedNotifications)))
                input.SuppressNoteAddedNotifications = SuppressNoteAddedNotifications;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                NoteCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentNote), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentNote), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
