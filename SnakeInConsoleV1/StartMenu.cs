using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class StartMenu
    {
        public void Menu()
        {
            Console.SetWindowSize(61,29);
            Console.CursorVisible = false;
            var playGame = new Game();
            playGame.PlayGame();
        }
    }
}
