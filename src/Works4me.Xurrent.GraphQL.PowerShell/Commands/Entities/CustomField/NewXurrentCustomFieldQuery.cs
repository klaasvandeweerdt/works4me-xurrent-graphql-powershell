using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="CustomFieldQuery"/> object for building Xurrent <see cref="CustomField"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="CustomField"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentCustomFieldQuery")]
    [OutputType(typeof(CustomFieldQuery))]
    public class NewXurrentCustomFieldQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="CustomField"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="CustomField"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldField[] Properties { get; set; } = Array.Empty<CustomFieldField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="CustomFieldQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CustomFieldQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
