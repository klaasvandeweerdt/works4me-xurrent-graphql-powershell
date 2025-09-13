using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="NoteReactionQuery"/> object for building Xurrent <see cref="NoteReaction"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="NoteReaction"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentNoteReactionQuery")]
    [OutputType(typeof(NoteReactionQuery))]
    public class NewXurrentNoteReactionQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="NoteReaction"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="NoteReaction"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteReactionField[] Properties { get; set; } = Array.Empty<NoteReactionField>();

        /// <summary>
        /// Sets the maximum number of <see cref="NoteReaction"/> items returned per request in the <see cref="NoteReactionQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="NoteReactionQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Note { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="NoteReactionQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Person { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="NoteReactionQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            NoteReactionQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Note is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                query.SelectNote(Note);

            if (Person is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Person)))
                query.SelectPerson(Person);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
