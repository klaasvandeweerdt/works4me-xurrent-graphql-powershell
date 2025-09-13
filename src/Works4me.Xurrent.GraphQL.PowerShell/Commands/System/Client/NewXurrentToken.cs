using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AuthenticationToken"/> for use with the Xurrent GraphQL API.<br/>
    /// Supports multiple authentication methods, including OAuth2, personal access token, and credentials.<br/>
    /// The resulting token can be used to authenticate subsequent requests.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentToken")]
    [OutputType(typeof(AuthenticationToken))]
    public class NewXurrentToken : XurrentCmdletBase
    {
        /// <summary>
        /// The OAuth2 client identifier. Required when using the <c>OAuth2</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// The OAuth2 client secret. Required when using the <c>OAuth2</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [ValidateNotNullOrEmpty]
        public string ClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// The personal access token used for authentication. Required when using the <c>PersonalAccessToken</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [ValidateNotNullOrEmpty]
        public string PersonalAccessToken { get; set; } = string.Empty;

        /// <summary>
        /// The OAuth2 Credentials (ClientId and ClientSecret). Required when using the <c>Credential</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [ValidateNotNull]
        public PSCredential? Credential { get; set; }

        /// <summary>
        /// Executes the token creation process by constructing an <see cref="AuthenticationToken"/> from the provided parameters, 
        /// writing the resulting token to the pipeline for use in authentication workflows.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                AuthenticationToken token = ParameterSetName switch
                {
                    "OAuth2" => new AuthenticationToken(ClientId, ClientSecret),
                    "PersonalAccessToken" => new(PersonalAccessToken),
                    "Credential" => Credential is null ? throw new ArgumentNullException(nameof(Credential)) : new(Credential.UserName, Credential.GetNetworkCredential().Password),
                    _ => throw new InvalidOperationException()
                };

                WriteObject(token, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentToken), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentToken), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
