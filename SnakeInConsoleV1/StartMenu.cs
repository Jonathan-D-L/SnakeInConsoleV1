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
            var selector = 0;
            var difficulty = 0;
            while (true)
            {
                selector = getGameArt.ShowStartMenu(selector);
                if (selector == 0)
                {
                    difficulty = getGameArt.ShowSubMenuDifficulty(difficulty);
                    if (difficulty != 3)
                    {
                        playGame.PlayGame(difficulty);
                    }
                }
                if (selector == 1)
                {
                    var hiScores = showHiScores.ShowHiScores();
                    getGameArt.ShowHiscores(hiScores);
                }
                if (selector == 2)
                {
                    break;
                }
            }
        }
    }
}
