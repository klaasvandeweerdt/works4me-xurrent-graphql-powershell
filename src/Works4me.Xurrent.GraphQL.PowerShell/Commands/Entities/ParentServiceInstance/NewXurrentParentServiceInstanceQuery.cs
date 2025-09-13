using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ParentServiceInstanceQuery"/> object for building Xurrent <see cref="ParentServiceInstance"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ParentServiceInstance"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentParentServiceInstanceQuery")]
    [OutputType(typeof(ParentServiceInstanceQuery))]
    public class NewXurrentParentServiceInstanceQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ParentServiceInstance"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ParentServiceInstance"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ParentServiceInstanceField[] Properties { get; set; } = Array.Empty<ParentServiceInstanceField>();

        /// <summary>
        /// Sets the maximum number of <see cref="ParentServiceInstance"/> items returned per request in the <see cref="ParentServiceInstanceQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="ParentServiceInstanceQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstance { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ParentServiceInstanceQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ParentServiceInstanceQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (ServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstance)))
                query.SelectServiceInstance(ServiceInstance);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
