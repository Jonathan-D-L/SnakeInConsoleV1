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
        public void startMenuArt()
        {
            var startImg = new CanvasImage("images\\Start.png");
            Console.CursorVisible = true;
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                Console.SetCursorPosition(15, Console.CursorTop - 6);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]   -PRESS ANY KEY TO START   [/]");
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey(false);
        }
    }
}
