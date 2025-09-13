using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="FeedbackQuery"/> object for building Xurrent <see cref="Feedback"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Feedback"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentFeedbackQuery")]
    [OutputType(typeof(FeedbackQuery))]
    public class NewXurrentFeedbackQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Feedback"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Feedback"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FeedbackField[] Properties { get; set; } = Array.Empty<FeedbackField>();

        /// <summary>
        /// Includes a nested <see cref="FeedbackUrlsQuery"/> in the <see cref="FeedbackQuery"/>, allowing related <see cref="FeedbackUrls"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FeedbackUrlsQuery? RequestedBy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="FeedbackUrlsQuery"/> in the <see cref="FeedbackQuery"/>, allowing related <see cref="FeedbackUrls"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FeedbackUrlsQuery? RequestedFor { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="FeedbackQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            FeedbackQuery query = new();

            if (RequestedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedBy)))
                query.SelectRequestedBy(RequestedBy);

            if (RequestedFor is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestedFor)))
                query.SelectRequestedFor(RequestedFor);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
