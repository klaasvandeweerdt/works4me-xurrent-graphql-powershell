using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AccountQuery"/> object for building Xurrent <see cref="Account"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Account"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAccountQuery")]
    [OutputType(typeof(AccountQuery))]
    public class NewXurrentAccountQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Account"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Account"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountField[] Properties { get; set; } = Array.Empty<AccountField>();

        /// <summary>
        /// Includes a nested <see cref="AccountDesignQuery"/> in the <see cref="AccountQuery"/>, allowing related <see cref="AccountDesign"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountDesignQuery? Design { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AccountQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? DirectoryAccount { get; set; }

        /// <summary>
        /// Includes a nested <see cref="OrganizationQuery"/> in the <see cref="AccountQuery"/>, allowing related <see cref="Organization"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery? Organization { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AccountQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AccountQuery query = new();

            if (Design is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Design)))
                query.SelectDesign(Design);

            if (DirectoryAccount is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DirectoryAccount)))
                query.SelectDirectoryAccount(DirectoryAccount);

            if (Organization is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Organization)))
                query.SelectOrganization(Organization);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
