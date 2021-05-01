using DiscordDotNet.WebApi.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet.CommandLine.Commands
{
    internal class GatewayCommand : Command
    {
        public GatewayCommand() : base("gateway", "Get the gateway")
        {
            Handler = CommandHandler.Create<InvocationContext, IHost, CancellationToken>(Exec);
        }

        private static async Task<int> Exec(InvocationContext invocationContext, IHost host, CancellationToken cancellationToken)
        {
            var client = host.Services.GetRequiredService<IDiscordWebClient>();
            var gateway = await client.GetGateway(cancellationToken).ConfigureAwait(false);

            invocationContext.Console.Append(new ContentView(gateway.ToString()));

            return 0;
        }
    }
}
