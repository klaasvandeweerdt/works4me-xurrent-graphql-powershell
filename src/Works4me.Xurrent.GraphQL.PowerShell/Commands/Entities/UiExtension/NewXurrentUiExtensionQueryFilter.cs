using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new filter object for building Xurrent <see cref="UiExtension"/> queries.<br/>
    /// This cmdlet is used to define filter conditions that can be applied when querying <see cref="UiExtension"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentUiExtensionQueryFilter", DefaultParameterSetName = "None")]
    [OutputType(typeof(QueryFilter<UiExtensionFilterField>))]
    public class NewXurrentUiExtensionQueryFilter : XurrentQueryFilterCmdletBase<UiExtensionFilterField>
    {
    }
}
