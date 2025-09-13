using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="SlaCoverageGroupQuery"/> object for building Xurrent <see cref="SlaCoverageGroup"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="SlaCoverageGroup"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentSlaCoverageGroupQuery")]
    [OutputType(typeof(SlaCoverageGroupQuery))]
    public class NewXurrentSlaCoverageGroupQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="SlaCoverageGroup"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="SlaCoverageGroup"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaCoverageGroupField[] Properties { get; set; } = Array.Empty<SlaCoverageGroupField>();

        /// <summary>
        /// Sets the maximum number of <see cref="SlaCoverageGroup"/> items returned per request in the <see cref="SlaCoverageGroupQuery"/>.<br/>
        /// Valid range: 1–100; values outside this range are rejected.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? ItemsPerRequest { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="SlaCoverageGroupQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="AttachmentQuery"/> in the <see cref="SlaCoverageGroupQuery"/>, allowing related <see cref="Attachment"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery? DescriptionAttachments { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="SlaCoverageGroupQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? People { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceLevelAgreementQuery"/> in the <see cref="SlaCoverageGroupQuery"/>, allowing related <see cref="ServiceLevelAgreement"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery? Slas { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="SlaCoverageGroupQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SlaCoverageGroupQuery query = new();

            if (ItemsPerRequest is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ItemsPerRequest)))
                query.ItemsPerRequest(ItemsPerRequest.Value);

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (DescriptionAttachments is not null && MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                query.SelectDescriptionAttachments(DescriptionAttachments);

            if (People is not null && MyInvocation.BoundParameters.ContainsKey(nameof(People)))
                query.SelectPeople(People);

            if (Slas is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Slas)))
                query.SelectSlas(Slas);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
