using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new filter object for building Xurrent <see cref="Product"/> queries.<br/>
    /// This cmdlet is used to define filter conditions that can be applied when querying <see cref="Product"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProductQueryFilter", DefaultParameterSetName = "None")]
    [OutputType(typeof(QueryFilter<ProductFilterField>))]
    public class NewXurrentProductQueryFilter : XurrentQueryFilterCmdletBase<ProductFilterField>
    {
    }
}
