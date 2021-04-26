using System.Text.Json.Serialization;

namespace DiscordDotNet.Abstractions.DataModel
{
    /// <summary>
    /// Object returned by the Get Gateway API
    /// </summary>
    public class Gateway
    {
        /// <summary>
        /// Base Websocket Url to connect to
        /// </summary>
        /// <remarks>
        /// Generally, it is a good idea to explicitly pass the gateway version (v and encoding (encoding, "json" or "etf") as query parameters. You can also pass "compress" with "zlib-stream" as a query parameter.
        /// </remarks>
        [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Url { get; set; }
    }
}
