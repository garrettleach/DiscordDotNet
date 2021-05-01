using DiscordDotNet.WebApi.Abstractions.DataModel;
using System.CommandLine.Rendering.Views;

namespace DiscordDotNet.CommandLine.Views
{
    /// <summary>
    /// A table view to display the commands on the console
    /// </summary>
    internal class ApplicationCommandTableView : TableView<ApplicationCommand>
    {
        /// <summary>
        /// Create the view
        /// </summary>
        /// <param name="appCommands">the application commands to display</param>
        public ApplicationCommandTableView(ApplicationCommand[] appCommands) : base()
        {
            Items = appCommands;
            AddColumn(cellValue: (v) => v?.Id ?? "", header: new ContentView("Id"), column: ColumnDefinition.SizeToContent());
            AddColumn(cellValue: (v) => v?.ApplicationId ?? "", header: new ContentView("ApplicationId"), column: ColumnDefinition.SizeToContent());
            AddColumn(cellValue: (v) => v?.DefaultPermission?.ToString() ?? "null", header: new ContentView("DefaultPermission"), column: ColumnDefinition.SizeToContent());
            AddColumn(cellValue: (v) => v?.Name ?? "", header: new ContentView("Name"), column: ColumnDefinition.SizeToContent());
            AddColumn(cellValue: (v) => v?.Description ?? "", header: new ContentView("Description"), column: ColumnDefinition.Star(1));
        }
    }
}
