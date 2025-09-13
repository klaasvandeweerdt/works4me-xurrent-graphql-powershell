using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="OutOfOfficePeriod"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="OutOfOfficePeriodCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="OutOfOfficePeriodCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentOutOfOfficePeriod")]
    [OutputType(typeof(OutOfOfficePeriodCreatePayload))]
    public class NewXurrentOutOfOfficePeriod : XurrentCmdletBase
    {
        /// <summary>
        /// End time of the out of office period.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime EndAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Identifier of the person who is out of office.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PersonId { get; set; } = string.Empty;

        /// <summary>
        /// Start time of the out of office period.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime StartAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Identifier of the person who is selected as the approval delegate for the out of office period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string? ApprovalDelegateId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Used to generate time entries for the out of office period. This field is required if the timesheet settings linked to the person's organization has one or more effort classes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// The reason of the out of office period. Required when the description category of the time allocation is required.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Reason { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Used to generate time entries for the out of office period. Only the time allocations without service and customer that are linked to the person's organization can be selected. This field is required if at least one time allocation exists that meets those conditions.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationId { get; set; }

        /// <summary>
        /// Specifies the <see cref="OutOfOfficePeriodQuery"/> that defines which fields of the <see cref="OutOfOfficePeriodCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public OutOfOfficePeriodQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="OutOfOfficePeriodCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="OutOfOfficePeriodCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            OutOfOfficePeriodCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EndAt)))
                input.EndAt = EndAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PersonId)))
                input.PersonId = PersonId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartAt)))
                input.StartAt = StartAt;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ApprovalDelegateId)))
                input.ApprovalDelegateId = ApprovalDelegateId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassId)))
                input.EffortClassId = EffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reason)))
                input.Reason = Reason;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocationId)))
                input.TimeAllocationId = TimeAllocationId;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                OutOfOfficePeriodCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentOutOfOfficePeriod), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentOutOfOfficePeriod), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
