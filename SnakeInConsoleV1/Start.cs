using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SnakeInConsoleV1.Helpers;

namespace SnakeInConsoleV1.Models
{
    internal class Start
    {
        public void SetWindowProp()
        {
            ConsoleWindowProperties.DisableFunctionsConsoleWindow();
            ConsoleWindowProperties.DisableClicksInConsoleWindow();
            Console.SetWindowSize(61, 29);
            Console.SetBufferSize(61, 29);
            Console.SetWindowSize(61, 29);
            Console.Title = "Snake";
            Console.TreatControlCAsInput = true;
            Console.CursorVisible = false;
            HighScoresHelper.CheckForHiScoresFile();
            var showStartMenu = new MainMenu();
            showStartMenu.ShowStartMenu();
        }
    }
}
