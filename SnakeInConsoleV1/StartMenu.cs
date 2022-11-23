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
            var getGameArt = new GameArt();
            getGameArt.startMenuArt();
            var playGame = new Game();
            playGame.PlayGame();
        }
    }
}
