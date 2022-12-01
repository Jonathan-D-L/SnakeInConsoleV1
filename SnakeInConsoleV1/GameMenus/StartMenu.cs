using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.GameMenus
{
    internal static class StartMenu
    {
        public static int ShowStartMenu(int selector)
        {
            var startImg = new CanvasImage("images\\Start.png");
            var renderData = new List<string>();
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                Console.SetCursorPosition(18, Console.CursorTop - 6);

                if (selector == 0)
                {
                    renderData.Add($"[black on rgb(192,222,114)]> PLAY           W \r\n[/]");
                }
                else
                {
                    renderData.Add($"[black on rgb(192,222,114)]  PLAY           W \r\n[/]");
                }
                if (selector == 1)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                > HISCORES     A S D\r\n[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                  HISCORES     A S D\r\n[/]");
                }
                if (selector == 2)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                > QUIT        ,_____,[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                  QUIT        ,_____,[/]");
                }
                string render = "";
                for (int y = 0; y < renderData.Count; ++y)
                {
                    render += (renderData[y]);
                }
                AnsiConsole.Markup(render);
                renderData.Clear();
                Console.SetCursorPosition(0, Console.CursorTop + 4);
                var input = Console.ReadKey().Key;
                if (input == ConsoleKey.Spacebar || input == ConsoleKey.Enter)
                {
                    break;
                }
                if ((input == ConsoleKey.W || input == ConsoleKey.UpArrow) && selector != 0)
                {
                    selector--;
                }
                if ((input == ConsoleKey.S || input == ConsoleKey.DownArrow) && selector != 2)
                {
                    selector++;
                }

            }
            return selector;
        }
    }
}
