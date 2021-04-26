using System.CommandLine.Rendering.Views;
using System.Text.Json;

namespace DiscordDotNet.CommandLine.Views
{
    internal class JsonView<T> : StackLayoutView
    {
        public JsonView(T obj)
        {
            foreach (var line in JsonSerializer.Serialize(obj, typeof(T), new JsonSerializerOptions() { WriteIndented = true }).Split("\r\n"))
            {
                Add(new ContentView(line));
            }
        }
    }
}
