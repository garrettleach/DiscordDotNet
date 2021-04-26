using DiscordDotNet.Abstractions;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class ApplicationsCommandsCommand : Command
    {
        public ApplicationsCommandsCommand() : base("get", "Get all or one application command(s)")
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
                var appCommands = await client.GetApplicationCommand(applicationId, commId);

                var json = JsonSerializer.Serialize(appCommands, appCommands.GetType(), new JsonSerializerOptions() { WriteIndented = true });

                var lines = json.Split('\n');
                foreach (var line in lines)
                {
                    invocationContext.Console.Append(new ContentView(line.Replace("\r", "")));
                }
            }
            else
            {
                var appCommands = await client.GetApplicationCommands(applicationId);

                var tableView = new ApplicationCommandTableView(appCommands);

                invocationContext.Console.Append(tableView, OutputMode.PlainText);
            }
            return 0;
        }
    }
}
