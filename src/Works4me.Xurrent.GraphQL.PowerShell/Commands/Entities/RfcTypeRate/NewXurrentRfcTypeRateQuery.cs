using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RfcTypeRateQuery"/> object for building Xurrent <see cref="RfcTypeRate"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="RfcTypeRate"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRfcTypeRateQuery")]
    [OutputType(typeof(RfcTypeRateQuery))]
    public class NewXurrentRfcTypeRateQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="RfcTypeRate"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="RfcTypeRate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RfcTypeRateField[] Properties { get; set; } = Array.Empty<RfcTypeRateField>();

        /// <summary>
        /// Sets the maximum number of <see cref="RfcTypeRate"/> items returned per request in the <see cref="RfcTypeRateQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RfcTypeQuery"/> in the <see cref="RfcTypeRateQuery"/>, allowing related <see cref="RfcType"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RfcTypeQuery? RfcType { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceOfferingQuery"/> in the <see cref="RfcTypeRateQuery"/>, allowing related <see cref="ServiceOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery? ServiceOffering { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RfcTypeRateQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RfcTypeRateQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (RfcType is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RfcType)))
                query.SelectRfcType(RfcType);

            if (ServiceOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceOffering)))
                query.SelectServiceOffering(ServiceOffering);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
