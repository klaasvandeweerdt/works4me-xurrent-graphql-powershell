using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProjectTaskTemplateQuery"/> object for building Xurrent <see cref="ProjectTaskTemplate"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="ProjectTaskTemplate"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectTaskTemplateQuery")]
    [OutputType(typeof(ProjectTaskTemplateQuery))]
    public class NewXurrentProjectTaskTemplateQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProjectTaskTemplate"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProjectTaskTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateField[] Properties { get; set; } = Array.Empty<ProjectTaskTemplateField>();

        /// <summary>
        /// Filters the query to return only the <see cref="ProjectTaskTemplate"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="ProjectTaskTemplate"/> view for the <see cref="ProjectTaskTemplateQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="ProjectTaskTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="ProjectTaskTemplate"/> results in the <see cref="ProjectTaskTemplateQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="ProjectTaskTemplate"/> results.<br/>
        /// If omitted, the <see cref="ProjectTaskTemplateQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="ProjectTaskTemplate"/> items returned per request in the <see cref="ProjectTaskTemplateQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="AgileBoard"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery? AgileBoard { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AgileBoardColumnQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="AgileBoardColumn"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery? AgileBoardColumn { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskTemplateAssignmentQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="ProjectTaskTemplateAssignment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateAssignmentQuery? Assignments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRules { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClass { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? InstructionsAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? NoteAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PdfDesignQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="PdfDesign"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PdfDesignQuery? PdfDesign { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTemplateQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="ProjectTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTemplateQuery? ProjectTemplates { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SkillPoolQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="SkillPool"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery? SkillPool { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Supplier { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ProjectTaskQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="ProjectTask"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery? Tasks { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TeamQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="Team"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery? Team { get; set; }

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="ProjectTaskTemplateQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{ProjectTaskTemplateFilterField}"/> conditions to the <see cref="ProjectTaskTemplateQuery"/>.<br/>
        /// Filters restrict which <see cref="ProjectTaskTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ProjectTaskTemplateFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="ProjectTaskTemplateQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="ProjectTaskTemplate"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProjectTaskTemplateQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectTaskTemplateQuery query = new();

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

            if (AgileBoard is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoard)))
                query.SelectAgileBoard(AgileBoard);

            if (AgileBoardColumn is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AgileBoardColumn)))
                query.SelectAgileBoardColumn(AgileBoardColumn);

            if (Assignments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Assignments)))
                query.SelectAssignments(Assignments);

            if (AutomationRules is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRules)))
                query.SelectAutomationRules(AutomationRules);

            if (EffortClass is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClass)))
                query.SelectEffortClass(EffortClass);

            if (InstructionsAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(InstructionsAttachments)))
                query.SelectInstructionsAttachments(InstructionsAttachments);

            if (NoteAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(NoteAttachments)))
                query.SelectNoteAttachments(NoteAttachments);

            if (PdfDesign is not null && MyInvocation.BoundParameters.ContainsKey(nameof(PdfDesign)))
                query.SelectPdfDesign(PdfDesign);

            if (ProjectTemplates is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ProjectTemplates)))
                query.SelectProjectTemplates(ProjectTemplates);

            if (SkillPool is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SkillPool)))
                query.SelectSkillPool(SkillPool);

            if (Supplier is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                query.SelectSupplier(Supplier);

            if (Tasks is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Tasks)))
                query.SelectTasks(Tasks);

            if (Team is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Team)))
                query.SelectTeam(Team);

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<ProjectTaskTemplateFilterField> filter in Filters)
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
