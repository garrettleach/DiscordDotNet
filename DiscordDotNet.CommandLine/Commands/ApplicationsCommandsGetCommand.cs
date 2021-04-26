using DiscordDotNet.Abstractions;
using DiscordDotNet.Abstractions.DataModel;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsCommandsGetCommand : Command
    {
        public ApplicationsCommandsGetCommand() : base("get", "Get all or one application command(s)")
        {
            var commandIdOpt = new Option<string>("--command-id", "The command id to request (omit for all)", ArgumentArity.ZeroOrOne);
            AddOption(commandIdOpt);
            Handler = CommandHandler.Create<InvocationContext, IHost, string, string>(Exec);
        }

        private async Task<int> Exec(InvocationContext invocationContext, IHost host, string applicationId, string commandId = null)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();
            if (commandId is string commId)
            {
                var appCommands = await client.GetApplicationCommand(applicationId, commId).ConfigureAwait(false);

                invocationContext.Console.Append(new JsonView<ApplicationCommand>(appCommands));
            }
            else
            {
                var commands = await client.GetApplicationCommands(applicationId).ConfigureAwait(false);

                var tableView = new ApplicationCommandTableView(commands);

                invocationContext.Console.Append(tableView, OutputMode.PlainText);
            }
            return 0;
        }
    }
}
