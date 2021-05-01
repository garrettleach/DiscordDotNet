using DiscordDotNet.Abstractions;
using DiscordDotNet.CommandLine.Commands;
using DiscordDotNet.CommandLine.Commands.ApplicationCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            _ = await BuildCommandLine()
                .UseHost(_ => Host.CreateDefaultBuilder(),
                host => {
                    _ = host.ConfigureLogging((ctx, logging) => {
                        if (ctx.HostingEnvironment.IsDevelopment())
                        {
                            _ = logging.ClearProviders();
                            _ = logging.AddDebug();
                        }
                    });
                    _ = host.ConfigureServices(services => {
                        _ = services.AddHttpClient<IDiscordWebV8Service, DiscordWebV8Service>();
                        _ = services.AddSingleton<IDiscordWebClient, DiscordWebClient>();
                        _ = services.AddOptions<DiscordWebClientOptions>().BindCommandLine();
                    });
                })
                .CancelOnProcessTermination()
                .UseDefaults()
                .Build()
                .InvokeAsync(args).ConfigureAwait(false);
        }

        private static CommandLineBuilder BuildCommandLine()
        {
            var rootCommand = new RootCommand("Tool to excercise Discord API")
            {
                new Option<string>("--bottoken", "Bot Token to use for request"),
                new Option<string>("--bearertoken", "Beraer Token to use for request"),
                new Option<string>("--baseurl", () => "https://discord.com/api/", "Base Discord API url to use"),
                new ApplicationCommand(),
                new GatewayCommand()
            };

            return new CommandLineBuilder(rootCommand);
        }

    }
}
