using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SurveyAnswerQuery"/> object for building Xurrent <see cref="SurveyAnswer"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="SurveyAnswer"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSurveyAnswerQuery")]
    [OutputType(typeof(SurveyAnswerQuery))]
    public class NewXurrentSurveyAnswerQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SurveyAnswer"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SurveyAnswer"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyAnswerField[] Properties { get; set; } = Array.Empty<SurveyAnswerField>();

        /// <summary>
        /// Sets the maximum number of <see cref="SurveyAnswer"/> items returned per request in the <see cref="SurveyAnswerQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SurveyAnswerQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuestionQuery"/> in the <see cref="SurveyAnswerQuery"/>, allowing related <see cref="SurveyQuestion"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuestionQuery? Question { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyResponseQuery"/> in the <see cref="SurveyAnswerQuery"/>, allowing related <see cref="SurveyResponse"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyResponseQuery? SurveyResponse { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="SurveyAnswerQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? TextAttachments { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SurveyAnswerQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SurveyAnswerQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Question is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Question)))
                query.SelectQuestion(Question);

            if (SurveyResponse is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SurveyResponse)))
                query.SelectSurveyResponse(SurveyResponse);

            if (TextAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TextAttachments)))
                query.SelectTextAttachments(TextAttachments);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
