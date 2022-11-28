using SnakeInConsoleV1.GameMenus;
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
            var getGameOverMenu = new GameOverMenu();
            var getSubMenuPlayAgain = new SubMenuPlayAgain();
            var getScore = new ScoreCounter();
            var getScoreString = new RenderScore();
            var saveScoreAndName = new HiScores();
            var keyList = new List<ConsoleKeyInfo>();

            var gridY = new int[26];
            var gridX = new int[28];
            var fruitAndScore = new int[2];
            var renderData = new List<string>();
            var action = 'w';
            var snake = getSnake.GetSnake();
            var fruit = getFruit.SpawnFruit(snake);
            var score = 0;
            int index = 0;
            while (true)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    keyList.Add(key);
                }
                if (keyList.Count > 1)
                {
                    keyList.RemoveAt(0);
                }
                if (keyList.Count > 0)
                {
                    var singleKey = keyList.Last();
                    switch (singleKey.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (action != 's')
                                action = 'w';
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (action != 'w')
                                action = 's';
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (action != 'd')
                                action = 'a';
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (action != 'a')
                                action = 'd';
                            break;
                    }
                }
                Console.Clear();
                getSnake.MoveSnake(action);
                var snakeColided = snake.GroupBy(i => new { i.PosY, i.PosX }).Where(g => g.Count() > 1).Select(g => g.Key).FirstOrDefault();
                if (snake.Any(s => s.PosX == -1 || s.PosX == 28 || s.PosY == -1 || s.PosY == 26) || snakeColided != null)
                {
                    break;
                }
                if (snake.First().PosX == fruit.First().PosX && snake.First().PosY == fruit.First().PosY)
                {
                    getSnake.GetSnakeTail();
                    fruit = getFruit.SpawnFruit(snake);
                    score++;
                }
                var snakeOrdered = snake.OrderBy(s => s.PosY).ThenBy(s => s.PosX).ToList();
                fruitAndScore = getScore.GetScore(score, difficulty);
                var scoreString = getScoreString.ScoreToRendableString(fruitAndScore);
                renderData.Add($"[rgb(192,222,114) on rgb(78,95,39)]{scoreString}[/]");
                renderData.Add("\r\n");
                for (int y = 0; y < gridY.Length; y++)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    for (int x = 0; x < gridX.Length; x++)
                    {
                        var s = snakeOrdered[index];
                        if (y == s.PosY && x == s.PosX)
                        {
                            if (index == snake.Count - 1)
                            {
                                index = 0;
                            }
                            else
                            {
                                index++;
                            }
                            renderData.Add($"[white on rgb(78,95,39)]  [/]");
                        }
                        else
                        {
                            if (y == fruit.First().PosY && x == fruit.First().PosX)
                            {
                                renderData.Add($"[on rgb(200,30,30)]  [/]");
                            }
                            else
                            {
                                renderData.Add($"[on rgb(192,222,114)]  [/]");
                            }
                        }
                    }
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                    renderData.Add("\r\n");
                }
                for (int x = 0; x <= gridX.Length + 1; x++)
                {
                    renderData.Add($"[on rgb(78,95,39)]  [/]");
                }
                string render = "";
                for (int y = 0; y < renderData.Count; ++y)
                {
                    render += (renderData[y]);
                }
                AnsiConsole.Markup(render);
                renderData.Clear();
                if (difficulty == 0)
                    System.Threading.Thread.Sleep(250);
                else if (difficulty == 1)
                    System.Threading.Thread.Sleep(150);
                else if (difficulty == 2)
                    System.Threading.Thread.Sleep(75);
            }
            var playerName = getGameOverMenu.ShowGameOverMenu(fruitAndScore);
            saveScoreAndName.AddHiScore(playerName, fruitAndScore);
            var playAgain = getSubMenuPlayAgain.ShowSubMenuPlayAgain(fruitAndScore);
            if (playAgain == 1)
            {
                PlayGame(difficulty);
            }
            if (playAgain == 0)
            {

            }
        }
    }
}
