using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SnakeInConsoleV1.Models
{
    internal class Game
    {
        public void PlayGame(int difficulty)
        {
            var getSnake = new Snake();
            var getFruit = new Fruit();
            var getGameArt = new GameArt();
            var getScore = new ScoreCounter();
            var saveScoreAndName = new HiScores();

            var gridY = new int[26];
            var gridX = new int[28];

            var action = 'w';
            var fruit = getFruit.SpawnFruit();
            var snake = getSnake.GetSnake();
            var score = 0;
            int index = 0;
            while (true)
            {

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
                var scoreString = getScore.GetScore(score);
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
                if (difficulty == 0)
                    System.Threading.Thread.Sleep(250);
                else if (difficulty == 1)
                    System.Threading.Thread.Sleep(150);
                else if (difficulty == 2)
                    System.Threading.Thread.Sleep(75);
                var keyList = new List<ConsoleKeyInfo>();
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    keyList.Add(key);
                    if (keyList.Count > 1)
                    {
                        keyList.RemoveAt(1);
                    }
                }
                if (keyList.Count > 0)
                {
                    var singleKey = keyList.First();
                    switch (singleKey.Key)
                    {
                        case ConsoleKey.W:
                            if (action != 's')
                                action = 'w';
                            break;
                        case ConsoleKey.S:
                            if (action != 'w')
                                action = 's';
                            break;
                        case ConsoleKey.A:
                            if (action != 'd')
                                action = 'a';
                            break;
                        case ConsoleKey.D:
                            if (action != 'a')
                                action = 'd';
                            break;
                    }
                }
            }
            var playerName = getGameArt.ShowGameOver();
            saveScoreAndName.AddHiScore(playerName, score, difficulty);
        }

    }
}
