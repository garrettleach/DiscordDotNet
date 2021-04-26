using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsGuildsCommandsCommand : Command
    {
        public ApplicationsGuildsCommandsCommand() : base("commands", "Handle requests about application guild commands")
        {
            AddCommand(new ApplicationsGuildsCommandsGetCommand());
        }
    }
}
