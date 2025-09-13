using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="CustomCollectionElement"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="CustomCollectionElementUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="CustomCollectionElementUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentCustomCollectionElement")]
    [OutputType(typeof(CustomCollectionElementUpdatePayload))]
    public class SetXurrentCustomCollectionElement : XurrentCmdletBase
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
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields' values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? CustomFieldsAttachments { get; set; }

        /// <summary>
        /// Description of the collection element.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Whether the collection element may not be referenced from custom fields of other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Any additional information about the element that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Information { get; set; }

        /// <summary>
        /// The attachments used in the information field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? InformationAttachments { get; set; }

        /// <summary>
        /// Name of the collection element.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The Reference field defaults to the Name field value, written in lower case characters and with all spaces replaced by the underscore character.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? Reference { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="CustomCollectionElementQuery"/> that defines which fields of the <see cref="CustomCollectionElementUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipelineByPropertyName = true)]
        public CustomCollectionElementQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="CustomCollectionElementUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="CustomCollectionElementUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CustomCollectionElementUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                input.CustomFields = CustomFields;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CustomFieldsAttachments)))
                input.CustomFieldsAttachments = CustomFieldsAttachments is null ? new() : new(CustomFieldsAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Disabled)))
                input.Disabled = Disabled;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Information)))
                input.Information = Information;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(InformationAttachments)))
                input.InformationAttachments = InformationAttachments is null ? new() : new(InformationAttachments);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Reference)))
                input.Reference = Reference;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                CustomCollectionElementUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentCustomCollectionElement), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentCustomCollectionElement), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
