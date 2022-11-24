using SnakeInConsoleV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class StartMenu
    {
        public void ShowStartMenu()
        {
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.WriteLine(" sadasd");
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine(" sadasd");
            //Console.ReadKey();
            var getGameArt = new GameArt();
            getGameArt.startMenuArt();
            var playGame = new Game();
            playGame.PlayGame();
        }
    }
}
