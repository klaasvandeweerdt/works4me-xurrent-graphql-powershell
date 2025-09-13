using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="NoteQuery"/> object for building Xurrent <see cref="Note"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Note"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentNoteQuery")]
    [OutputType(typeof(NoteQuery))]
    public class NewXurrentNoteQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Note"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Note"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteField[] Properties { get; set; } = Array.Empty<NoteField>();

        /// <summary>
        /// Sets the maximum number of <see cref="Note"/> items returned per request in the <see cref="NoteQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="NoteQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="InboundEmailQuery"/> in the <see cref="NoteQuery"/>, allowing related <see cref="InboundEmail"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InboundEmailQuery? InboundEmail { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteReactionQuery"/> in the <see cref="NoteQuery"/>, allowing related <see cref="NoteReaction"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteReactionQuery? NoteReactions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="NoteQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Person { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="NoteQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? TextAttachments { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="NoteQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            NoteQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (InboundEmail is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InboundEmail)))
                query.SelectInboundEmail(InboundEmail);

            if (NoteReactions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(NoteReactions)))
                query.SelectNoteReactions(NoteReactions);

            if (Person is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Person)))
                query.SelectPerson(Person);

            if (TextAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TextAttachments)))
                query.SelectTextAttachments(TextAttachments);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
