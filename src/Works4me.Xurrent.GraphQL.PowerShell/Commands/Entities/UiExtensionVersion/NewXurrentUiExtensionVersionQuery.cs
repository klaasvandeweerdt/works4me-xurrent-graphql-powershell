using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="UiExtensionVersionQuery"/> object for building Xurrent <see cref="UiExtensionVersion"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="UiExtensionVersion"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentUiExtensionVersionQuery")]
    [OutputType(typeof(UiExtensionVersionQuery))]
    public class NewXurrentUiExtensionVersionQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="UiExtensionVersion"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="UiExtensionVersion"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionVersionField[] Properties { get; set; } = Array.Empty<UiExtensionVersionField>();

        /// <summary>
        /// Includes a nested <see cref="UiExtensionQuery"/> in the <see cref="UiExtensionVersionQuery"/>, allowing related <see cref="UiExtension"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery? UiExtension { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="UiExtensionVersionQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            UiExtensionVersionQuery query = new();

            if (UiExtension is not null && MyInvocation.BoundParameters.ContainsKey(nameof(UiExtension)))
                query.SelectUiExtension(UiExtension);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
