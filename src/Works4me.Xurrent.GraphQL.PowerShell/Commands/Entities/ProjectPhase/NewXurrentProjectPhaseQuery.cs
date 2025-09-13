using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProjectPhaseQuery"/> object for building Xurrent <see cref="ProjectPhase"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ProjectPhase"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectPhaseQuery")]
    [OutputType(typeof(ProjectPhaseQuery))]
    public class NewXurrentProjectPhaseQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProjectPhase"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProjectPhase"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectPhaseField[] Properties { get; set; } = Array.Empty<ProjectPhaseField>();

        /// <summary>
        /// Sets the maximum number of <see cref="ProjectPhase"/> items returned per request in the <see cref="ProjectPhaseQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProjectPhaseQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectPhaseQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
