using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.GameMenus
{
    internal class SubMenuPlayAgain
    {
        public int ShowSubMenuPlayAgain(int[] fruitAndScore)
        {
            var gameOverImg = new CanvasImage("images\\GameOver.png");
            var renderData = new List<string>();
            int selector = 1;
            var fruit = fruitAndScore[0];
            var a = fruit.ToString();
            var spacesNeded = 10 - a.Length;
            var fruitSpace = "";
            for (int i = 0; i < spacesNeded; i++)
            {
                fruitSpace += " ";
            }
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(gameOverImg);
                Console.SetCursorPosition(16, Console.CursorTop - 7);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]FRUITS: {fruitAndScore[0]}{fruitSpace}SCORE: {fruitAndScore[1]}\r\n\r\n[/]");
                if (selector == 1)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                    > PLAY AGAIN\r\n[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                      PLAY AGAIN\r\n[/]");
                }
                if (selector == 0)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                    > MAIN MENU[/]");
                }
                else
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add($"[black on rgb(192,222,114)]                      MAIN MENU[/]");
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
                if ((input == ConsoleKey.W || input == ConsoleKey.UpArrow) && selector != 1)
                {
                    selector++;
                }
                if ((input == ConsoleKey.S || input == ConsoleKey.DownArrow) && selector != 0)
                {
                    selector--;
                }
            }
            return selector;
        }
    }
}
