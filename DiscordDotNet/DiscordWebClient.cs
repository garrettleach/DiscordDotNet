using DiscordDotNet.Abstractions;
using DiscordDotNet.Abstractions.DataModel;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet
{
    /// <summary>
    /// The client for Discord web APIs
    /// </summary>
    public class DiscordWebClient : IDiscordWebClient
    {
        private readonly IDiscordWebV8Service _DiscordWebV8Service;
        private readonly ILogger<DiscordWebClient> _Logger;
        /// <summary>
        /// Create the client
        /// </summary>
        /// <param name="discordWebV8Service">The v8 service the client will use</param>
        /// <param name="logger">Logger</param>
        public DiscordWebClient(IDiscordWebV8Service discordWebV8Service, ILogger<DiscordWebClient> logger)
        {
            _DiscordWebV8Service = discordWebV8Service ?? throw new ArgumentNullException(nameof(discordWebV8Service));
            _Logger = logger ?? throw new ArgumentNullException(nameof(discordWebV8Service));
        }

        /// <inheritdoc/>
        public Task<ApplicationCommand[]> GetApplicationCommands(string applicationId, CancellationToken? cancellationToken = null)
        {
            return _DiscordWebV8Service.GetApplicationCommands(applicationId, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Uri> GetGateway(CancellationToken? cancellationToken = null)
        {
            var gateway = await _DiscordWebV8Service.GetGateway(cancellationToken);
            return new Uri(gateway.Url);
        }
    }
}
