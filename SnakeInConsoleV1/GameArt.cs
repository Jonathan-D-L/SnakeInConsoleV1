using SixLabors.ImageSharp.ColorSpaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class GameArt
    {
        public void StartMenuArt()
        {
            var startImg = new CanvasImage("images\\Start.png");
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                Console.SetCursorPosition(18, Console.CursorTop - 6);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]PRESS ANY KEY TO START![/]");
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey(false);
        }
        public void GameOverArt()
        {

        }
    }
}
