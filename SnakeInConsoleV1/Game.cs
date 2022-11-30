using SnakeInConsoleV1.GameMenus;
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
            var getColors = new ColorSet();
            var getScore = new ScoreCounter();
            var getDifficulty = new Difficulty();
            var saveScoreAndName = new HiScores();
            var getScoreString = new RenderScore();
            var getPlayerInput = new PlayerInput();
            var getGameOverMenu = new GameOverMenu();
            var getSubMenuPlayAgain = new SubMenuPlayAgain();

            var gridX = new int[28];
            var gridY = new int[26];
            var fruitAndScore = new int[2];
            var keyList = new List<ConsoleKeyInfo>();

            var snake = getSnake.GetSnake();
            var color = getColors.GetGreenSet();
            var fruit = getFruit.SpawnFruit(snake);

            var level = 0;
            var score = 0;
            var index = 0;
            var sLengthMax = 503;
            var action = 'w';
            while (true)
            {
                if (snake.Count == sLengthMax && level < 3)
                {
                    level++;
                }
                if (level == 1 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    snake = getSnake.GetSnake();
                    color = getColors.GetBlueSet();
                }
                if (level == 2 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    snake = getSnake.GetSnake();
                    color = getColors.GetPurpleSet();
                }
                if (level == 3 && snake.Count >= sLengthMax)
                {
                    snake.RemoveRange(3, snake.Count - 3);
                    snake = getSnake.GetSnake();
                    color = getColors.GetRedSet();
                }
                string render = "";
                Console.Clear();
                action = getPlayerInput.GetPLayerInput(action, keyList);
                getSnake.MoveSnake(action);
                var snakeColided = snake.GroupBy(s => new { s.PosY, s.PosX }).Where(g => g.Count() > 1).Select(g => g.Key).FirstOrDefault();
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
                render += $"[white on rgb({color[0]})]{scoreString}\r\n[/]"; //border top
                for (int y = 0; y < gridY.Length; y++)
                {
                    render += $"[on rgb({color[0]})]  [/]"; //border
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
                            render += $"[on rgb({color[0]})]  [/]"; //snake
                        }
                        else
                        {
                            if (y == fruit.First().PosY && x == fruit.First().PosX)
                            {
                                render += $"[on rgb({color[2]})]  [/]"; //fruit
                            }
                            else
                            {
                                render += $"[on rgb({color[1]})]  [/]"; //background
                            }
                        }
                    }
                    render += $"[on rgb({color[0]})]  \r\n[/]"; //border
                }
                for (int x = 0; x <= gridX.Length + 1; x++)
                {
                    render += $"[on rgb({color[0]})]  [/]"; //border
                }
                AnsiConsole.Markup(render);
                getDifficulty.CurrentDifficulty(difficulty, level);
            }
            var playerName = getGameOverMenu.ShowGameOverMenu(fruitAndScore);
            saveScoreAndName.AddHiScore(playerName, fruitAndScore);
            var playAgain = getSubMenuPlayAgain.ShowSubMenuPlayAgain(fruitAndScore);
            if (playAgain == 1)
            {
                PlayGame(difficulty);
            }
        }
    }
}
