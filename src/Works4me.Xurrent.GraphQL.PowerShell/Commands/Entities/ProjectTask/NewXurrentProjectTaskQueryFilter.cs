using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new filter object for building Xurrent <see cref="ProjectTask"/> queries.<br/>
    /// This cmdlet is used to define filter conditions that can be applied when querying <see cref="ProjectTask"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProjectTaskQueryFilter", DefaultParameterSetName = "None")]
    [OutputType(typeof(QueryFilter<ProjectTaskFilterField>))]
    public class NewXurrentProjectTaskQueryFilter : XurrentQueryFilterCmdletBase<ProjectTaskFilterField>
    {
    }
}
