using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="XurrentPowerShellClient"/> instance for connecting to the Xurrent GraphQL API.<br/>
    /// Supports multiple authentication modes (<c>OAuth2</c>, <c>PersonalAccessToken</c>, or <c>Credential</c>) and environment options.<br/>
    /// The created client is added to the session’s client manager so it can be reused by subsequent cmdlets.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentClient")]
    [OutputType(typeof(XurrentPowerShellClient))]
    public class NewXurrentClient : XurrentCmdletBase
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
        /// The Xurrent Authentication token collection.  Required when using the <c>AuthenticationToken</c> parameter set.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        public AuthenticationToken[]? Tokens { get; set; }

        /// <summary>
        /// The account identifier to connect to. Required in all authentication modes.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [Parameter(Mandatory = true, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// The Xurrent environment type.
        /// Required unless <see cref="DomainName"/> is explicitly provided.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [Parameter(Mandatory = true, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        public EnvironmentType EnvironmentType { get; set; }

        /// <summary>
        /// The Xurrent environment region.
        /// Required unless <see cref="DomainName"/> is explicitly provided.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [Parameter(Mandatory = true, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        public EnvironmentRegion EnvironmentRegion { get; set; }

        /// <summary>
        /// An optional custom domain name to connect to instead of using <see cref="EnvironmentType"/> and <see cref="EnvironmentRegion"/>.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [Hidden]
        public string? DomainName { get; set; }

        /// <summary>
        /// Sets the maximum number of items a single query may request.
        /// Defaults to <c>10000</c>. Values must be between 1 and 10000.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [Parameter(Mandatory = false, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        [ValidateRange(1, 10000)]
        public int MaximumRequestsPerQuery { get; set; } = 10000;

        /// <summary>
        /// Sets the default number of items requested per query page.
        /// Defaults to <c>100</c>. Values must be between 1 and 100.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [Parameter(Mandatory = false, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int DefaultItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// Sets the maximum depth of nested connection queries allowed.
        /// Defaults to <c>2</c>. Values must be between 1 and 13.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [Parameter(Mandatory = false, ParameterSetName = "AuthenticationToken")]
        [ValidateNotNull]
        [ValidateRange(1, 13)]
        public int MaximumConnectionDepth { get; set; } = 2;

        /// <summary>
        /// Creates and configures a <see cref="XurrentPowerShellClient"/> based on the provided parameters,
        /// adds it to the client manager, and writes it to the pipeline.<br/>
        /// Throws a terminating error if authentication or connection setup fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        { 
            try
            {
                XurrentPowerShellClient client;
                if (DomainName is not null)
                {
                    client = ParameterSetName switch
                    {
                        "OAuth2" => new(ClientId, ClientSecret, AccountId, DomainName),
                        "PersonalAccessToken" => new(PersonalAccessToken, AccountId, DomainName),
                        "Credential" => Credential is null ? throw new ArgumentNullException(nameof(Credential)) : new(Credential.UserName, Credential.GetNetworkCredential().Password, AccountId, DomainName),
                        "AuthenticationToken" => Tokens is null ? throw new ArgumentNullException(nameof(Tokens)) : new(Tokens, AccountId, DomainName),
                        _ => throw new InvalidOperationException()
                    };
                }
                else
                {
                    client = ParameterSetName switch
                    {
                        "OAuth2" => new(ClientId, ClientSecret, AccountId, EnvironmentType, EnvironmentRegion),
                        "PersonalAccessToken" => new(PersonalAccessToken, AccountId, EnvironmentType, EnvironmentRegion),
                        "Credential" => Credential is null ? throw new ArgumentNullException(nameof(Credential)) : new(Credential.UserName, Credential.GetNetworkCredential().Password, AccountId, EnvironmentType, EnvironmentRegion),
                        "AuthenticationToken" => Tokens is null ? throw new ArgumentNullException(nameof(Tokens)) : new(Tokens, AccountId, EnvironmentType, EnvironmentRegion),
                        _ => throw new InvalidOperationException()
                    };
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(MaximumRequestsPerQuery)))
                {
                    client.MaximumRequestsPerQuery = MaximumRequestsPerQuery;
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(DefaultItemsPerRequest)))
                {
                    client.DefaultItemsPerRequest = DefaultItemsPerRequest;
                }

                if (MyInvocation.BoundParameters.ContainsKey(nameof(MaximumConnectionDepth)))
                {
                    client.MaximumConnectionDepth = MaximumConnectionDepth;
                }

                XurrentPowerShellClientManager.AddClient(client);
                WriteObject(client, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentClient), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentClient), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
