using DiscordDotNet.Abstractions;
using DiscordDotNet.Abstractions.DataModel;
using DiscordDotNet.CommandLine.Options;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands.GuildAppCommands
{
    internal class GetGuildAppCmdCommand : Command
    {
        public GetGuildAppCmdCommand() : base("get", "Get a guild application command")
        {
            AddArgument(new Argument("command id"));
            Handler = CommandHandler.Create<InvocationContext, IHost, GuildApplicationOptions, CommandIdOptions, CancellationToken>(Exec);
        }
        private async Task<int> Exec(InvocationContext invocationContext, IHost host, GuildApplicationOptions guildAppOptions, CommandIdOptions command, CancellationToken cancellationToken)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();

            var commands = await client.GetGuildApplicationCommand(guildAppOptions.Application.ApplicationId, guildAppOptions.Guild.GuildId, command.CommandId, cancellationToken).ConfigureAwait(false);

            invocationContext.Console.Append(new JsonView<ApplicationCommand>(commands));

            return 0;
        }
    }
}
