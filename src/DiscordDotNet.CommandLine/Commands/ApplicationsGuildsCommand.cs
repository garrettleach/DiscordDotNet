using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsGuildsCommand : Command
    {
        public ApplicationsGuildsCommand() : base("guilds", "Handle requests about application guilds")
        {
            AddCommand(new ApplicationsGuildsCommandsCommand());
            AddArgument(new Argument("guildId"));
        }
    }
}