using DiscordDotNet.Abstractions.DataModel;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet
{
    /// <summary>
    /// Interface for Discord Web APIs (v8)
    /// </summary>
    public interface IDiscordWebV8Service
    {
        /// <summary>
        /// Get the commands for the application
        /// </summary>
        /// <param name="applicationId">application ID to request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>application commands</returns>
        Task<ApplicationCommand[]> GetApplicationCommands(string applicationId, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Get a command for the application
        /// </summary>
        /// <param name="applicationId">application ID for the request</param>
        /// <param name="commandId">command id to request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>application command</returns>
        Task<ApplicationCommand> GetApplicationCommand(string applicationId, string commandId, CancellationToken? cancellationToken);
        /// <summary>
        /// Get the gateway Uri
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Uri to connect to</returns>
        Task<Gateway> GetGateway(CancellationToken? cancellationToken = null);
    }
}
