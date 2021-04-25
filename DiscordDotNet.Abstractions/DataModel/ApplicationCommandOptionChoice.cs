using System.Text.Json.Serialization;

namespace DiscordDotNet.Abstractions.DataModel
{
    /// <summary>
    /// Choice for an option
    /// </summary>
    /// <remarks>
    /// If you specify choices for an option, they are the only valid values for a user to pick
    /// </remarks>
    public class ApplicationCommandOptionChoice
    {
        /// <summary>
        /// Choice name
        /// </summary>
        /// <remarks>
        /// 1-100 characters
        /// </remarks>
        [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Name { get; set; }
        /// <summary>
        /// value of the choice
        /// </summary>
        /// <remarks>
        /// int or string, up to 100 characters if string
        /// </remarks>
        [JsonPropertyName("value"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public object Value { get; set; }
    }
}