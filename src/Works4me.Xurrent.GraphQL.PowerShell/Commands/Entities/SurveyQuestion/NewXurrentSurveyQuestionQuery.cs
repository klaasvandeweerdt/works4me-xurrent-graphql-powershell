using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SurveyQuestionQuery"/> object for building Xurrent <see cref="SurveyQuestion"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="SurveyQuestion"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSurveyQuestionQuery")]
    [OutputType(typeof(SurveyQuestionQuery))]
    public class NewXurrentSurveyQuestionQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SurveyQuestion"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SurveyQuestion"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuestionField[] Properties { get; set; } = Array.Empty<SurveyQuestionField>();

        /// <summary>
        /// Sets the maximum number of <see cref="SurveyQuestion"/> items returned per request in the <see cref="SurveyQuestionQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SurveyQuestionQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="SurveyQuestionQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? GuidanceAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SurveyQuery"/> in the <see cref="SurveyQuestionQuery"/>, allowing related <see cref="Survey"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuery? Survey { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="SurveyQuestionQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SurveyQuestionQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SurveyQuestionQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (GuidanceAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(GuidanceAttachments)))
                query.SelectGuidanceAttachments(GuidanceAttachments);

            if (Survey is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Survey)))
                query.SelectSurvey(Survey);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
