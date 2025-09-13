using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Tests whether any of the provided authentication tokens has sufficient remaining quota.<br />
    /// Writes <see langword="true"/> if at least one token exceeds both the minimum remaining rate limit and cost thresholds; otherwise writes <see langword="false"/>.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "XurrentClientTokenQuota")]
    [OutputType(typeof(bool))]
    public class TestXurrentClientTokenQuota : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for execution.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 0)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// The minimum remaining requests required on a token’s rate limit to qualify. The default value is 50.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1)]
        [ValidateNotNull]
        public int MinRateRemaining { get; set; } = 50;

        /// <summary>
        /// The minimum remaining cost budget required on a token to qualify. The default value is 100.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2)]
        [ValidateNotNull]
        public int MinCostRemaining { get; set; } = 100;

        /// <summary>
        /// Evaluates each token used by the client against the specified thresholds and writes the result to the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                bool result = false;
                foreach (AuthenticationToken token in client.Tokens)
                    result |= token.RequestLimit.Remaining > MinRateRemaining && token.CostLimit.Remaining > MinCostRemaining;
                WriteObject(result, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAgileBoard), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAgileBoard), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
