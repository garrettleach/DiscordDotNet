using System.CommandLine;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsCommand : Command
    {
        public ApplicationsCommand() : base("applications", "Handle requests about applications")
        {
            AddOption(new Option<string>("--application-id", "The application id for the request"));
            AddCommand(new Command("commands", "Handle requests about application commands")
            {
                new ApplicationsCommandsCommand()
            });
        }
    }
}
