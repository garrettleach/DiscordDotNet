using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands.GuildAppCommands
{
    internal class GuildAppCmdCommand : Command
    {
        public GuildAppCmdCommand() : base("guildcommand", "Handle requests about guild application commands")
        {
            AddArgument(new Argument("guild id"));
            AddCommand(new GetGuildAppCmdCommand());
            AddCommand(new GetAllGuildAppCmdCommand());
        }
    }
}