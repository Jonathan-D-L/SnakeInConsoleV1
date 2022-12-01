using SnakeInConsoleV1.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.GameMenus
{
    internal static class SubHiscoresMenu
    {
        public static void ShowHiscoresMenu(List<playerScore> hiScores)
        {
            var scoreBoardImg = new CanvasImage("images\\ScoreBoard.png");
            Console.Clear();
            AnsiConsole.Write(scoreBoardImg);
            Console.SetCursorPosition(13, Console.CursorTop - 18);
            AnsiConsole.Markup($"[black on rgb(192,222,114)]~~~~~~~~~~~ SCOREBOARD ~~~~~~~~~~~[/]");
            Console.SetCursorPosition(15, Console.CursorTop + 2);
            AnsiConsole.Markup($"[black on rgb(192,222,114)]NAME[/]");
            Console.SetCursorPosition(33, Console.CursorTop);
            AnsiConsole.Markup($"[black on rgb(192,222,114)]SCORE[/]");
            Console.SetCursorPosition(0, Console.CursorTop);
            foreach (var h in hiScores)
            {
                Console.SetCursorPosition(15, Console.CursorTop + 1);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]{h.Name}[/]");
                Console.SetCursorPosition(33, Console.CursorTop);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]{h.Score}[/]");
            }
            Console.SetCursorPosition(0, Console.CursorTop + 6);
            Console.ReadKey();
        }
    }
}
