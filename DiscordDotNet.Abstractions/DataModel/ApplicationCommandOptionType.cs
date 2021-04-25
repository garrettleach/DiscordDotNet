namespace DiscordDotNet.Abstractions.DataModel
{
    /// <summary>
    /// Describes the type of option
    /// </summary>
    public enum ApplicationCommandOptionType
    {
        /// <summary>
        /// A sub command
        /// </summary>
        /// <remarks>
        /// A subcommand can hold options but not other sub commands or sub command groups
        /// </remarks>
        SUB_COMMAND = 1,
        /// <summary>
        /// A group of sub commands
        /// </summary>
        /// <remarks>
        /// A sub command group can hold subcommands and options, but not other sub command groups
        /// </remarks>
        SUB_COMMAND_GROUP = 2,
        /// <summary>
        /// A string option
        /// </summary>
        /// <remarks>
        /// You can limit the possible options by providing "choices"
        /// </remarks>
        STRING = 3,
        /// <summary>
        /// An integer option
        /// </summary>
        /// <remarks>
        /// You can limit the possible options by providing "choices"
        /// </remarks>
        INTEGER = 4,
        /// <summary>
        /// A boolean option
        /// </summary>
        BOOLEAN = 5,
        /// <summary>
        /// An option accepting users
        /// </summary>
        USER = 6,
        /// <summary>
        /// An option accepting channels
        /// </summary>
        CHANNEL = 7,
        /// <summary>
        /// An option accepting roles
        /// </summary>
        ROLE = 8,
    }
}