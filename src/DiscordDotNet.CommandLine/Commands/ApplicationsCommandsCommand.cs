using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsCommandsCommand : Command
    {
        public ApplicationsCommandsCommand() : base("commands", "Handle requests about application commands")
        {
            AddCommand(new ApplicationsCommandsGetCommand());
        }
    }
}
