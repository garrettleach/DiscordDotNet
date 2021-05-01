using DiscordDotNet.WebApi.Abstractions.DataModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.WebApi.Abstractions
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
        /// Get a registered command for the application
        /// </summary>
        /// <param name="applicationId">The application ID</param>
        /// <param name="commandId">The command ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>application command</returns>
        Task<ApplicationCommand> GetApplicationCommand(string applicationId, string commandId, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Get the registered commands for the application in a guild
        /// </summary>
        /// <param name="applicationId">the application ID</param>
        /// <param name="guildId">the guild ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>application guild commands</returns>
        Task<ApplicationCommand[]> GetGuildApplicationCommands(string applicationId, string guildId, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Get a registered commands for the application in a guild
        /// </summary>
        /// <param name="applicationId">the application ID</param>
        /// <param name="guildId">the guild ID</param>
        /// <param name="commandId">the command ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>application guild command</returns>
        Task<ApplicationCommand> GetGuildApplicationCommand(string applicationId, string guildId, string commandId, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Get the Url of the gateway
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>the uri of the gateway</returns>
        Task<Uri> GetGateway(CancellationToken? cancellationToken = null);
    }
}
