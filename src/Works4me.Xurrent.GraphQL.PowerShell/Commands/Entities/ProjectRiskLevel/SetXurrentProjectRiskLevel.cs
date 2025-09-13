using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Updates an existing <see cref="ProjectRiskLevel"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="ProjectRiskLevelUpdateInput"/> from the provided parameters, executes the operation, and returns a <see cref="ProjectRiskLevelUpdatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "XurrentProjectRiskLevel")]
    [OutputType(typeof(ProjectRiskLevelUpdatePayload))]
    public class SetXurrentProjectRiskLevel : XurrentCmdletBase
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
        /// A very short description of the project risk level, for example "Risk of Failure is Significant".
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Whether the project risk level may not be related to any more projects.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Any additional information about the project risk level that might prove useful, especially for project managers when they need to decide which project risk level to select for a project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public string? Information { get; set; }

        /// <summary>
        /// The attachments used in the information field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[]? InformationAttachments { get; set; }

        /// <summary>
        /// The name of the project risk level. Ideally the name of a project risk level consists of a single word, such as "Significant".
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The position that the project risk level takes when it is displayed in a sorted list.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public long? Position { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProjectRiskLevelQuery"/> that defines which fields of the <see cref="ProjectRiskLevelUpdatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public ProjectRiskLevelQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="ProjectRiskLevelUpdateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="ProjectRiskLevelUpdatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProjectRiskLevelUpdateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
                input.Id = Id;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

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

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Position)))
                input.Position = Position;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Source)))
                input.Source = Source;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(SourceID)))
                input.SourceID = SourceID;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                ProjectRiskLevelUpdatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentProjectRiskLevel), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(SetXurrentProjectRiskLevel), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
