using System.Text.Json.Serialization;

namespace DiscordDotNet.WebApi.Abstractions.DataModel
{
    /// <summary>
    /// Description of sn option in an application command
    /// </summary>
    public class ApplicationCommandOption
    {
        /// <summary>
        /// Type of the option
        /// </summary>
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ApplicationCommandOptionType Type { get; set; }
        /// <summary>
        /// Name of the option
        /// </summary>
        /// <remarks>
        /// 1-32 character name matching ^[\w-]{1,32}$
        /// </remarks>
        [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Name { get; set; }
        /// <summary>
        /// Description of the option
        /// </summary>
        /// <remarks>
        /// 1-100 character description
        /// </remarks>
        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }
        /// <summary>
        /// Is the parameter required or optional
        /// </summary>
        /// <remarks>
        /// Default is false
        /// </remarks>
        [JsonPropertyName("required"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Required { get; set; }
        /// <summary>
        /// choices for string and int types for the user to pick from
        /// </summary>
        /// <remarks>
        /// Limited to 25 choices</remarks>
        [JsonPropertyName("choices"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ApplicationCommandOptionChoice[] Choices { get; set; }
        /// <summary>
        /// if the option is a subcommand or subcommand group type, this nested options will be the parameters
        /// </summary>
        [JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ApplicationCommandOption[] Options { get; set; }
    }
}