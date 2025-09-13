using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="BroadcastTranslationQuery"/> object for building Xurrent <see cref="BroadcastTranslation"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="BroadcastTranslation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentBroadcastTranslationQuery")]
    [OutputType(typeof(BroadcastTranslationQuery))]
    public class NewXurrentBroadcastTranslationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="BroadcastTranslation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="BroadcastTranslation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public BroadcastTranslationField[] Properties { get; set; } = Array.Empty<BroadcastTranslationField>();

        /// <summary>
        /// Sets the maximum number of <see cref="BroadcastTranslation"/> items returned per request in the <see cref="BroadcastTranslationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="BroadcastTranslationQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? MessageAttachments { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="BroadcastTranslationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            BroadcastTranslationQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (MessageAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(MessageAttachments)))
                query.SelectMessageAttachments(MessageAttachments);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
