using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="EffortClassRateQuery"/> object for building Xurrent <see cref="EffortClassRate"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="EffortClassRate"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentEffortClassRateQuery")]
    [OutputType(typeof(EffortClassRateQuery))]
    public class NewXurrentEffortClassRateQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="EffortClassRate"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="EffortClassRate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateField[] Properties { get; set; } = Array.Empty<EffortClassRateField>();

        /// <summary>
        /// Sets the maximum number of <see cref="EffortClassRate"/> items returned per request in the <see cref="EffortClassRateQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="EffortClassRateQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceOfferingQuery"/> in the <see cref="EffortClassRateQuery"/>, allowing related <see cref="ServiceOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery? ServiceOffering { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="EffortClassRateQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            EffortClassRateQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (EffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClass)))
                query.SelectEffortClass(EffortClass);

            if (ServiceOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceOffering)))
                query.SelectServiceOffering(ServiceOffering);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
