using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeInConsoleV1.Models
{
    internal class Game
    {
        public void PlayGame()
        {
            var getSnake = new Snake();
            var getFruit = new Fruit();
            var getGameArt = new GameArt();
            var getScore = new SnakeScoreCounter();
            var saveScoreAndName = new SnakeHiScores();

            var gridY = new int[26];
            var gridX = new int[28];

            var action = 'w';
            var fruit = getFruit.SpawnFruit();
            var snake = getSnake.GetSnake();
            var score = 0;
            int index = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == 'w' && action == 's' ||
                        key.KeyChar == 's' && action == 'w' ||
                        key.KeyChar == 'a' && action == 'd' ||
                        key.KeyChar == 'd' && action == 'a' ||
                        key.KeyChar == 'w' && action == 'w' ||
                        key.KeyChar == 's' && action == 's' ||
                        key.KeyChar == 'a' && action == 'a' ||
                        key.KeyChar == 'd' && action == 'd')
                    {
                    }
                    else
                    {
                        action = key.KeyChar;
                    }
                }
                Console.Clear();
                getSnake.MoveSnake(action);
                if (snake.First().posX == fruit.First().posX && snake.First().posY == fruit.First().posY)
                {
                    getSnake.GetSnakeTail();
                    fruit = getFruit.SpawnFruit();
                    score++;
                }
                var snakeColided = snake
                    .GroupBy(i => new { i.posY, i.posX })
                    .Where(g => g
                    .Count() > 1)
                    .Select(g => g.Key)
                    .FirstOrDefault();
                if (snake.Any(s => s.posX == -1 || s.posX == 28 || s.posY == -1 || s.posY == 26 || snakeColided != null))
                {
                    break;
                }
                var snakeOrdered = snake.OrderBy(s => s.posY).ThenBy(s => s.posX).ToList();
                var scoreString = getScore.ScoreCounter(score);
                AnsiConsole.Markup($"[rgb(192,222,114) on rgb(78,95,39)]{scoreString}[/]");
                Console.Write("\r\n");
                for (int y = 0; y < gridY.Length; y++)
                {
                    AnsiConsole.Markup($"[on rgb(78,95,39)]  [/]");
                    for (int x = 0; x < gridX.Length; x++)
                    {
                        var s = snakeOrdered[index];
                        if (y == s.posY && x == s.posX)
                        {
                            if (index == snake.Count - 1)
                            {
                                index = 0;
                            }
                            else
                            {
                                index++;
                            }
                            AnsiConsole.Markup($"[white on rgb(78,95,39)]  [/]");
                        }
                        else
                        {
                            if (y == fruit.First().posY && x == fruit.First().posX)
                            {
                                AnsiConsole.Markup($"[on rgb(200,30,30)]  [/]");
                            }
                            else
                            {
                                AnsiConsole.Markup($"[on rgb(192,222,114)]  [/]");
                            }
                        }
                    }
                    AnsiConsole.Markup($"[on rgb(78,95,39)]  [/]");
                    Console.Write("\r\n");
                }
                for (int x = 0; x <= gridX.Length + 1; x++)
                {
                    AnsiConsole.Markup($"[on rgb(78,95,39)]  [/]");
                }
                System.Threading.Thread.Sleep(250);
            }
            var playerName = getGameArt.GameOverArt();
            saveScoreAndName.CheckHiscoresFile();
            saveScoreAndName.AddHiScore(playerName, score);
            var goToStart = new StartMenu();
            goToStart.ShowStartMenu();
        }

    }
}
