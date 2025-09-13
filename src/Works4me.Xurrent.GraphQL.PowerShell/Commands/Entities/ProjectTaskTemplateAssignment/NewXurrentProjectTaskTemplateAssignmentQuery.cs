using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProjectTaskTemplateAssignmentQuery"/> object for building Xurrent <see cref="ProjectTaskTemplateAssignment"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ProjectTaskTemplateAssignment"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectTaskTemplateAssignmentQuery")]
    [OutputType(typeof(ProjectTaskTemplateAssignmentQuery))]
    public class NewXurrentProjectTaskTemplateAssignmentQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProjectTaskTemplateAssignment"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProjectTaskTemplateAssignment"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateAssignmentField[] Properties { get; set; } = Array.Empty<ProjectTaskTemplateAssignmentField>();

        /// <summary>
        /// Sets the maximum number of <see cref="ProjectTaskTemplateAssignment"/> items returned per request in the <see cref="ProjectTaskTemplateAssignmentQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="ProjectTaskTemplateAssignmentQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Assignee { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProjectTaskTemplateAssignmentQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectTaskTemplateAssignmentQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Assignee is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Assignee)))
                query.SelectAssignee(Assignee);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
