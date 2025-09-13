using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ShopArticle"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ShopArticleCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ShopArticleCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentShopArticle")]
    [OutputType(typeof(ShopArticleCreatePayload))]
    public class NewXurrentShopArticle : XurrentCmdletBase
    {
        /// <summary>
        /// The display name of the shop article.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Calendar that represents the work hours related to the fulfillment/delivery.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? CalendarId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The number of minutes it usually takes to deliver the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public long? DeliveryDuration { get; set; }

        /// <summary>
        /// Whether the shop article is visible in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// After this moment the shop article is no longer available in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// The request template used to order one of more units of this shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? FulfillmentTemplateId { get; set; }

        /// <summary>
        /// The full description of the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? FullDescription { get; set; }

        /// <summary>
        /// The largest number of units that may be bought at once.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public long? MaxQuantity { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// The price of a single unit.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public decimal? Price { get; set; }

        /// <summary>
        /// The currency of the price of this shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public Currency? PriceCurrency { get; set; }

        /// <summary>
        /// Related product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? ProductId { get; set; }

        /// <summary>
        /// The frequency in which the recurring price is due.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public ShopArticleRecurringPeriod? RecurringPeriod { get; set; }

        /// <summary>
        /// The recurring price of a single unit.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public decimal? RecurringPrice { get; set; }

        /// <summary>
        /// The currency of the recurring price of this shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public Currency? RecurringPriceCurrency { get; set; }

        /// <summary>
        /// This reference can be used to link the shop article to a shop order line using the Xurrent APIs or the Xurrent Import functionality.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public string? Reference { get; set; }

        /// <summary>
        /// Whether or not this is a physical article that requires shipping.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public bool? RequiresShipping { get; set; }

        /// <summary>
        /// The shop description of the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? ShortDescription { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The moment the shop article becomes available in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The Time zone related to the calendar.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Specifies the <see cref="ShopArticleQuery"/> that defines which fields of the <see cref="ShopArticleCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public ShopArticleQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ShopArticleCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ShopArticleCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ShopArticleCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CalendarId)))
                input.CalendarId = CalendarId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DeliveryDuration)))
                input.DeliveryDuration = DeliveryDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndAt)))
                input.EndAt = EndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FulfillmentTemplateId)))
                input.FulfillmentTemplateId = FulfillmentTemplateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(FullDescription)))
                input.FullDescription = FullDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxQuantity)))
                input.MaxQuantity = MaxQuantity;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Price)))
                input.Price = Price;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PriceCurrency)))
                input.PriceCurrency = PriceCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProductId)))
                input.ProductId = ProductId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RecurringPeriod)))
                input.RecurringPeriod = RecurringPeriod;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RecurringPrice)))
                input.RecurringPrice = RecurringPrice;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RecurringPriceCurrency)))
                input.RecurringPriceCurrency = RecurringPriceCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reference)))
                input.Reference = Reference;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequiresShipping)))
                input.RequiresShipping = RequiresShipping;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ShortDescription)))
                input.ShortDescription = ShortDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UiExtensionId)))
                input.UiExtensionId = UiExtensionId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ShopArticleCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShopArticle), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentShopArticle), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
