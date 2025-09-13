using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RateLimitQuery"/> object for building Xurrent <see cref="RateLimit"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="RateLimit"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRateLimitQuery")]
    [OutputType(typeof(RateLimitQuery))]
    public class NewXurrentRateLimitQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="RateLimit"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="RateLimit"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RateLimitField[] Properties { get; set; } = Array.Empty<RateLimitField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RateLimitQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RateLimitQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
