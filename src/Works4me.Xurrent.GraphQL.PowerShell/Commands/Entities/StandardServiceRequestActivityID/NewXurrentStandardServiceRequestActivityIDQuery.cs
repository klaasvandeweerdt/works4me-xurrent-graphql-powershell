using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="StandardServiceRequestActivityIDQuery"/> object for building Xurrent <see cref="StandardServiceRequestActivityID"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="StandardServiceRequestActivityID"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentStandardServiceRequestActivityIDQuery")]
    [OutputType(typeof(StandardServiceRequestActivityIDQuery))]
    public class NewXurrentStandardServiceRequestActivityIDQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="StandardServiceRequestActivityID"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="StandardServiceRequestActivityID"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestActivityIDField[] Properties { get; set; } = Array.Empty<StandardServiceRequestActivityIDField>();

        /// <summary>
        /// Sets the maximum number of <see cref="StandardServiceRequestActivityID"/> items returned per request in the <see cref="StandardServiceRequestActivityIDQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="StandardServiceRequestQuery"/> in the <see cref="StandardServiceRequestActivityIDQuery"/>, allowing related <see cref="StandardServiceRequest"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery? StandardServiceRequest { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="StandardServiceRequestActivityIDQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            StandardServiceRequestActivityIDQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (StandardServiceRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(StandardServiceRequest)))
                query.SelectStandardServiceRequest(StandardServiceRequest);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
