using SnakeInConsoleV1.GameMenus;
using SnakeInConsoleV1.Helpers;
using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;


namespace SnakeInConsoleV1.Models
{
    internal class Game
    {
        public void PlayGame(int difficulty)
        {
            var getSnake = new Snake();
            var getFruit = new Fruit();

            var gridX = new int[28];
            var gridY = new int[26];
            var fruitAndScore = new int[3];
            var keyList = new List<ConsoleKeyInfo>();

            var snake = getSnake.GetSnake();
            var color = ColorSetHelper.GetGreenSet();
            var fruit = getFruit.SpawnFruit(snake);

            var level = 0;
            var score = 0;
            var index = 0;
            var sLengthMax = 503;
            var action = 'w';
            while (true)
            {
                if (snake.Count == sLengthMax && level < 4)
                {
                    level++;
                }
                if (level == 1 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    color = ColorSetHelper.GetBlueSet();
                }
                if (level == 2 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    color = ColorSetHelper.GetPurpleSet();
                }
                if (level == 3 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    color = ColorSetHelper.GetRedSet();
                }
                var render = string.Empty;
                action = PlayerInputHelper.GetPLayerInput(action, keyList);
                getSnake.MoveSnake(action);
                var snakeColided = snake.GroupBy(s => new { s.PosY, s.PosX }).Where(g => g.Count() > 1).Select(g => g.Key).FirstOrDefault();
                if (snake.Any(s => s.PosX == -1 || s.PosX == 28 || s.PosY == -1 || s.PosY == 26) || snakeColided != null)
                {
                    break;
                }
                if (snake.First().PosX == fruit.First().PosX && snake.First().PosY == fruit.First().PosY)
                {
                    getSnake.GetSnakeTail();
                    snake = getSnake.GetSnake();
                    fruit = getFruit.SpawnFruit(snake);
                    score++;
                }
                var snakeOrdered = snake.OrderBy(s => s.PosY).ThenBy(s => s.PosX).ToList();
                fruitAndScore = ScoreCountHelper.GetScore(score, difficulty, level);
                var scoreString = RenderScoreHelper.ScoreToRendableString(fruitAndScore);
                var listToRender = new List<string>();
                listToRender.Add($"[white on rgb({color[0]})]{scoreString}\r\n[/]"); //border top
                for (int y = 0; y < gridY.Length; y++)
                {
                    listToRender.Add($"[on rgb({color[0]})]  [/]"); //border
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
                            if (listToRender.Last().Contains(color[0]) && listToRender.Count > 0)
                            {
                                var lastRender = listToRender.Select(r => r).Last();
                                var squarePixel = lastRender.Insert(20, "  ");
                                listToRender.RemoveAt(listToRender.Count - 1);
                                listToRender.Add(squarePixel);
                            }
                            else
                            {
                                listToRender.Add($"[on rgb({color[0]})]  [/]"); //snake
                            }
                        }
                        else
                        {
                            if (y == fruit.First().PosY && x == fruit.First().PosX)
                            {
                                listToRender.Add($"[on rgb({color[2]})]  [/]"); //fruit
                            }
                            else
                            {
                                if (listToRender.Last().Contains(color[1]) && listToRender.Count > 0)
                                {
                                    var lastRender = listToRender.Select(r => r).Last();
                                    var squarePixel = lastRender.Insert(21, "  ");
                                    listToRender.RemoveAt(listToRender.Count - 1);
                                    listToRender.Add(squarePixel);
                                }
                                else
                                {
                                    listToRender.Add($"[on rgb({color[1]})]  [/]"); //background
                                }
                            }
                        }
                    }
                    listToRender.Add($"[on rgb({color[0]})]  \r\n[/]"); //border
                }
                listToRender.Add($"[on rgb({color[0]})]                         " +
                        $"                                   [/]"); //border
                foreach (var r in listToRender)
                {
                    render += r;
                }
                Console.Clear();
                AnsiConsole.Markup(render);
                DifficultyHelper.CurrentDifficultySpeed(difficulty, level);
            }
            var playerName = GameOverMenu.ShowGameOverMenu(fruitAndScore);
            HiScoresHelper.AddHiScore(playerName, fruitAndScore);
            var playAgain = SubMenuPlayAgain.ShowSubMenuPlayAgain(fruitAndScore);
            if (playAgain == 1)
            {
                PlayGame(difficulty);
            }
        }
    }
}
