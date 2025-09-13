using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TimeEntryQuery"/> object for building Xurrent <see cref="TimeEntry"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="TimeEntry"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTimeEntryQuery")]
    [OutputType(typeof(TimeEntryQuery))]
    public class NewXurrentTimeEntryQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="TimeEntry"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="TimeEntry"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryField[] Properties { get; set; } = Array.Empty<TimeEntryField>();

        /// <summary>
        /// Filters the query to return only the <see cref="TimeEntry"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="TimeEntry"/> view for the <see cref="TimeEntryQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="TimeEntry"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="TimeEntry"/> results in the <see cref="TimeEntryQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="TimeEntry"/> results.<br/>
        /// If omitted, the <see cref="TimeEntryQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="TimeEntry"/> items returned per request in the <see cref="TimeEntryQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProblemQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related Assignment data, cast to <see cref="Problem"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery? AssignmentAsProblem { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related Assignment data, cast to <see cref="ProjectTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? AssignmentAsProjectTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="RequestQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related Assignment data, cast to <see cref="Request"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery? AssignmentAsRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="WorkflowTaskQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related Assignment data, cast to <see cref="WorkflowTask"/>, to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskQuery? AssignmentAsWorkflowTask { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Customer { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="NoteQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Note"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery? Note { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organization { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Person { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Service"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery? Service { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceInstanceQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="ServiceInstance"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery? ServiceInstance { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceLevelAgreementQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="ServiceLevelAgreement"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery? ServiceLevelAgreement { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TimeAllocationQuery"/> in the <see cref="TimeEntryQuery"/>, allowing related <see cref="TimeAllocation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationQuery? TimeAllocation { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{TimeEntryFilterField}"/> conditions to the <see cref="TimeEntryQuery"/>.<br/>
        /// Filters restrict which <see cref="TimeEntry"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TimeEntryFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="TimeEntryQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="TimeEntry"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="TimeEntryQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TimeEntryQuery query = new();

            if (WithId is not null && MyInvocation.BoundParameters.ContainsKey(nameof(WithId)))
                query.WithId(WithId);

            if (View is not null && MyInvocation.BoundParameters.ContainsKey(nameof(View)))
                query.View(View.Value);

            if (OrderBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(OrderBy)))
            {
                if (SortOrder is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                    query.OrderBy(OrderBy.Value, SortOrder.Value);
                else
                    query.OrderBy(OrderBy.Value, GraphQL.SortOrder.Ascending);
            }

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (AssignmentAsProblem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentAsProblem)))
                query.SelectAssignment(AssignmentAsProblem);

            if (AssignmentAsProjectTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentAsProjectTask)))
                query.SelectAssignment(AssignmentAsProjectTask);

            if (AssignmentAsRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentAsRequest)))
                query.SelectAssignment(AssignmentAsRequest);

            if (AssignmentAsWorkflowTask is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentAsWorkflowTask)))
                query.SelectAssignment(AssignmentAsWorkflowTask);

            if (Customer is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Customer)))
                query.SelectCustomer(Customer);

            if (EffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClass)))
                query.SelectEffortClass(EffortClass);

            if (Note is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                query.SelectNote(Note);

            if (Organization is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organization)))
                query.SelectOrganization(Organization);

            if (Person is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Person)))
                query.SelectPerson(Person);

            if (Service is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Service)))
                query.SelectService(Service);

            if (ServiceInstance is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceInstance)))
                query.SelectServiceInstance(ServiceInstance);

            if (ServiceLevelAgreement is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceLevelAgreement)))
                query.SelectServiceLevelAgreement(ServiceLevelAgreement);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            if (TimeAllocation is not null && MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocation)))
                query.SelectTimeAllocation(TimeAllocation);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<TimeEntryFilterField> filter in Filters)
                {
                    if (filter.BooleanValue is not null)
                        query.Where(filter.Property, filter.Operator, filter.BooleanValue.Value);
                    else if (filter.DateTimeValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.DateTimeValues);
                    else if (filter.IntegerValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.IntegerValues);
                    else if (filter.TextValues is not null)
                        query.Where(filter.Property, filter.Operator, filter.TextValues);
                    else
                        query.Where(filter.Property, filter.Operator);
                }
            }

            if (Search is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Search)))
                query.Search(Search);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
