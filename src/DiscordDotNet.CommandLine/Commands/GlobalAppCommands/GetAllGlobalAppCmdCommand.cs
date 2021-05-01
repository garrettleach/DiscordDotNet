using DiscordDotNet.Abstractions;
using DiscordDotNet.CommandLine.Options;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands.GlobalAppCommands
{
    internal class GetAllGlobalAppCmdCommand : Command
    {
        public GetAllGlobalAppCmdCommand() : base("getall", "Get all global application commands")
        {
            Handler = CommandHandler.Create<InvocationContext, IHost, ApplicationOptions, CancellationToken>(Exec);
        }

        private async Task<int> Exec(InvocationContext invocationContext, IHost host, ApplicationOptions appIdOptions, CancellationToken cancellationToken)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();

            var commands = await client.GetApplicationCommands(appIdOptions.ApplicationId, cancellationToken).ConfigureAwait(false);

            var tableView = new ApplicationCommandTableView(commands);

            invocationContext.Console.Append(tableView, OutputMode.PlainText);

            return 0;
        }
    }
}
