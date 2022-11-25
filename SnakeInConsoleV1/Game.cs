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

            bool readKey = false;
            bool lost = false;

            var gridY = new int[26];
            var gridX = new int[28];

            var action = '0';
            var preventFastInput = new List<char>() { 'w' };
            var fruit = getFruit.SpawnFruit();
            var score = 0;
            while (true)
            {
                var snake = getSnake.GetSnake();
                if (readKey == true)
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
                    else if (preventFastInput.Count <= 1) // breaks on not wasd
                    {
                        preventFastInput.Add(key.KeyChar);
                    }
                    readKey = false;
                }
                int index = 0;
                while (!Console.KeyAvailable)
                {
                    preventFastInput.Reverse();
                    action = preventFastInput.First();
                    if (preventFastInput.Count > 1)
                    {
                        preventFastInput.RemoveAt(1);
                    }
                    Console.Clear();
                    getSnake.MoveSnake(action);
                    if (snake.First().posX == fruit.First().posX && snake.First().posY == fruit.First().posY)
                    {
                        getSnake.getSnakeTail();
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
                        lost = true;
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
                                AnsiConsole.Markup($"[on rgb(78,95,39)]  [/]");
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
                readKey = true;
                if (lost == true)
                {
                    lost = false;
                    break;
                }
            }
            //=> GameArtLost
            Console.WriteLine("game over");
            Console.ReadKey();
            var goToStart = new StartMenu();
            goToStart.ShowStartMenu();
        }

    }
}
