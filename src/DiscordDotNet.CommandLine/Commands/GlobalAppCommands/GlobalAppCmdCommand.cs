using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands.GlobalAppCommands
{
    internal class GlobalAppCmdCommand : Command
    {
        public GlobalAppCmdCommand() : base("globalcommand", "Handle requests about global application commands")
        {
            AddCommand(new GetGlobalAppCmdCommand());
            AddCommand(new GetAllGlobalAppCmdCommand());
        }
    }
}
