using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhlSystemClassLibrary;

namespace NhlWebApp.Pages
{
    public class NhlPlayersModel : PageModel
    {
        private IWebHostEnvironment WebHostEnvironment;

        public NhlPlayersModel(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        public List<Player> PlayerList { get; private set; } = new List<Player>();

        public void OnGet()
        {
            string dataFilePath = WebHostEnvironment.ContentRootPath;
            string csvFilePath = Path.Combine(dataFilePath, @"data\OilersPlayers.csv");
            string[] allLines = System.IO.File.ReadAllLines(csvFilePath);
            foreach (var currentLine in allLines)
            {
                try
                {
                    Player currentPlayer = null;
                    if (Player.TryParse(currentLine, out currentPlayer))
                    {
                        PlayerList.Add(currentPlayer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from file with exception {ex.Message}");
                }
            }
        }
    }
}
