using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ShortUrl"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ShortUrlCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ShortUrlCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentShortUrl")]
    [OutputType(typeof(ShortUrlCreatePayload))]
    public class NewXurrentShortUrl : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the CI for which a request is to be registered in Xurrent Self Service when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string? CiId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the dashboard which is to be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? DashboardId { get; set; }

        /// <summary>
        /// Values for email that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public ShortUrlEmailInput? Email { get; set; }

        /// <summary>
        /// Coordinates of the location for which a map should be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public ShortUrlGeoInput? Geo { get; set; }

        /// <summary>
        /// Identifier of the knowledge article which instructions need to be displayed when the short URL is used in Xurrent Self Service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? KnowledgeArticleId { get; set; }

        /// <summary>
        /// The address (or only the city or country) for which a map should be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? MapAddress { get; set; }

        /// <summary>
        /// The Plain text field is used to enter the text that should be displayed when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? PlainText { get; set; }

        /// <summary>
        /// The identifier of the request template that is to be applied to each new request that is opened when in Xurrent Self Service when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? RequestTemplateId { get; set; }

        /// <summary>
        /// The Skype name that is to be called when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? SkypeName { get; set; }

        /// <summary>
        /// Values for the SMS message that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public ShortUrlSmsInput? Sms { get; set; }

        /// <summary>
        /// The telephone number that is to be called when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? Tel { get; set; }

        /// <summary>
        /// The Twitter tweet that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Tweet { get; set; }

        /// <summary>
        /// The name of the Twitter user whose Twitter feed is to be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? TwitterName { get; set; }

        /// <summary>
        /// The uniform resource identifier (URI) to which the short URL is forwarded.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public Uri? Uri { get; set; }

        /// <summary>
        /// The uniform resource locator of a website to which the short URL is to forward when it is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public Uri? WebsiteUrl { get; set; }

        /// <summary>
        /// Specifies the <see cref="ShortUrlQuery"/> that defines which fields of the <see cref="ShortUrlCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public ShortUrlQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ShortUrlCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ShortUrlCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ShortUrlCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CiId)))
                input.CiId = CiId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DashboardId)))
                input.DashboardId = DashboardId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Email)))
                input.Email = Email;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Geo)))
                input.Geo = Geo;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(KnowledgeArticleId)))
                input.KnowledgeArticleId = KnowledgeArticleId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MapAddress)))
                input.MapAddress = MapAddress;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PlainText)))
                input.PlainText = PlainText;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplateId)))
                input.RequestTemplateId = RequestTemplateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SkypeName)))
                input.SkypeName = SkypeName;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Sms)))
                input.Sms = Sms;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Tel)))
                input.Tel = Tel;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Tweet)))
                input.Tweet = Tweet;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TwitterName)))
                input.TwitterName = TwitterName;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Uri)))
                input.Uri = Uri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(WebsiteUrl)))
                input.WebsiteUrl = WebsiteUrl;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ShortUrlCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShortUrl), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShortUrl), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
