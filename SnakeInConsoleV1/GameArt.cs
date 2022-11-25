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
        public int ShowStartMenu(int selector)
        {
            var startImg = new CanvasImage("images\\Start.png");
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);

                if (selector == 0)
                {
                    Console.SetCursorPosition(18, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> PLAY[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]PLAY[/]");
                }
                if (selector == 1)
                {
                    Console.SetCursorPosition(18, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> HISCORES[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]HISCORES[/]");
                }
                if (selector == 2)
                {
                    Console.SetCursorPosition(18, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> QUIT[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]QUIT[/]");
                }
                Console.SetCursorPosition(34, Console.CursorTop - 2);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] W [/]");
                Console.SetCursorPosition(32, Console.CursorTop + 1);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] A [/]");
                Console.SetCursorPosition(34, Console.CursorTop);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] S [/]");
                Console.SetCursorPosition(36, Console.CursorTop);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] D [/]");
                Console.SetCursorPosition(32, Console.CursorTop + 1);
                AnsiConsole.Markup($"[black on rgb(192,222,114)],_____,[/]");
                System.Threading.Thread.Sleep(1000);
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey().KeyChar;
                    if (input == ' ')
                    {
                        break;
                    }
                    if (input == 'w' && selector != 0)
                    {
                        selector--;
                    }
                    if (input == 's' && selector != 2)
                    {
                        selector++;
                    }
                }
            }
            return selector;
        }
        public string ShowGameOven()
        {
            var startImg = new CanvasImage("images\\GameOver.png");
            var playerName = string.Empty;
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                Console.SetCursorPosition(18, Console.CursorTop - 6);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]ENTER NAME: {playerName.ToUpper()}[/]");
                var input = Console.ReadKey().KeyChar;
                if (input == (char)8)
                {
                    if (playerName.Length != 0)
                    {
                        Console.Write("\a \b");
                        playerName = playerName.Remove(playerName.Length - 1);
                    }
                }
                if (input == (char)13)
                {
                    var space = ' ';
                    if (playerName.All(x => x == space))
                    {
                        playerName = string.Empty;
                    }
                    break;
                }
                else if (input != '[' && input != ']' && playerName.Length < 20 && input != (char)8)
                {
                    playerName += input.ToString();
                }
            }
            return playerName;
        }
        public void ShowHiscores(List<string> hiScores)
        {
            Console.Clear();
            var sortedHiScores = hiScores.OrderByDescending(h => Convert.ToInt32(h.Split(' ')[1])).ToList();
            var top10 = 0;
            foreach (var sHS in sortedHiScores)
            {
                if (top10 < 1)
                {
                    Console.WriteLine(sHS);
                    top10++;
                }
                else
                {
                    break;
                }
            }
            if (hiScores.Count == 0)
            {
                Console.WriteLine("NO SCORE");
            }
            Console.ReadKey();
        }
    }
}
