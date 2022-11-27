using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.GameMenus
{
    internal class SubMenuDifficulty
    {
        public int ShowSubMenuDifficulty(int selector)
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
                    renderData.Add($"[black on rgb(192,222,114)]> EASY           W \r\n[/]");
                }
                else
                {
                    renderData.Add($"[black on rgb(192,222,114)]  EASY           W \r\n[/]");
                }
                if (selector == 1)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                > NORMAL       A S D\r\n[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                  NORMAL       A S D\r\n[/]");
                }
                if (selector == 2)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                > HARD        ,_____,\r\n[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                  HARD        ,_____,\r\n[/]");
                }
                if (selector == 3)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                > BACK[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                  BACK[/]");
                }
                string render = "";
                for (int y = 0; y < renderData.Count; ++y)
                {
                    render += (renderData[y]);
                }
                AnsiConsole.Markup(render);
                renderData.Clear();
                Console.SetCursorPosition(0, Console.CursorTop + 3);
                var input = Console.ReadKey().Key;
                if (input == ConsoleKey.Spacebar || input == ConsoleKey.Enter)
                {
                    break;
                }
                if ((input == ConsoleKey.W || input == ConsoleKey.UpArrow) && selector != 0)
                {
                    selector--;
                }
                if ((input == ConsoleKey.S || input == ConsoleKey.DownArrow) && selector != 3)
                {
                    selector++;
                }
            }
            return selector;
        }
    }
}
