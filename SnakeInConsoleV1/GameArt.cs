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
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                //Console.BackgroundColor = AnsiConsole.Background = new Color(192, 222, 114);
                Console.SetCursorPosition(17, Console.CursorTop - 6);
                Console.Write($"                         \r\n");
                Console.SetCursorPosition(15, Console.CursorTop);
                string a = "20 32 32";
                Console.Write($"   -PRESS ANY KEY TO START   \r\n");
                Console.SetCursorPosition(17, Console.CursorTop);
                Console.Write($"                         ");
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey(false);
        }
    }
}
