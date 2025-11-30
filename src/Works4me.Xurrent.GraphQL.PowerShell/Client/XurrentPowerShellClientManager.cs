using System.Collections.Generic;
using System.Linq;

namespace Works4me.Xurrent.GraphQL.PowerShell.Client
{
    /// <summary>
    /// Provides centralized management for <see cref="XurrentPowerShellClient"/> instances, enabling access to and lifecycle control of client connections within a PowerShell session.
    /// </summary>
    /// <remarks>
    /// Clients are stored in memory for the duration of the session. The first registered client
    /// is returned by <see cref="GetClient"/>. If no client is registered, <see cref="XurrentException"/>
    /// is thrown to indicate that a connection must be established.
    /// </remarks>
    internal static class XurrentPowerShellClientManager
    {
        private readonly static List<XurrentPowerShellClient> _clients = new();

        /// <summary>
        /// Adds a new <see cref="XurrentPowerShellClient"/> to the managed collection.
        /// </summary>
        /// <param name="client">The client instance to add.</param>
        public static void AddClient(XurrentPowerShellClient client)
        {
            _clients.Add(client);
        }

        /// <summary>
        /// Retrieves the last available <see cref="XurrentPowerShellClient"/> from the managed collection.
        /// </summary>
        /// <returns>The last registered <see cref="XurrentPowerShellClient"/>.</returns>
        /// <exception cref="XurrentException">Thrown if no clients have been registered. A connection must be created first.</exception>
        public static XurrentPowerShellClient GetClient()
        {
            if (_clients.Count == 0)
                throw new XurrentException("No active connection to a Xurrent instance found. Please establish a connection using New-XurrentConnection before proceeding.");

            return _clients.Last();
        }
    }
}
