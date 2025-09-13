using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SkillPoolQuery"/> object for building Xurrent <see cref="SkillPool"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="SkillPool"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSkillPoolQuery")]
    [OutputType(typeof(SkillPoolQuery))]
    public class NewXurrentSkillPoolQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SkillPool"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SkillPool"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolField[] Properties { get; set; } = Array.Empty<SkillPoolField>();

        /// <summary>
        /// Filters the query to return only the <see cref="SkillPool"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="SkillPool"/> view for the <see cref="SkillPoolQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="SkillPool"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="SkillPool"/> results in the <see cref="SkillPoolQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="SkillPool"/> results.<br/>
        /// If omitted, the <see cref="SkillPoolQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="SkillPool"/> items returned per request in the <see cref="SkillPoolQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SkillPoolQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="EffortClassQuery"/> in the <see cref="SkillPoolQuery"/>, allowing related <see cref="EffortClass"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery? EffortClasses { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="SkillPoolQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Manager { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="SkillPoolQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Members { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="SkillPoolQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? RemarksAttachments { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{SkillPoolFilterField}"/> conditions to the <see cref="SkillPoolQuery"/>.<br/>
        /// Filters restrict which <see cref="SkillPool"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<SkillPoolFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="SkillPoolQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="SkillPool"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SkillPoolQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SkillPoolQuery query = new();

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

            if (EffortClasses is not null && MyInvocation.BoundParameters.ContainsKey(nameof(EffortClasses)))
                query.SelectEffortClasses(EffortClasses);

            if (Manager is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                query.SelectManager(Manager);

            if (Members is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Members)))
                query.SelectMembers(Members);

            if (RemarksAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RemarksAttachments)))
                query.SelectRemarksAttachments(RemarksAttachments);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<SkillPoolFilterField> filter in Filters)
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
