using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new filter object for building Xurrent <see cref="AutomationRule"/> queries.<br/>
    /// This cmdlet is used to define filter conditions that can be applied when querying <see cref="AutomationRule"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAutomationRuleQueryFilter", DefaultParameterSetName = "None")]
    [OutputType(typeof(QueryFilter<AutomationRuleFilterField>))]
    public class NewXurrentAutomationRuleQueryFilter : XurrentQueryFilterCmdletBase<AutomationRuleFilterField>
    {
    }
}
