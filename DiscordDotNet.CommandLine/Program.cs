using DiscordDotNet.Abstractions;
using DiscordDotNet.CommandLine.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
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
                new Command("applications", "Handle requests about applications")
                {
                    new Option<string>("--application-id", "The application id for the request"),
                    new Command("commands", "Handle requests about application commands")
                    {
                        new Command("get", "Get all application commands")
                        {
                            Handler = CommandHandler.Create<InvocationContext, IHost, string>(GetApplicationCommands),
                        }
                    }
                },
                new Command("gateway", "Get the gateway") {
                    Handler = CommandHandler.Create<InvocationContext, IHost>(GetGateway)
                }
            };

            return new CommandLineBuilder(rootCommand);
        }

        public static async Task<int> GetApplicationCommands(InvocationContext invocationContext, IHost host, string applicationId)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();
            var appCommands = await client.GetApplicationCommands(applicationId);

            var tableView = new ApplicationCommandTableView(appCommands);

            invocationContext.Console.Append(tableView, OutputMode.PlainText);

            return 0;
        }

        private static async Task<int> GetGateway(InvocationContext invocationContext, IHost host)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();
            var gateway = await client.GetGateway();

            invocationContext.Console.Append(new ContentView(gateway.ToString()));

            return 0;
        }
    }
}
