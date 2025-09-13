using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AppOfferingAutomationRuleQuery"/> object for building Xurrent <see cref="AppOfferingAutomationRule"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AppOfferingAutomationRule"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAppOfferingAutomationRuleQuery")]
    [OutputType(typeof(AppOfferingAutomationRuleQuery))]
    public class NewXurrentAppOfferingAutomationRuleQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AppOfferingAutomationRule"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AppOfferingAutomationRule"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingAutomationRuleField[] Properties { get; set; } = Array.Empty<AppOfferingAutomationRuleField>();

        /// <summary>
        /// Sets the maximum number of <see cref="AppOfferingAutomationRule"/> items returned per request in the <see cref="AppOfferingAutomationRuleQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AppOfferingAutomationRuleQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleActionQuery"/> in the <see cref="AppOfferingAutomationRuleQuery"/>, allowing related <see cref="AutomationRuleAction"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleActionQuery? Actions { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AppOfferingQuery"/> in the <see cref="AppOfferingAutomationRuleQuery"/>, allowing related <see cref="AppOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingQuery? AppOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AutomationRuleExpressionQuery"/> in the <see cref="AppOfferingAutomationRuleQuery"/>, allowing related <see cref="AutomationRuleExpression"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleExpressionQuery? Expressions { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AppOfferingAutomationRuleQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingAutomationRuleQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Actions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Actions)))
                query.SelectActions(Actions);

            if (AppOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(AppOffering)))
                query.SelectAppOffering(AppOffering);

            if (Expressions is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Expressions)))
                query.SelectExpressions(Expressions);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
