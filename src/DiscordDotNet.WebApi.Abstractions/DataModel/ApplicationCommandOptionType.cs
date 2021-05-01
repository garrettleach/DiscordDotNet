
namespace DiscordDotNet.WebApi.Abstractions.DataModel
{
    /// <summary>
    /// Describes the type of option
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum ApplicationCommandOptionType
#pragma warning restore CA1008 // Enums should have zero value
    {
#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// A sub command (SUB_COMMAND)
        /// </summary>
        /// <remarks>
        /// A subcommand can hold options but not other sub commands or sub command groups
        /// </remarks>
        SubCommand = 1,
        /// <summary>
        /// A group of sub commands (SUB_COMMAND_GROUP)
        /// </summary>
        /// <remarks>
        /// A sub command group can hold subcommands and options, but not other sub command groups
        /// </remarks>
        SubCommandGroup = 2,
        /// <summary>
        /// A string option (STRING)
        /// </summary>
        /// <remarks>
        /// You can limit the possible options by providing "choices"
        /// </remarks>
        String = 3,
        /// <summary>
        /// An integer option (INTEGER)
        /// </summary>
        /// <remarks>
        /// You can limit the possible options by providing "choices"
        /// </remarks>
        Integer = 4,
        /// <summary>
        /// A boolean option (BOOLEAN)
        /// </summary>
        Boolean = 5,
        /// <summary>
        /// An option accepting users (USER)
        /// </summary>
        User = 6,
        /// <summary>
        /// An option accepting channels (CHANNEL)
        /// </summary>
        Channel = 7,
        /// <summary>
        /// An option accepting roles (ROLE)
        /// </summary>
        Role = 8,
#pragma warning restore CA1720 // Identifier contains type name
    }
}