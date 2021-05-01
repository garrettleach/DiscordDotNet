using DiscordDotNet.WebApi.Abstractions;
using DiscordDotNet.WebApi.Abstractions.DataModel;
using DiscordDotNet.CommandLine.Options;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands.GlobalAppCommands
{
    internal class GetGlobalAppCmdCommand : Command
    {
        public GetGlobalAppCmdCommand() : base("get", "Get a global application command")
        {
            AddArgument(new Argument("command-id"));
            Handler = CommandHandler.Create<InvocationContext, IHost, ApplicationOptions, CommandIdOptions, CancellationToken>(Exec);
        }

        private async Task<int> Exec(InvocationContext invocationContext, IHost host, ApplicationOptions appIdOptions, CommandIdOptions command, CancellationToken cancellationToken)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();

            var commands = await client.GetApplicationCommand(appIdOptions.ApplicationId, command.CommandId, cancellationToken).ConfigureAwait(false);

            invocationContext.Console.Append(new JsonView<ApplicationCommand>(commands));

            return 0;
        }
    }
}
