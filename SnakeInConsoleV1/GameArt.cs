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
        public int ShowStartMenu()
        {
            var startImg = new CanvasImage("images\\Start.png");
            var selector = 0;
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);

                if (selector == 0)
                {
                    Console.SetCursorPosition(22, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> PLAY[/]");
                }
                else
                {
                    Console.SetCursorPosition(24, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]PLAY[/]");
                }
                if (selector == 1)
                {
                    Console.SetCursorPosition(22, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> HISCORES[/]");
                }
                else
                {
                    Console.SetCursorPosition(24, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]HISCORES[/]");
                }
                if (selector == 2)
                {
                    Console.SetCursorPosition(22, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> QUIT[/]");
                }
                else
                {
                    Console.SetCursorPosition(24, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]QUIT[/]");
                }
                System.Threading.Thread.Sleep(1000);
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey().KeyChar;
                    if (input == (char)13)
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
            Console.ReadKey(false);
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
            foreach(var hS in hiScores)
            {
                Console.WriteLine(hS);
            }
            Console.ReadLine();
        }
    }
}
