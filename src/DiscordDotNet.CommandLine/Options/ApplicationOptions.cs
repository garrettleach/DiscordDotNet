namespace DiscordDotNet.CommandLine.Options
{
    internal class ApplicationOptions
    {
        public ApplicationOptions(string applicationId)
        {
            ApplicationId = applicationId;
        }

        public string ApplicationId { get; }
    }
}
