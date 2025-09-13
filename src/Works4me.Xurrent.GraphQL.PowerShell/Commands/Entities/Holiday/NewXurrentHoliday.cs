using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="Holiday"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="HolidayCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="HolidayCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentHoliday")]
    [OutputType(typeof(HolidayCreatePayload))]
    public class NewXurrentHoliday : XurrentCmdletBase
    {
        /// <summary>
        /// End of the holiday.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime EndAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Name of the holiday.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Start of the holiday.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime StartAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Identifiers of calendars of the holiday.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string[]? CalendarIds { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public Uri? PictureUri { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="HolidayQuery"/> that defines which fields of the <see cref="HolidayCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public HolidayQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="HolidayCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="HolidayCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            HolidayCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndAt)))
                input.EndAt = EndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CalendarIds)))
                input.CalendarIds = CalendarIds is null ? new() : new(CalendarIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PictureUri)))
                input.PictureUri = PictureUri;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                HolidayCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentHoliday), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentHoliday), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
