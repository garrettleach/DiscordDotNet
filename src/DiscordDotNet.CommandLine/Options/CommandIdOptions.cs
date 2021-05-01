namespace DiscordDotNet.CommandLine.Options
{
    internal class CommandIdOptions
    {
        public CommandIdOptions(string commandId)
        {
            CommandId = commandId;
        }

        public string CommandId { get; }
    }
}
