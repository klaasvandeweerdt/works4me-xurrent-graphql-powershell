using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="CiStagedChangeQuery"/> object for building Xurrent <see cref="CiStagedChange"/> queries.<br/>
    /// This cmdlet is used to define the fields, filters, sorting, and related objects to include when querying <see cref="CiStagedChange"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentCiStagedChangeQuery")]
    [OutputType(typeof(CiStagedChangeQuery))]
    public class NewXurrentCiStagedChangeQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="CiStagedChange"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="CiStagedChange"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CiStagedChangeField[] Properties { get; set; } = Array.Empty<CiStagedChangeField>();

        /// <summary>
        /// Filters the query to return only the <see cref="CiStagedChange"/> with the specified identifier.<br/>
        /// When this parameter is used, all other filter conditions are ignored.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? WithId { get; set; }

        /// <summary>
        /// Selects a predefined <see cref="CiStagedChange"/> view for the <see cref="CiStagedChangeQuery"/>.<br/>
        /// A view represents a predefined projection that controls how <see cref="CiStagedChange"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CiStagedChangeView? View { get; set; }

        /// <summary>
        /// Specifies the field used to order <see cref="CiStagedChange"/> results in the <see cref="CiStagedChangeQuery"/>.<br/>
        /// Combine with <see cref="SortOrder"/> to control the sort direction.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CiStagedChangeOrderField? OrderBy { get; set; }

        /// <summary>
        /// Specifies the sort direction when ordering <see cref="CiStagedChange"/> results.<br/>
        /// If omitted, the <see cref="CiStagedChangeQuery"/> defaults to ascending order.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// Sets the maximum number of <see cref="CiStagedChange"/> items returned per request in the <see cref="CiStagedChangeQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="CiStagedChangeQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleQuery"/> in the <see cref="CiStagedChangeQuery"/>, allowing related <see cref="AutomationRule"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery? AutomationRule { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="CiStagedChangeQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? Ci { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="CiStagedChangeQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? CreatedBy { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="CiStagedChangeQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? ReviewedBy { get; set; }

        /// <summary>
        /// Applies one or more <see cref="QueryFilter{CiStagedChangeFilterField}"/> conditions to the <see cref="CiStagedChangeQuery"/>.<br/>
        /// Filters restrict which <see cref="CiStagedChange"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<CiStagedChangeFilterField>[]? Filters { get; set; }

        /// <summary>
        /// Adds a free-form search filter to the <see cref="CiStagedChangeQuery"/>.<br/>
        /// This parameter enables simple text-based filtering of <see cref="CiStagedChange"/> results.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string? Search { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="CiStagedChangeQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CiStagedChangeQuery query = new();

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

            if (AutomationRule is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AutomationRule)))
                query.SelectAutomationRule(AutomationRule);

            if (Ci is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Ci)))
                query.SelectCi(Ci);

            if (CreatedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(CreatedBy)))
                query.SelectCreatedBy(CreatedBy);

            if (ReviewedBy is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ReviewedBy)))
                query.SelectReviewedBy(ReviewedBy);

            if (Filters is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Filters)))
            {
                foreach (QueryFilter<CiStagedChangeFilterField> filter in Filters)
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
