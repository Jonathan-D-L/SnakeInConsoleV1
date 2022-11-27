using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.GameMenus
{
    internal class GameOverMenu
    {
        public string ShowGameOverMenu(int[] fruitAndScore)
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
    }
}
