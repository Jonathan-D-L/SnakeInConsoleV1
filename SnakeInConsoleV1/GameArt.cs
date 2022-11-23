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
            var test = new CanvasImage("images\\test.png");
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                AnsiConsole.Write(test);
                Console.SetCursorPosition(15, Console.CursorTop - 6);
                Console.Write($"                             \r\n");
                Console.SetCursorPosition(15, Console.CursorTop);
                Console.Write($"   -press any key to start   \r\n");
                Console.SetCursorPosition(15, Console.CursorTop);
                Console.Write($"                             ");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
