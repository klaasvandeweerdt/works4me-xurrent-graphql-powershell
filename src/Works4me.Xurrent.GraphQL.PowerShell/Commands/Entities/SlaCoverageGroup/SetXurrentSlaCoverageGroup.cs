using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="SlaCoverageGroup"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="SlaCoverageGroupUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="SlaCoverageGroupUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentSlaCoverageGroup")]
    [OutputType(typeof(SlaCoverageGroupUpdatePayload))]
    public class SetXurrentSlaCoverageGroup : XurrentCmdletBase
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Any additional information about the SLA coverage group.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? DescriptionAttachments { get; set; }

        /// <summary>
        /// Whether the SLA coverage group may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// The name of the SLA coverage group.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The phrase used to filter the people.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? SearchPhrase { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="SlaCoverageGroupQuery"/> that defines which fields of the <see cref="SlaCoverageGroupUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public SlaCoverageGroupQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="SlaCoverageGroupUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="SlaCoverageGroupUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            SlaCoverageGroupUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(DescriptionAttachments)))
                input.DescriptionAttachments = DescriptionAttachments is null ? new() : new(DescriptionAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SearchPhrase)))
                input.SearchPhrase = SearchPhrase;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                SlaCoverageGroupUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentSlaCoverageGroup), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentSlaCoverageGroup), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
