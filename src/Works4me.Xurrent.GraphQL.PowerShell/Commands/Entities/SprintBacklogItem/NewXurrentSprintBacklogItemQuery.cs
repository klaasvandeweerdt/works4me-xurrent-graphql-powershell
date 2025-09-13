using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SprintBacklogItemQuery"/> object for building Xurrent <see cref="SprintBacklogItem"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="SprintBacklogItem"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSprintBacklogItemQuery")]
    [OutputType(typeof(SprintBacklogItemQuery))]
    public class NewXurrentSprintBacklogItemQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SprintBacklogItem"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SprintBacklogItem"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintBacklogItemField[] Properties { get; set; } = Array.Empty<SprintBacklogItemField>();

        /// <summary>
        /// Sets the maximum number of <see cref="SprintBacklogItem"/> items returned per request in the <see cref="SprintBacklogItemQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related Record data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? RecordAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related Record data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? RecordAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related Record data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? RecordAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related Record data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? RecordAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SprintQuery"/> in the <see cref="SprintBacklogItemQuery"/>, allowing related <see cref="Sprint"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintQuery? Sprint { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SprintBacklogItemQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SprintBacklogItemQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (RecordAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsProblem)))
                query.SelectRecord(RecordAsProblem);

            if (RecordAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsProjectTask)))
                query.SelectRecord(RecordAsProjectTask);

            if (RecordAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsRequest)))
                query.SelectRecord(RecordAsRequest);

            if (RecordAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsWorkflowTask)))
                query.SelectRecord(RecordAsWorkflowTask);

            if (Sprint is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Sprint)))
                query.SelectSprint(Sprint);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
