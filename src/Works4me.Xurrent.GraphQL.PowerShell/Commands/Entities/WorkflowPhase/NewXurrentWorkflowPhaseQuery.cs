using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="WorkflowPhaseQuery"/> object for building Xurrent <see cref="WorkflowPhase"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="WorkflowPhase"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentWorkflowPhaseQuery")]
    [OutputType(typeof(WorkflowPhaseQuery))]
    public class NewXurrentWorkflowPhaseQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="WorkflowPhase"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="WorkflowPhase"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowPhaseField[] Properties { get; set; } = Array.Empty<WorkflowPhaseField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="WorkflowPhaseQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            WorkflowPhaseQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
