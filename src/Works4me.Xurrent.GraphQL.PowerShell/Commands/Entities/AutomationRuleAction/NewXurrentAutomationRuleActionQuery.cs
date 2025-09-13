using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AutomationRuleActionQuery"/> object for building Xurrent <see cref="AutomationRuleAction"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AutomationRuleAction"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAutomationRuleActionQuery")]
    [OutputType(typeof(AutomationRuleActionQuery))]
    public class NewXurrentAutomationRuleActionQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AutomationRuleAction"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AutomationRuleAction"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleActionField[] Properties { get; set; } = Array.Empty<AutomationRuleActionField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AutomationRuleActionQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AutomationRuleActionQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
