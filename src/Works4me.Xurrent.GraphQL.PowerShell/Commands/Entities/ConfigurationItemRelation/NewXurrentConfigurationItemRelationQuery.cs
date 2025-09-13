using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ConfigurationItemRelationQuery"/> object for building Xurrent <see cref="ConfigurationItemRelation"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ConfigurationItemRelation"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentConfigurationItemRelationQuery")]
    [OutputType(typeof(ConfigurationItemRelationQuery))]
    public class NewXurrentConfigurationItemRelationQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ConfigurationItemRelation"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ConfigurationItemRelation"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemRelationField[] Properties { get; set; } = Array.Empty<ConfigurationItemRelationField>();

        /// <summary>
        /// Sets the maximum number of <see cref="ConfigurationItemRelation"/> items returned per request in the <see cref="ConfigurationItemRelationQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ConfigurationItemQuery"/> in the <see cref="ConfigurationItemRelationQuery"/>, allowing related <see cref="ConfigurationItem"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery? ConfigurationItem { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ConfigurationItemRelationQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ConfigurationItemRelationQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (ConfigurationItem is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ConfigurationItem)))
                query.SelectConfigurationItem(ConfigurationItem);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
