using DiscordDotNet.Abstractions;
using DiscordDotNet.CommandLine.Commands;
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
    class Program
    {
        static async Task Main(string[] args) => await BuildCommandLine()
            .UseHost(_ => Host.CreateDefaultBuilder(),
                host => {
                    host.ConfigureLogging(logging => {
                        logging.ClearProviders();
                        logging.AddDebug();
                    });
                    host.ConfigureServices(services => {
                        services.AddHttpClient<IDiscordWebV8Service, DiscordWebV8Service>();
                        services.AddSingleton<IDiscordWebClient, DiscordWebClient>();
                        services.AddOptions<DiscordWebClientOptions>().BindConfiguration("DiscordApiClient");

                    });
                })
            .UseDefaults()
            .Build()
            .InvokeAsync(args);

        private static CommandLineBuilder BuildCommandLine()
        {
            var rootCommand = new RootCommand("Tool to excercise Discord API")
            {
                new ApplicationsCommand(),
                new GatewayCommand()
            };

            return new CommandLineBuilder(rootCommand);
        }

    }
}
