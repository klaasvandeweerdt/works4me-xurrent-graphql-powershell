using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ReservationOffering"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ReservationOfferingCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ReservationOfferingCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentReservationOffering")]
    [OutputType(typeof(ReservationOfferingCreatePayload))]
    public class NewXurrentReservationOffering : XurrentCmdletBase
    {
        /// <summary>
        /// Calendar that defines the hours in which reservations may start and end.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CalendarId { get; set; } = string.Empty;

        /// <summary>
        /// The maximum duration of the reservation within the hours of the calendar.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long MaxDuration { get; set; } = 0;

        /// <summary>
        /// The minimum duration of the reservation within the hours of the calendar.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long MinDuration { get; set; } = 0;

        /// <summary>
        /// A short description of the reservation offering.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The increments with which the reservation may be prolonged.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long StepDuration { get; set; } = 0;

        /// <summary>
        /// The time zone that applies to the selected calendar.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TimeZone { get; set; } = string.Empty;

        /// <summary>
        /// Whether it is allowed to create recurrent reservations for this offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public bool? AllowRepeat { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the configuration items that may be reserved using this offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string[]? ConfigurationItemIds { get; set; }

        /// <summary>
        /// Whether the reservation offering may not be used to register requests for reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The filters of the reservation offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string[]? Filters { get; set; }

        /// <summary>
        /// The initial status of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public ReservationStatus? InitialStatus { get; set; }

        /// <summary>
        /// The maximum duration between the creation time of a request for reservation and the requested start of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public long? MaxAdvanceDuration { get; set; }

        /// <summary>
        /// The minimum duration between the creation time of a request for reservation and the requested start of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public long? MinAdvanceDuration { get; set; }

        /// <summary>
        /// Whether or not the reservation may span over multiple calendar days.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public bool? MultiDay { get; set; }

        /// <summary>
        /// The duration required to prepare the asset before the reservation starts.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public long? PreparationDuration { get; set; }

        /// <summary>
        /// Reservations of this reservation offering are private and can not be viewed by other end users.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public bool? PrivateReservations { get; set; }

        /// <summary>
        /// Identifier of the service instance for which the reservations may be requested.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="ReservationOfferingQuery"/> that defines which fields of the <see cref="ReservationOfferingCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public ReservationOfferingQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ReservationOfferingCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ReservationOfferingCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ReservationOfferingCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CalendarId)))
                input.CalendarId = CalendarId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxDuration)))
                input.MaxDuration = MaxDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MinDuration)))
                input.MinDuration = MinDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StepDuration)))
                input.StepDuration = StepDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AllowRepeat)))
                input.AllowRepeat = AllowRepeat;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItemIds)))
                input.ConfigurationItemIds = ConfigurationItemIds is null ? new() : new(ConfigurationItemIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
                input.Filters = Filters is null ? new() : new(Filters);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InitialStatus)))
                input.InitialStatus = InitialStatus;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MaxAdvanceDuration)))
                input.MaxAdvanceDuration = MaxAdvanceDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MinAdvanceDuration)))
                input.MinAdvanceDuration = MinAdvanceDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(MultiDay)))
                input.MultiDay = MultiDay;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PreparationDuration)))
                input.PreparationDuration = PreparationDuration;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PrivateReservations)))
                input.PrivateReservations = PrivateReservations;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstanceId)))
                input.ServiceInstanceId = ServiceInstanceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ReservationOfferingCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentReservationOffering), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentReservationOffering), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
