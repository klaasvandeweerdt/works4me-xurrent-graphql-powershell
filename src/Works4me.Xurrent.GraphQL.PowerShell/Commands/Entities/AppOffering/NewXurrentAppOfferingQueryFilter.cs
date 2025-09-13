using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new filter object for building Xurrent <see cref="AppOffering"/> queries.<br/>
    /// This cmdlet is used to define filter conditions that can be applied when querying <see cref="AppOffering"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAppOfferingQueryFilter", DefaultParameterSetName = "None")]
    [OutputType(typeof(QueryFilter<AppOfferingFilterField>))]
    public class NewXurrentAppOfferingQueryFilter : XurrentQueryFilterCmdletBase<AppOfferingFilterField>
    {
    }
}
