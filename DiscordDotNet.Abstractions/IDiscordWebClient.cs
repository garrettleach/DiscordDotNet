using DiscordDotNet.Abstractions.DataModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.Abstractions
{
    /// <summary>
    /// Interface for the Discord web APIs
    /// </summary>
    public interface IDiscordWebClient
    {
        /// <summary>
        /// Get the registered commands for the application
        /// </summary>
        /// <param name="applicationId">The application ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>application commands</returns>
        Task<ApplicationCommand[]> GetApplicationCommands(string applicationId, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Get the Url of the gateway
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>the uri of the gateway</returns>
        Task<Uri> GetGateway(CancellationToken? cancellationToken = null);
    }
}
