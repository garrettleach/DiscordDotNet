namespace DiscordDotNet.CommandLine.Options
{
    internal class GuildOptions
    {
        public GuildOptions(string guildId)
        {
            GuildId = guildId;
        }

        public string GuildId { get; }
    }
}
