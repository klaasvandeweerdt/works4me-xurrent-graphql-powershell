using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AgileBoardColumnQuery"/> object for building Xurrent <see cref="AgileBoardColumn"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AgileBoardColumn"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAgileBoardColumnQuery")]
    [OutputType(typeof(AgileBoardColumnQuery))]
    public class NewXurrentAgileBoardColumnQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AgileBoardColumn"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AgileBoardColumn"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnField[] Properties { get; set; } = Array.Empty<AgileBoardColumnField>();

        /// <summary>
        /// Sets the maximum number of <see cref="AgileBoardColumn"/> items returned per request in the <see cref="AgileBoardColumnQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related <see cref="AgileBoard"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery? AgileBoard { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related Items data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? ItemsAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related Items data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? ItemsAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related Items data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? ItemsAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related Items data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? ItemsAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Member { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="AgileBoardColumnQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AgileBoardColumnQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AgileBoardColumnQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (AgileBoard is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoard)))
                query.SelectAgileBoard(AgileBoard);

            if (ItemsAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsAsProblem)))
                query.SelectItems(ItemsAsProblem);

            if (ItemsAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsAsProjectTask)))
                query.SelectItems(ItemsAsProjectTask);

            if (ItemsAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsAsRequest)))
                query.SelectItems(ItemsAsRequest);

            if (ItemsAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsAsWorkflowTask)))
                query.SelectItems(ItemsAsWorkflowTask);

            if (Member is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Member)))
                query.SelectMember(Member);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
