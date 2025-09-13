using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ServiceOffering"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ServiceOfferingCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ServiceOfferingCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentServiceOffering")]
    [OutputType(typeof(ServiceOfferingCreatePayload))]
    public class NewXurrentServiceOffering : XurrentCmdletBase
    {
        /// <summary>
        /// The name of the service offering.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service for which the service offering is being prepared.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// The duration, expressed as percentage of the total number of service hours, during which the service is to be available to customers with an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public decimal? Availability { get; set; }

        /// <summary>
        /// The amount that the service provider will charge the customer for the delivery of the service per charge driver, per charge term.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? Charges { get; set; }

        /// <summary>
        /// Defines how a Case must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeCase { get; set; }

        /// <summary>
        /// Defines how a high incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeHigh { get; set; }

        /// <summary>
        /// Defines how a low incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeLow { get; set; }

        /// <summary>
        /// Defines how a medium incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeMedium { get; set; }

        /// <summary>
        /// Defines how a RFC must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeRfc { get; set; }

        /// <summary>
        /// Defines how a RFI must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeRfi { get; set; }

        /// <summary>
        /// Defines how a top incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeTop { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The continuity measures for the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? Continuity { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a request with an affected SLA linked to this service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? DefaultEffortClassId { get; set; }

        /// <summary>
        /// Identifiers of effort classes of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string[]? EffortClassIds { get; set; }

        /// <summary>
        /// The limitations that apply to the service level agreements that are based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public string? Limitations { get; set; }

        /// <summary>
        /// Effort class rates of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public EffortClassRateInput[]? NewEffortClassRates { get; set; }

        /// <summary>
        /// Standard service requests of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public StandardServiceRequestInput[]? NewStandardServiceRequests { get; set; }

        /// <summary>
        /// Used to specify what the penalties will be for the service provider organization if a service level target has been breached.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? Penalties { get; set; }

        /// <summary>
        /// Used to describe the transaction(s) and the maximum time these transaction(s) can take to complete.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? Performance { get; set; }

        /// <summary>
        /// Used to specify which requirements need to be met by the customer in order for the customer to be able to benefit from the service. The service provider cannot be held accountable for breaches of the service level targets caused by a failure of the customer to meet one or more of these prerequisites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? Prerequisites { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a Case.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public decimal? RateCase { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a Case.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public Currency? RateCaseCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a high incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public decimal? RateHigh { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a high incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public Currency? RateHighCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a low incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public decimal? RateLow { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a low incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        public Currency? RateLowCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a medium incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipelineByPropertyName = true)]
        public decimal? RateMedium { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a medium incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipelineByPropertyName = true)]
        public Currency? RateMediumCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a RFC.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipelineByPropertyName = true)]
        public decimal? RateRfc { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFC.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipelineByPropertyName = true)]
        public Currency? RateRfcCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a RFI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipelineByPropertyName = true)]
        public decimal? RateRfi { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipelineByPropertyName = true)]
        public Currency? RateRfiCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a top incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipelineByPropertyName = true)]
        public decimal? RateTop { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a top incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipelineByPropertyName = true)]
        public Currency? RateTopCurrency { get; set; }

        /// <summary>
        /// The Recovery Point Objective (RPO) is the maximum targeted duration in minutes in which data (transactions) might be lost from an IT service due to a major incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipelineByPropertyName = true)]
        public long? RecoveryPointObjective { get; set; }

        /// <summary>
        /// The Recovery Time Objective (RTO) is the maximum targeted duration in minutes in which a business process must be restored after a disaster (or disruption) in order to avoid unacceptable consequences associated with a break in business continuity.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipelineByPropertyName = true)]
        public long? RecoveryTimeObjective { get; set; }

        /// <summary>
        /// Used to specify the maximum number of times per month that the service may become unavailable to customers with an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipelineByPropertyName = true)]
        public string? Reliability { get; set; }

        /// <summary>
        /// Used to specify how often the representative of a customer of an active SLA that is based on the service offering will receive a report comparing the service level targets specified in the service offering with the actual level of service provided.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingReportFrequency? ReportFrequency { get; set; }

        /// <summary>
        /// The minimum percentage of incidents that is to be resolved before their resolution target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionsWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category "Case" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetCase { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value "High - Service Degraded for Several Users" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetHigh { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value "Low - Service Degraded for One User" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetLow { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value "Medium - Service Down for One User" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetMedium { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category "RFC - Request for Change" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetRfc { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category "RFI - Request for Information" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetRfi { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value "Top - Service Down for Several Users" is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 46, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetTop { get; set; }

        /// <summary>
        /// The minimum percentage of incidents that is to be responded to before their response target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipelineByPropertyName = true)]
        public long? ResponsesWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category "Case" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 48, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetCase { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact "High - Service Degraded for Several Users" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 49, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetHigh { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact "Low - Service Degraded for One User" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 50, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetLow { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact "Medium - Service Down for One User" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 51, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetMedium { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category "RFC - Request for Change" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 52, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetRfc { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category "RFI - Request for Information" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 53, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetRfi { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact "Top - Service Down for Several Users" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 54, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetTop { get; set; }

        /// <summary>
        /// How often an active SLA that is based on the service offering will be reviewed with the representative of its customer.
        /// </summary>
        [Parameter(Mandatory = false, Position = 55, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingReviewFrequency? ReviewFrequency { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the hours during which the service is supposed to be available.
        /// </summary>
        [Parameter(Mandatory = false, Position = 56, ValueFromPipelineByPropertyName = true)]
        public string? ServiceHoursId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 57, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 58, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The current status of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 59, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingStatus? Status { get; set; }

        /// <summary>
        /// A high-level description of the differentiators between this service offering and other service offerings that have already been, or could be, prepared for the same service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 60, ValueFromPipelineByPropertyName = true)]
        public string? Summary { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category "Case" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 61, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursCaseId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact "High - Service Degraded for Several Users" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 62, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursHighId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact "Low - Service Degraded for One User" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 63, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursLowId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact "Medium - Service Down for One User" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 64, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursMediumId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category "RFC - Request for Change" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 65, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursRfcId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category "RFI - Request for Information" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 66, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursRfiId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact "Top - Service Down for Several Users" when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 67, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursTopId { get; set; }

        /// <summary>
        /// Used to describe the length of notice required for changing or terminating the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 68, ValueFromPipelineByPropertyName = true)]
        public string? Termination { get; set; }

        /// <summary>
        /// The time zone that applies to the selected service hours.<br/>
        /// The list with possible values is available on the Xurrent developer site.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 69, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Specifies the <see cref="ServiceOfferingQuery"/> that defines which fields of the <see cref="ServiceOfferingCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 70, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 71, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ServiceOfferingCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ServiceOfferingCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ServiceOfferingCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceId)))
                input.ServiceId = ServiceId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Availability)))
                input.Availability = Availability;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Charges)))
                input.Charges = Charges;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeCase)))
                input.ChargeTypeCase = ChargeTypeCase;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeHigh)))
                input.ChargeTypeHigh = ChargeTypeHigh;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeLow)))
                input.ChargeTypeLow = ChargeTypeLow;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeMedium)))
                input.ChargeTypeMedium = ChargeTypeMedium;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeRfc)))
                input.ChargeTypeRfc = ChargeTypeRfc;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeRfi)))
                input.ChargeTypeRfi = ChargeTypeRfi;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ChargeTypeTop)))
                input.ChargeTypeTop = ChargeTypeTop;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Continuity)))
                input.Continuity = Continuity;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DefaultEffortClassId)))
                input.DefaultEffortClassId = DefaultEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassIds)))
                input.EffortClassIds = EffortClassIds is null ? new() : new(EffortClassIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Limitations)))
                input.Limitations = Limitations;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewEffortClassRates)))
                input.NewEffortClassRates = NewEffortClassRates is null ? new() : new(NewEffortClassRates);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NewStandardServiceRequests)))
                input.NewStandardServiceRequests = NewStandardServiceRequests is null ? new() : new(NewStandardServiceRequests);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Penalties)))
                input.Penalties = Penalties;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Performance)))
                input.Performance = Performance;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Prerequisites)))
                input.Prerequisites = Prerequisites;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateCase)))
                input.RateCase = RateCase;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateCaseCurrency)))
                input.RateCaseCurrency = RateCaseCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateHigh)))
                input.RateHigh = RateHigh;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateHighCurrency)))
                input.RateHighCurrency = RateHighCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateLow)))
                input.RateLow = RateLow;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateLowCurrency)))
                input.RateLowCurrency = RateLowCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateMedium)))
                input.RateMedium = RateMedium;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateMediumCurrency)))
                input.RateMediumCurrency = RateMediumCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateRfc)))
                input.RateRfc = RateRfc;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateRfcCurrency)))
                input.RateRfcCurrency = RateRfcCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateRfi)))
                input.RateRfi = RateRfi;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateRfiCurrency)))
                input.RateRfiCurrency = RateRfiCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateTop)))
                input.RateTop = RateTop;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RateTopCurrency)))
                input.RateTopCurrency = RateTopCurrency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RecoveryPointObjective)))
                input.RecoveryPointObjective = RecoveryPointObjective;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RecoveryTimeObjective)))
                input.RecoveryTimeObjective = RecoveryTimeObjective;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reliability)))
                input.Reliability = Reliability;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ReportFrequency)))
                input.ReportFrequency = ReportFrequency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionsWithinTarget)))
                input.ResolutionsWithinTarget = ResolutionsWithinTarget;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetCase)))
                input.ResolutionTargetCase = ResolutionTargetCase;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetHigh)))
                input.ResolutionTargetHigh = ResolutionTargetHigh;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetLow)))
                input.ResolutionTargetLow = ResolutionTargetLow;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetMedium)))
                input.ResolutionTargetMedium = ResolutionTargetMedium;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetRfc)))
                input.ResolutionTargetRfc = ResolutionTargetRfc;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetRfi)))
                input.ResolutionTargetRfi = ResolutionTargetRfi;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetTop)))
                input.ResolutionTargetTop = ResolutionTargetTop;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponsesWithinTarget)))
                input.ResponsesWithinTarget = ResponsesWithinTarget;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetCase)))
                input.ResponseTargetCase = ResponseTargetCase;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetHigh)))
                input.ResponseTargetHigh = ResponseTargetHigh;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetLow)))
                input.ResponseTargetLow = ResponseTargetLow;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetMedium)))
                input.ResponseTargetMedium = ResponseTargetMedium;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetRfc)))
                input.ResponseTargetRfc = ResponseTargetRfc;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetRfi)))
                input.ResponseTargetRfi = ResponseTargetRfi;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetTop)))
                input.ResponseTargetTop = ResponseTargetTop;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ReviewFrequency)))
                input.ReviewFrequency = ReviewFrequency;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServiceHoursId)))
                input.ServiceHoursId = ServiceHoursId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                input.Status = Status;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Summary)))
                input.Summary = Summary;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursCaseId)))
                input.SupportHoursCaseId = SupportHoursCaseId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursHighId)))
                input.SupportHoursHighId = SupportHoursHighId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursLowId)))
                input.SupportHoursLowId = SupportHoursLowId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursMediumId)))
                input.SupportHoursMediumId = SupportHoursMediumId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursRfcId)))
                input.SupportHoursRfcId = SupportHoursRfcId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursRfiId)))
                input.SupportHoursRfiId = SupportHoursRfiId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SupportHoursTopId)))
                input.SupportHoursTopId = SupportHoursTopId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Termination)))
                input.Termination = Termination;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeZone)))
                input.TimeZone = TimeZone;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ServiceOfferingCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentServiceOffering), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentServiceOffering), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
