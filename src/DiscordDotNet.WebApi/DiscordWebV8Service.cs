using DiscordDotNet.WebApi.Abstractions.DataModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.WebApi
{
    /// <summary>
    /// Service to make underlying requests against the Discord web APIs (v8)
    /// </summary>
    public class DiscordWebV8Service : IDiscordWebV8Service
    {
        private readonly HttpClient _HttpClient;
        private readonly ILogger<DiscordWebV8Service> _Logger;
        private readonly IOptions<DiscordWebClientOptions> _ClientOptions;
        /// <summary>
        /// Create the service
        /// </summary>
        /// <param name="httpClient">underlying client</param>
        /// <param name="clientOptions">configuration for the client</param>
        /// <param name="logger">logger</param>
        public DiscordWebV8Service(HttpClient httpClient, IOptions<DiscordWebClientOptions> clientOptions, ILogger<DiscordWebV8Service> logger)
        {
            _HttpClient = httpClient;
            _ClientOptions = clientOptions;
            _Logger = logger;

            _HttpClient.BaseAddress = _ClientOptions.Value.BaseUrl;
            if (_ClientOptions?.Value?.BotToken is string bot)
            {
                _Logger?.LogTrace("Using Bot Authorization Header");
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", bot);
            }
            else if (_ClientOptions?.Value?.BearerToken is string bearer)
            {
                _Logger?.LogTrace("Using Bearer Authorization Header");
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            }
            else
            {
                _Logger?.LogWarning("Using *NO* Authorization Header");
                _HttpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        /// <inheritdoc/>
        public Task<ApplicationCommand[]> GetApplicationCommands(string applicationId, CancellationToken? cancellationToken = null)
        {
            _Logger.LogTrace($"Getting application commands for application {applicationId}");
            return _HttpClient.GetFromJsonAsync<ApplicationCommand[]>($"v8/applications/{applicationId}/commands", cancellationToken ?? CancellationToken.None);
        }

        /// <inheritdoc/>
        public Task<ApplicationCommand> GetApplicationCommand(string applicationId, string commandId, CancellationToken? cancellationToken)
        {
            _Logger.LogTrace($"Getting application command for application {applicationId} with command {commandId}");
            return _HttpClient.GetFromJsonAsync<ApplicationCommand>($"v8/applications/{applicationId}/commands/{commandId}", cancellationToken ?? CancellationToken.None);
        }

        /// <inheritdoc/>
        public Task<Gateway> GetGateway(CancellationToken? cancellationToken = null)
        {
            _Logger.LogTrace($"Getting gateway");
            return _HttpClient.GetFromJsonAsync<Gateway>($"v8/gateway", cancellationToken ?? CancellationToken.None);
        }

        /// <inheritdoc/>
        public Task<ApplicationCommand[]> GetGuildApplicationCommands(string applicationId, string guildId, CancellationToken? cancellationToken = null)
        {
            _Logger.LogTrace($"Getting application commands for application {applicationId} in guild {guildId}");
            return _HttpClient.GetFromJsonAsync<ApplicationCommand[]>($"v8/applications/{applicationId}/guilds/{guildId}/commands", cancellationToken ?? CancellationToken.None);
        }

        /// <inheritdoc/>
        public Task<ApplicationCommand> GetGuildApplicationCommand(string applicationId, string guildId, string commandId, CancellationToken? cancellationToken = null)
        {
            _Logger.LogTrace($"Getting application command for application {applicationId} in guild {guildId} with command {commandId}");
            return _HttpClient.GetFromJsonAsync<ApplicationCommand>($"v8/applications/{applicationId}/guilds/{guildId}/commands/{commandId}", cancellationToken ?? CancellationToken.None);
        }
    }
}
