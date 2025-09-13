using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="PeriodQuery"/> object for building Xurrent <see cref="Period"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Period"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentPeriodQuery")]
    [OutputType(typeof(PeriodQuery))]
    public class NewXurrentPeriodQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Period"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Period"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PeriodField[] Properties { get; set; } = Array.Empty<PeriodField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="PeriodQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            PeriodQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
