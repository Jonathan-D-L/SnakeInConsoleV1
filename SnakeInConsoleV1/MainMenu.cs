using SnakeInConsoleV1.GameMenus;
using SnakeInConsoleV1.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class MainMenu
    {
        public void ShowStartMenu()
        {

            var playGame = new Game();
            var showHiScores = new HiScores();
            var getStartMenu = new StartMenu();
            var getSubMenuDifficulty = new SubMenuDifficulty();
            var getHiScoresMenu = new HiscoresMenu();
            var selector = 0;
            var difficulty = 0;
            while (true)
            {
                selector = getStartMenu.ShowStartMenu(selector);
                if (selector == 0)
                {
                    difficulty = getSubMenuDifficulty.ShowSubMenuDifficulty(difficulty);
                    if (difficulty != 3)
                    {
                        playGame.PlayGame(difficulty);
                    }
                    if (difficulty == 3)
                    {
                        difficulty = 2;
                    }
                }
                if (selector == 1)
                {
                    var hiScores = showHiScores.GetHiScoresFromFile();
                    getHiScoresMenu.ShowHiscoresMenu(hiScores);
                }
                if (selector == 2)
                {
                    break;
                }
            }
        }
    }
}
