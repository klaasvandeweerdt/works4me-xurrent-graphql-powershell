using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="InboundEmailQuery"/> object for building Xurrent <see cref="InboundEmail"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="InboundEmail"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentInboundEmailQuery")]
    [OutputType(typeof(InboundEmailQuery))]
    public class NewXurrentInboundEmailQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="InboundEmail"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="InboundEmail"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InboundEmailField[] Properties { get; set; } = Array.Empty<InboundEmailField>();

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Note { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? RecordAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Project"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery? RecordAsProject { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? RecordAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ReleaseQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Release"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery? RecordAsRelease { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? RecordAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RiskQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Risk"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery? RecordAsRisk { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="Workflow"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery? RecordAsWorkflow { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="InboundEmailQuery"/>, allowing related Record data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? RecordAsWorkflowTask { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="InboundEmailQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            InboundEmailQuery query = new();

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Note is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                query.SelectNote(Note);

            if (RecordAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsProblem)))
                query.SelectRecord(RecordAsProblem);

            if (RecordAsProject is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsProject)))
                query.SelectRecord(RecordAsProject);

            if (RecordAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsProjectTask)))
                query.SelectRecord(RecordAsProjectTask);

            if (RecordAsRelease is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsRelease)))
                query.SelectRecord(RecordAsRelease);

            if (RecordAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsRequest)))
                query.SelectRecord(RecordAsRequest);

            if (RecordAsRisk is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsRisk)))
                query.SelectRecord(RecordAsRisk);

            if (RecordAsWorkflow is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsWorkflow)))
                query.SelectRecord(RecordAsWorkflow);

            if (RecordAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RecordAsWorkflowTask)))
                query.SelectRecord(RecordAsWorkflowTask);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
