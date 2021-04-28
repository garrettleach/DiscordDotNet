﻿using DiscordDotNet.Abstractions;
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
    internal class ApplicationsGuildsCommandsGetCommand : Command
    {
        public ApplicationsGuildsCommandsGetCommand() : base("get", "Get all or one application guild command(s)")
        {
            var commandIdOpt = new Option<string>("--command-id", "The command id to request (omit for all)", ArgumentArity.ZeroOrOne);
            AddOption(commandIdOpt);
            Handler = CommandHandler.Create<InvocationContext, IHost, ApplicationOptions, GuildOptions, string>(Exec);
        }
        private async Task<int> Exec(InvocationContext invocationContext, IHost host, ApplicationOptions appOptions, GuildOptions guildOptions, string commandId = null)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();

            if (commandId is string commId)
            {
                var commands = await client.GetGuildApplicationCommand(appOptions.ApplicationId, guildOptions.GuildId, commId).ConfigureAwait(false);

                invocationContext.Console.Append(new JsonView<ApplicationCommand>(commands));
            }
            else
            {
                var commands = await client.GetGuildApplicationCommands(appOptions.ApplicationId, guildOptions.GuildId).ConfigureAwait(false);

                var tableView = new ApplicationCommandTableView(commands);

                invocationContext.Console.Append(tableView, OutputMode.PlainText);
            }

            return 0;
        }
    }
}
