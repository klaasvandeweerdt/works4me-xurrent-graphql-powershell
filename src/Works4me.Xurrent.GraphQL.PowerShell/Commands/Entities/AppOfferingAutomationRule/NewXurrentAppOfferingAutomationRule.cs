using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AppOfferingAutomationRule"/> through the Xurrent GraphQL API.<br/>
    /// This cmdlet constructs a <see cref="AppOfferingAutomationRuleCreateInput"/> from the provided parameters, executes the operation, and returns a <see cref="AppOfferingAutomationRuleCreatePayload"/> describing the result.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAppOfferingAutomationRule")]
    [OutputType(typeof(AppOfferingAutomationRuleCreatePayload))]
    public class NewXurrentAppOfferingAutomationRule : XurrentCmdletBase
    {
        /// <summary>
        /// Identifier of the app offering the rule belongs to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AppOfferingId { get; set; } = string.Empty;

        /// <summary>
        /// The Condition field is used to define the condition that needs to be met in order for the update action(s) of the rule to be performed. For example: is_assigned and !badge.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Condition { get; set; } = string.Empty;

        /// <summary>
        /// The name of the automation rule.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The Trigger field is used to specify when the automation rule is to be triggered, for example on status update or on note added.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Trigger { get; set; } = string.Empty;

        /// <summary>
        /// The Actions field is used to define actions that should be executed when the condition of the automation rule is met.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        public AutomationRuleActionInput[]? Actions { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// A high-level description of the automation rule's function.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The Expressions field is used to define expressions that can subsequently be used to define the rule's conditions and the update action(s) that the rule is to perform.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipelineByPropertyName = true)]
        public AutomationRuleExpressionInput[]? Expressions { get; set; }

        /// <summary>
        /// The record type this rule is linked to.<br/>
        /// Valid values are:<br/>
        /// • request.<br/>
        /// • task.<br/>
        /// • ci.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipelineByPropertyName = true)]
        public string? Generic { get; set; }

        /// <summary>
        /// The Position field dictates the order in which the automation rule is executed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipelineByPropertyName = true)]
        public long? Position { get; set; }

        /// <summary>
        /// Specifies the <see cref="AppOfferingAutomationRuleQuery"/> that defines which fields of the <see cref="AppOfferingAutomationRuleCreatePayload"/> are returned by the mutation.<br/>
        /// If omitted, a default selection is used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipelineByPropertyName = true)]
        public AppOfferingAutomationRuleQuery ResponseQuery { get; set; } = new();

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the mutation by constructing a <see cref="AppOfferingAutomationRuleCreateInput"/> from the bound parameters, submitting it with the provided or default client, and writing the resulting <see cref="AppOfferingAutomationRuleCreatePayload"/> to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AppOfferingAutomationRuleCreateInput input = new();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(AppOfferingId)))
                input.AppOfferingId = AppOfferingId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Condition)))
                input.Condition = Condition;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                input.Name = Name;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Trigger)))
                input.Trigger = Trigger;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Actions)))
                input.Actions = Actions is null ? new() : new(Actions);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ClientMutationId)))
                input.ClientMutationId = ClientMutationId;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                input.Description = Description;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Expressions)))
                input.Expressions = Expressions is null ? new() : new(Expressions);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Generic)))
                input.Generic = Generic;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Position)))
                input.Position = Position;

            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AppOfferingAutomationRuleCreatePayload result = client.Client.MutationAsync(input, ResponseQuery).GetAwaiter().GetResult();
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAppOfferingAutomationRule), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAppOfferingAutomationRule), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
