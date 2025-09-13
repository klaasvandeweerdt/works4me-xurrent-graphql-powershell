using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AppOfferingScopeQuery"/> object for building Xurrent <see cref="AppOfferingScope"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AppOfferingScope"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAppOfferingScopeQuery")]
    [OutputType(typeof(AppOfferingScopeQuery))]
    public class NewXurrentAppOfferingScopeQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AppOfferingScope"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AppOfferingScope"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingScopeField[] Properties { get; set; } = Array.Empty<AppOfferingScopeField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AppOfferingScopeQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingScopeQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
