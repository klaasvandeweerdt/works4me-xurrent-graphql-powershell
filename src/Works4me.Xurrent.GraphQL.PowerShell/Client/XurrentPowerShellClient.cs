using System;
using Works4me.Xurrent.GraphQL.PowerShell.Logging;

namespace Works4me.Xurrent.GraphQL.PowerShell.Client
{
    /// <summary>
    /// The Works4me Xurrent GraphQL PowerShell client.
    /// </summary>
    public sealed class XurrentPowerShellClient : IDisposable
    {
        private readonly AuthenticationTokenCollection _tokens = new();
        private readonly XurrentClient _client;
        private bool _disposedValue;

        internal XurrentClient Client 
        {
            get => _client; 
        }

        internal AuthenticationTokenCollection Tokens
        {
            get => _tokens;
        }

        /// <summary>
        /// Gets or sets the current account ID. Cannot be null or whitespace.
        /// </summary>
        public string AccountId
        {
            get => _client.AccountId;
            set => _client.AccountId = value;
        }

        /// <summary>
        /// Gets or sets the maximum number of consecutive requests the SDK will make to retrieve additional items for a single query.
        /// </summary>
        /// <remarks>
        /// This setting controls how many follow-up requests the SDK is allowed to perform automatically when fetching large result sets that exceed the per-request item limit.<br />
        /// The default value is 1000, which ensures complete data retrieval for most scenarios.<br />
        /// However, when working with very large datasets, it is recommended to lower this value to reduce the risk of exceeding API rate limits, such as the 3600 requests per hour restriction when using a single token.<br />
        /// </remarks>
        /// <value>The default value is 1000. Must be between 1 and 10000, inclusive.</value>
        /// <exception cref="XurrentQueryException">Thrown if the value is less than 1 or greater than 10000.</exception>
        public int MaximumRequestsPerQuery
        {
            get => _client.MaximumRequestsPerQuery;
            set => _client.MaximumRequestsPerQuery = value;
        }

        /// <summary>
        /// Gets or sets the default number of items to return per request.
        /// </summary>
        /// <value>The default value is 100. Must be between 1 and 100, inclusive.</value>
        /// <exception cref="XurrentQueryException">Thrown if the value is less than 1 or greater than 100.</exception>
        public int DefaultItemsPerRequest
        {
            get => _client.DefaultItemsPerRequest;
            set => _client.DefaultItemsPerRequest = value;
        }

        /// <summary>
        /// Gets or sets the maximum allowed depth of nested connection fields in the GraphQL query.
        /// <para><b>Warning:</b> Increasing this value can significantly impact performance due to additional pagination handling in deeply nested connection queries.</para>
        /// </summary>
        /// <value>The default value is 2. Must be between 1 and 13, inclusive.</value>
        public int MaximumConnectionDepth
        {
            get => _client.MaximumConnectionDepth;
            set => _client.MaximumConnectionDepth = value;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token string.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="environment">The environment (e.g., production, quality assurance) to target.</param>
        /// <param name="environmentRegion">The region of the environment (e.g., EU, AU) to target.</param>
        public XurrentPowerShellClient(string personalAccessToken, string accountId, EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            _tokens.Add(new(personalAccessToken));
            _client = new(_tokens, accountId, environment, environmentRegion, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="clientId">The OAuth 2.0 client ID.</param>
        /// <param name="clientSecret">The OAuth 2.0 client secret.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="environment">The environment (e.g., production, quality assurance) to target.</param>
        /// <param name="environmentRegion">The region of the environment (e.g., EU, AU) to target.</param>
        internal XurrentPowerShellClient(string clientId, string clientSecret, string accountId, EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            _tokens.Add(new(clientId, clientSecret));
            _client = new(_tokens, accountId, environment, environmentRegion, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="tokens">The collection of authentication tokens to use.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="environment">The environment (e.g., production, quality assurance) to target.</param>
        /// <param name="environmentRegion">The region of the environment (e.g., EU, AU) to target.</param>
        internal XurrentPowerShellClient(AuthenticationToken[] tokens, string accountId, EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            foreach (AuthenticationToken token in tokens)
                _tokens.Add(token);
            _client = new(_tokens, accountId, environment, environmentRegion, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token string.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="domainName">The domain name of the Xurrent API endpoint.</param>
        internal XurrentPowerShellClient(string personalAccessToken, string accountId, string domainName)
        {
            _tokens.Add(new(personalAccessToken));
            _client = new(_tokens, accountId, domainName, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="clientId">The OAuth 2.0 client ID.</param>
        /// <param name="clientSecret">The OAuth 2.0 client secret.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="domainName">The domain name of the Xurrent API endpoint.</param>
        internal XurrentPowerShellClient(string clientId, string clientSecret, string accountId, string domainName)
        {
            _tokens.Add(new(clientId, clientSecret));
            _client = new(_tokens, accountId, domainName, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/>.
        /// </summary>
        /// <param name="tokens">The collection of authentication tokens to use.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="domainName">The domain name of the Xurrent API endpoint.</param>
        internal XurrentPowerShellClient(AuthenticationToken[] tokens, string accountId, string domainName)
        {
            foreach (AuthenticationToken token in tokens)
                _tokens.Add(token);
            _client = new(_tokens, accountId, domainName, ModuleLoggerFactory.CreateLogger<XurrentClient>());
        }

        /// <summary>
        /// Releases the unmanaged and managed resources used by this client.
        /// </summary>
        /// <param name="disposing"><c>true</c> if called from <see cref="Dispose()"/>; otherwise, <c>false</c>.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (AuthenticationToken token in _tokens)
                        token?.Dispose();
                    _tokens?.Dispose();
                    _client?.Dispose();
                }
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes the client, releasing all managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
