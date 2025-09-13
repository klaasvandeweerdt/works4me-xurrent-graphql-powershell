using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProviderShopOrderLineQuery"/> object for building Xurrent <see cref="ProviderShopOrderLine"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ProviderShopOrderLine"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProviderShopOrderLineQuery")]
    [OutputType(typeof(ProviderShopOrderLineQuery))]
    public class NewXurrentProviderShopOrderLineQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProviderShopOrderLine"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProviderShopOrderLine"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProviderShopOrderLineField[] Properties { get; set; } = Array.Empty<ProviderShopOrderLineField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProviderShopOrderLineQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProviderShopOrderLineQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
