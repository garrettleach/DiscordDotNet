using System;

namespace DiscordDotNet.WebApi
{
    /// <summary>
    /// Options for the api client
    /// </summary>
    public class DiscordWebClientOptions
    {
        /// <summary>
        /// The Base URL for Discord API requests
        /// </summary>
        /// <remarks>
        /// Typically "https://discord.com/api/"
        /// </remarks>
        public Uri BaseUrl { get; set; }
        /// <summary>
        /// Bot Token to use when authorization is required
        /// </summary>
        public string BotToken { get; set; }
        /// <summary>
        /// Bearer Token to use when authorization is required
        /// </summary>
        public string BearerToken { get; set; }
    }
}
