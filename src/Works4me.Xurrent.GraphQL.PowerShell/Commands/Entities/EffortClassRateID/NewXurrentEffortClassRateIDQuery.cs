using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="EffortClassRateIDQuery"/> object for building Xurrent <see cref="EffortClassRateID"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="EffortClassRateID"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentEffortClassRateIDQuery")]
    [OutputType(typeof(EffortClassRateIDQuery))]
    public class NewXurrentEffortClassRateIDQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="EffortClassRateID"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="EffortClassRateID"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateIDField[] Properties { get; set; } = Array.Empty<EffortClassRateIDField>();

        /// <summary>
        /// Sets the maximum number of <see cref="EffortClassRateID"/> items returned per request in the <see cref="EffortClassRateIDQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="EffortClassRateIDQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClass { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="EffortClassRateIDQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            EffortClassRateIDQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (EffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClass)))
                query.SelectEffortClass(EffortClass);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
