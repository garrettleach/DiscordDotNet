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

namespace DiscordDotNet.CommandLine.Commands.GuildAppCommands
{
    internal class GetAllGuildAppCmdCommand : Command
    {
        public GetAllGuildAppCmdCommand() : base("getall", "Get all guild application commands")
        {
            Handler = CommandHandler.Create<InvocationContext, IHost, GuildApplicationOptions, CancellationToken>(Exec);
        }
        private async Task<int> Exec(InvocationContext invocationContext, IHost host, GuildApplicationOptions guildAppOptions, CancellationToken cancellationToken)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();

            var commands = await client.GetGuildApplicationCommands(guildAppOptions.Application.ApplicationId, guildAppOptions.Guild.GuildId, cancellationToken).ConfigureAwait(false);

            var tableView = new ApplicationCommandTableView(commands);

            invocationContext.Console.Append(tableView);

            return 0;
        }
    }
}
