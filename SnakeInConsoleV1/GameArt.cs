using SixLabors.ImageSharp.ColorSpaces;
using SnakeInConsoleV1.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                System.Threading.Thread.Sleep(250);
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
        public int ShowSubMenuDifficulty(int selector)
        {
            var startImg = new CanvasImage("images\\Start.png");
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);

                if (selector == 0)
                {
                    Console.SetCursorPosition(18, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> EASY[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop - 6);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]EASY[/]");
                }
                if (selector == 1)
                {
                    Console.SetCursorPosition(18, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> NORMAL[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]NORMAL[/]");
                }
                if (selector == 2)
                {
                    Console.SetCursorPosition(18, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> HARD[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]HARD[/]");
                }
                if (selector == 3)
                {
                    Console.SetCursorPosition(18, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]> BACK[/]");
                }
                else
                {
                    Console.SetCursorPosition(20, Console.CursorTop + 1);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]BACK[/]");
                }
                Console.SetCursorPosition(34, Console.CursorTop - 3);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] W [/]");
                Console.SetCursorPosition(32, Console.CursorTop + 1);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] A [/]");
                Console.SetCursorPosition(34, Console.CursorTop);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] S [/]");
                Console.SetCursorPosition(36, Console.CursorTop);
                AnsiConsole.Markup($"[black on rgb(192,222,114)] D [/]");
                Console.SetCursorPosition(32, Console.CursorTop + 1);
                AnsiConsole.Markup($"[black on rgb(192,222,114)],_____,[/]");
                System.Threading.Thread.Sleep(250);
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
                    if (input == 's' && selector != 3)
                    {
                        selector++;
                    }
                }
            }
            return selector;
        }
        public string ShowGameOver()
        {
            var startImg = new CanvasImage("images\\GameOver.png");
            var playerName = string.Empty;
            while (true)
            {
                Console.Clear();
                AnsiConsole.Write(startImg);
                Console.SetCursorPosition(18, Console.CursorTop - 6);
                AnsiConsole.Markup($"[black on rgb(192,222,114)]ENTER NAME: {playerName}[/]");
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
                else if ((char.IsLetter(input) || char.IsDigit(input) || char.IsWhiteSpace(input)) && playerName.Length < 15 && input != (char)8)
                {
                    playerName += input.ToString();
                }
            }
            return playerName;
        }
        public void ShowHiscores(List<playerScore> hiScores)
        {
            var scoreBoard = new CanvasImage("images\\ScoreBoard.png");
            Console.Clear();
            AnsiConsole.Write(scoreBoard);
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
            Console.ReadKey();
        }
    }
}
