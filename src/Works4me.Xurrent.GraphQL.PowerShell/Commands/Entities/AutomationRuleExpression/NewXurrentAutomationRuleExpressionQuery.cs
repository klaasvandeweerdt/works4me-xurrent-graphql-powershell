using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AutomationRuleExpressionQuery"/> object for building Xurrent <see cref="AutomationRuleExpression"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AutomationRuleExpression"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAutomationRuleExpressionQuery")]
    [OutputType(typeof(AutomationRuleExpressionQuery))]
    public class NewXurrentAutomationRuleExpressionQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AutomationRuleExpression"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AutomationRuleExpression"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleExpressionField[] Properties { get; set; } = Array.Empty<AutomationRuleExpressionField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AutomationRuleExpressionQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AutomationRuleExpressionQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
