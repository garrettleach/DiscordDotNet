using DiscordDotNet.CommandLine.Commands.GlobalAppCommands;
using DiscordDotNet.CommandLine.Commands.GuildAppCommands;
using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands.ApplicationCommands
{
    internal class ApplicationCommand : Command
    {
        public ApplicationCommand() : base("application", "Handle requests about applications")
        {
            AddArgument(new Argument("application id"));
            AddCommand(new GlobalAppCmdCommand());
            AddCommand(new GuildAppCmdCommand());
        }
    }
}
