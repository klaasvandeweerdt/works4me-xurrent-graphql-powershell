using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Filters;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AttachmentStorageQuery"/> object for building Xurrent <see cref="AttachmentStorage"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AttachmentStorage"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAttachmentStorageQuery")]
    [OutputType(typeof(AttachmentStorageQuery))]
    public class NewXurrentAttachmentStorageQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AttachmentStorage"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AttachmentStorage"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentStorageField[] Properties { get; set; } = Array.Empty<AttachmentStorageField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AttachmentStorageQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AttachmentStorageQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
