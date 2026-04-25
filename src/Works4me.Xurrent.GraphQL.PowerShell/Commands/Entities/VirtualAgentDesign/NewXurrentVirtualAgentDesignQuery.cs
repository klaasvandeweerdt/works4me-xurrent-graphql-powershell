using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="VirtualAgentDesignQuery"/> object for building Xurrent <see cref="VirtualAgentDesign"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="VirtualAgentDesign"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentVirtualAgentDesignQuery")]
    [OutputType(typeof(VirtualAgentDesignQuery))]
    public class NewXurrentVirtualAgentDesignQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="VirtualAgentDesign"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="VirtualAgentDesign"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public VirtualAgentDesignField[] Properties { get; set; } = Array.Empty<VirtualAgentDesignField>();

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="VirtualAgentDesignQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="VirtualAgentDesignQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            VirtualAgentDesignQuery query = new();

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
