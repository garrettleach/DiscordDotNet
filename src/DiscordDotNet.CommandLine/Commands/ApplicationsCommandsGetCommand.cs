using DiscordDotNet.Abstractions;
using DiscordDotNet.Abstractions.DataModel;
using DiscordDotNet.CommandLine.Options;
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
            Handler = CommandHandler.Create<InvocationContext, IHost, ApplicationOptions, string>(Exec);
        }

        private async Task<int> Exec(InvocationContext invocationContext, IHost host, ApplicationOptions appIdOptions, string commandId = null)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();
            if (commandId is string commId)
            {
                var appCommands = await client.GetApplicationCommand(appIdOptions.ApplicationId, commId).ConfigureAwait(false);

                invocationContext.Console.Append(new JsonView<ApplicationCommand>(appCommands));
            }
            else
            {
                var commands = await client.GetApplicationCommands(appIdOptions.ApplicationId).ConfigureAwait(false);

                var tableView = new ApplicationCommandTableView(commands);

                invocationContext.Console.Append(tableView, OutputMode.PlainText);
            }
            return 0;
        }
    }
}
