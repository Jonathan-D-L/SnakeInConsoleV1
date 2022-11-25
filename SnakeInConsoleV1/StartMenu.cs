using SnakeInConsoleV1.Models;
using Spectre.Console;
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

            var playGame = new Game();
            var showHiScores = new HiScores();
            var getGameArt = new GameArt();
            var selector = getGameArt.ShowStartMenu();
            if (selector == 0)
            {
                playGame.PlayGame();
            }
            if (selector == 1)
            {
                var hiScores = showHiScores.ShowHiScores();
                getGameArt.ShowHiscores(hiScores);
            }
            if (selector == 2)
            {
                
            }
        }
    }
}
