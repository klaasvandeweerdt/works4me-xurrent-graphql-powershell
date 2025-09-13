using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ActivityIDQuery"/> object for building Xurrent <see cref="ActivityID"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ActivityID"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentActivityIDQuery")]
    [OutputType(typeof(ActivityIDQuery))]
    public class NewXurrentActivityIDQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ActivityID"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ActivityID"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ActivityIDField[] Properties { get; set; } = Array.Empty<ActivityIDField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ActivityIDQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ActivityIDQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
