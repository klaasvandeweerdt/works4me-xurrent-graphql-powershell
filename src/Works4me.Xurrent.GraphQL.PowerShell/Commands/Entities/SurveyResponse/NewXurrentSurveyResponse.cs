using System;
using System.Management.Automation;
using System.Text.Json;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SurveyResponse"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="SurveyResponseCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="SurveyResponseCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSurveyResponse")]
    [OutputType(typeof(SurveyResponseCreatePayload))]
    public class NewXurrentSurveyResponse : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the service this response is about.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the survey this response is for.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SurveyId { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the respondent completed the survey.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? Completed { get; set; }

        /// <summary>
        /// Answers of this survey response.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public SurveyAnswerInput[]? NewAnswers { get; set; }

        /// <summary>
        /// Identifier of the person who provided this response (i.e. the respondent).
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? PersonId { get; set; }

        /// <summary>
        /// Rating calculated based on the answers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public int? Rating { get; set; }

        /// <summary>
        /// How the individual answers were combined to calculate the rating.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public JsonElement? RatingCalculation { get; set; }

        /// <summary>
        /// Time this response was submitted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public DateTime? RespondedAt { get; set; }

        /// <summary>
        /// Identifiers of the SLAs this response is for. (Ignored when supplying a personId.).
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string[]? SlaIds { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="SurveyResponseQuery"/> that defines which fields of the <see cref="SurveyResponseCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public SurveyResponseQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="SurveyResponseCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="SurveyResponseCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SurveyResponseCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SurveyId)))
                input.SurveyId = SurveyId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Completed)))
                input.Completed = Completed;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewAnswers)))
                input.NewAnswers = NewAnswers is null ? new() : new(NewAnswers);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PersonId)))
                input.PersonId = PersonId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Rating)))
                input.Rating = Rating;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RatingCalculation)))
                input.RatingCalculation = RatingCalculation;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RespondedAt)))
                input.RespondedAt = RespondedAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SlaIds)))
                input.SlaIds = SlaIds is null ? new() : new(SlaIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                SurveyResponseCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentSurveyResponse), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentSurveyResponse), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
