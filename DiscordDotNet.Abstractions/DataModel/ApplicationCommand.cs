using System.Text.Json.Serialization;

namespace DiscordDotNet.Abstractions.DataModel
{
    /// <summary>
    /// Description of an application command
    /// </summary>
    public class ApplicationCommand
    {
        /// <summary>
        /// Unique id of the command
        /// </summary>
        /// <remarks>
        /// Snowflake format
        /// </remarks>
        [JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Id { get; set; }
        /// <summary>
        /// Unique id of the parent application
        /// </summary>
        /// <remarks>
        /// Snowflake format
        /// </remarks>
        [JsonPropertyName("application_id"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string ApplicationId { get; set; }
        /// <summary>
        /// Name of the command
        /// </summary>
        /// <remarks>
        /// 1-32 character name matching ^[\w-]{1,32}$
        /// </remarks>
        [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Name { get; set; }
        /// <summary>
        /// Description of the command
        /// </summary>
        /// <remarks>
        /// 1-100 character description
        /// </remarks>
        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Description { get; set; }
        /// <summary>
        /// The parameters for the command
        /// </summary>
        /// <remarks>
        /// A command, or each individual subcommand, can have a maximum of 25 options
        /// </remarks>
        [JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ApplicationCommandOption[] Options { get; set; }
        /// <summary>
        /// Whether the command is enabled by default when the app is added to a guild
        /// </summary>
        /// <remarks>
        /// Defaults to true
        /// </remarks>
        [JsonPropertyName("default_permission"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DefaultPermission { get; set; }

    }
}
