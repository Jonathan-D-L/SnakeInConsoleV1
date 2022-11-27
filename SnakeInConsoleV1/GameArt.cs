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
            return selector;
        }
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
            return selector;
        }
        public string ShowGameOver(int[] fruitAndScore)
        {
            var gameOverImg = new CanvasImage("images\\GameOver.png");
            var playerName = string.Empty;
            var getHiScores = new HiScores();
            var hiScores = getHiScores.GetHiScoresFromFile();
            var fruit = fruitAndScore[0];
            var a = fruit.ToString();
            var spacesNeded = 10 - a.Length;
            var fruitSpace = "";
            for (int i = 0; i < spacesNeded; i++)
            {
                fruitSpace += " ";
            }

            if (hiScores.Any(s => s.Score < fruitAndScore[1]) || hiScores.Count < 10)
            {
                while (true)
                {
                    Console.Clear();
                    AnsiConsole.Write(gameOverImg);
                    Console.SetCursorPosition(16, Console.CursorTop - 7);
                    AnsiConsole.Markup($"[black on rgb(192,222,114)]FRUITS: {fruitAndScore[0]}{fruitSpace}SCORE: {fruitAndScore[1]}[/]");
                    Console.SetCursorPosition(16, Console.CursorTop + 2);
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
                        if (playerName.All(x => x == space) || playerName.Length == 0)
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
            }
            return playerName;
        }
        public void ShowHiscores(List<playerScore> hiScores)
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
                Console.SetCursorPosition(0, Console.CursorTop + 3);
                var input = Console.ReadKey().KeyChar;
                if (input == ' ')
                {
                    break;
                }
                if (input == 'w' && selector != 1)
                {
                    selector++;
                }
                if (input == 's' && selector != 0)
                {
                    selector--;
                }
            }
            return selector;
        }
    }
}
