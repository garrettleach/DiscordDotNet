namespace DiscordDotNet.CommandLine.Options
{
    internal class GuildApplicationOptions
    {
        public GuildApplicationOptions(ApplicationOptions application, GuildOptions guild)
        {
            Guild = guild;
            Application = application;
        }

        public ApplicationOptions Application { get; }

        public GuildOptions Guild { get; }
    }
}
