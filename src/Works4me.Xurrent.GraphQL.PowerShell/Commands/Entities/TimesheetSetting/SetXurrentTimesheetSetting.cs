using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="TimesheetSetting"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="TimesheetSettingUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="TimesheetSettingUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentTimesheetSetting")]
    [OutputType(typeof(TimesheetSettingUpdatePayload))]
    public class SetXurrentTimesheetSetting : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Whether people of the related organizations need to be able to register time entries for the time allocations that are linked to their organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public bool? AllocationTimeTracking { get; set; }

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single day than the amount of time specified in the Workday field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public bool? AllowWorkdayOvertime { get; set; }

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single week than the amount of time specified in the Workweek field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? AllowWorkweekOvertime { get; set; }

        /// <summary>
        /// Whether the Time spent field needs to be available in requests, problems and tasks for specialists of the related organizations to specify how long they have worked on their assignments.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? AssignmentTimeTracking { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the timesheet settings may no longer be related to any more organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Identifiers of effort classes of the timesheet setting.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string[]? EffortClassIds { get; set; }

        /// <summary>
        /// The name of the timesheet settings.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Whether an email notification should be sent to each person who registered fewer hours for the past week than the workweek hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public bool? NotifyOnIncomplete { get; set; }

        /// <summary>
        /// Identifiers of organizations of the timesheet setting.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string[]? OrganizationIds { get; set; }

        /// <summary>
        /// The minimum amount percentage of a workday that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This percentage of a workday is also the increment by which they can increase this minimum percentage of a workday.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingPercentageIncrement? PercentageIncrement { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public string? ProblemEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        public string? ProjectTaskEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        public string? RequestEffortClassId { get; set; }

        /// <summary>
        /// Whether the Note field needs to become required, when someone in an organization linked to the timesheet settings registers time on a request, problem or task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        public bool? RequireNote { get; set; }

        /// <summary>
        /// Whether the Time entry description field needs to become required, when someone in an organization linked to the timesheet settings registers time on a request, problem, task or on a time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        public bool? RequireTimeEntryDescription { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a workflow task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        public string? TaskEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationEffortClassId { get; set; }

        /// <summary>
        /// The minimum amount of time that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This amount of time is also the increment by which they can increase this minimum amount of time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingTimeIncrement? TimeIncrement { get; set; }

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked need to register their time in hours and minutes, or as a percentage of a workday.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingUnit? Unit { get; set; }

        /// <summary>
        /// The duration of a workday in minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipelineByPropertyName = true)]
        public long? Workday { get; set; }

        /// <summary>
        /// The duration of a workweek in minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipelineByPropertyName = true)]
        public long? Workweek { get; set; }

        /// <summary>
        /// Specifies the <see cref="TimesheetSettingQuery"/> that defines which fields of the <see cref="TimesheetSettingUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="TimesheetSettingUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="TimesheetSettingUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TimesheetSettingUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AllocationTimeTracking)))
                input.AllocationTimeTracking = AllocationTimeTracking;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AllowWorkdayOvertime)))
                input.AllowWorkdayOvertime = AllowWorkdayOvertime;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AllowWorkweekOvertime)))
                input.AllowWorkweekOvertime = AllowWorkweekOvertime;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AssignmentTimeTracking)))
                input.AssignmentTimeTracking = AssignmentTimeTracking;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(EffortClassIds)))
                input.EffortClassIds = EffortClassIds is null ? new() : new(EffortClassIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(NotifyOnIncomplete)))
                input.NotifyOnIncomplete = NotifyOnIncomplete;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrganizationIds)))
                input.OrganizationIds = OrganizationIds is null ? new() : new(OrganizationIds);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PercentageIncrement)))
                input.PercentageIncrement = PercentageIncrement;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProblemEffortClassId)))
                input.ProblemEffortClassId = ProblemEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ProjectTaskEffortClassId)))
                input.ProjectTaskEffortClassId = ProjectTaskEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequestEffortClassId)))
                input.RequestEffortClassId = RequestEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequireNote)))
                input.RequireNote = RequireNote;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(RequireTimeEntryDescription)))
                input.RequireTimeEntryDescription = RequireTimeEntryDescription;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TaskEffortClassId)))
                input.TaskEffortClassId = TaskEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeAllocationEffortClassId)))
                input.TimeAllocationEffortClassId = TimeAllocationEffortClassId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TimeIncrement)))
                input.TimeIncrement = TimeIncrement;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Unit)))
                input.Unit = Unit;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Workday)))
                input.Workday = Workday;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Workweek)))
                input.Workweek = Workweek;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                TimesheetSettingUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentTimesheetSetting), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentTimesheetSetting), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
