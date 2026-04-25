using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RfcTypeActivityIDQuery"/> object for building Xurrent <see cref="RfcTypeActivityID"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="RfcTypeActivityID"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRfcTypeActivityIDQuery")]
    [OutputType(typeof(RfcTypeActivityIDQuery))]
    public class NewXurrentRfcTypeActivityIDQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="RfcTypeActivityID"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="RfcTypeActivityID"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RfcTypeActivityIDField[] Properties { get; set; } = Array.Empty<RfcTypeActivityIDField>();

        /// <summary>
        /// Sets the maximum number of <see cref="RfcTypeActivityID"/> items returned per request in the <see cref="RfcTypeActivityIDQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RfcTypeQuery"/> in the <see cref="RfcTypeActivityIDQuery"/>, allowing related <see cref="RfcType"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RfcTypeQuery? RfcType { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RfcTypeActivityIDQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RfcTypeActivityIDQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (RfcType is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RfcType)))
                query.SelectRfcType(RfcType);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
