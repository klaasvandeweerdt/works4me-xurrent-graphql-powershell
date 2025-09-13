using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="TaskApprovalQuery"/> object for building Xurrent <see cref="TaskApproval"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="TaskApproval"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentTaskApprovalQuery")]
    [OutputType(typeof(TaskApprovalQuery))]
    public class NewXurrentTaskApprovalQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="TaskApproval"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="TaskApproval"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskApprovalField[] Properties { get; set; } = Array.Empty<TaskApprovalField>();

        /// <summary>
        /// Sets the maximum number of <see cref="TaskApproval"/> items returned per request in the <see cref="TaskApprovalQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="TaskApprovalQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Approver { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="TaskApprovalQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? Attachment { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="TaskApprovalQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            TaskApprovalQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Approver is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Approver)))
                query.SelectApprover(Approver);

            if (Attachment is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Attachment)))
                query.SelectAttachment(Attachment);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
