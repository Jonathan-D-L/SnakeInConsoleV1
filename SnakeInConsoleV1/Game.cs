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
            var bluePixel = new CanvasImage("images\\BluePixel.png");
            var greenPixel = new CanvasImage("images\\GreenPixel.png");
            var darkGreenPixel = new CanvasImage("images\\DarkGreenPixel.png");
            var orangePixel = new CanvasImage("images\\OrangePixel.png");
            var test = new CanvasImage("images\\test.png");

            var getSnake = new Snake();
            var getFruit = new Fruit();
            bool readKey = false;
            var gridY = new int[26];
            var gridX = new int[28];
            var action = '0';
            bool lost = false;
            bool snakeEatFruit = false;
            var preventFastInput = new List<char>() { '0' };
            var countDots = 0;
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                AnsiConsole.Write(test);
                Console.SetCursorPosition(15, Console.CursorTop - 6);
                Console.Write($"                             \r\n");
                Console.SetCursorPosition(15, Console.CursorTop);
                if (countDots == 0)
                    Console.Write($"  press any key to start     \r\n");
                if (countDots == 1)
                    Console.Write($"  press any key to start.    \r\n");
                if (countDots == 2)
                    Console.Write($"  press any key to start..   \r\n");
                if (countDots == 3)

                    Console.Write($"  press any key to start...  \r\n");
                countDots++;
                if (countDots == 4)
                    countDots = 0;
                Console.SetCursorPosition(15, Console.CursorTop);
                Console.Write($"                             ");
                System.Threading.Thread.Sleep(500);
            }
            var fruit = getFruit.SpawnFruit();
            while (true)
            {
                var snake = getSnake.SnakeLength(snakeEatFruit);
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
                    else if (preventFastInput.Count <= 1)
                    {
                        preventFastInput.Add(key.KeyChar);
                    }
                    readKey = false;
                }
                int index = 0;
                int posCursor = 0;
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
                        fruit = getFruit.SpawnFruit();
                        snakeEatFruit = true;
                        getSnake.SnakeLength(snakeEatFruit);
                        snakeEatFruit = false;
                    }
                    var snakeColided = snake
                        .GroupBy(i => new { i.posY, i.posX })
                        .Where(g => g
                        .Count() > 1)
                        .Select(g => g.Key)
                        .FirstOrDefault();
                    if (snake.Any(s => s.posX == -1 || s.posX == 28 || s.posY == -1 || s.posY == 26 || snakeColided != null))
                    {
                        //AnsiConsole.Write();
                        lost = true;
                        break;
                    }
                    var snake1 = snake.OrderBy(s => s.posY).ThenBy(s => s.posX).ToList();
                    for (int x = 0; x <= gridX.Length + 1; x++)
                    {
                        AnsiConsole.Write(darkGreenPixel);
                        posCursor = (x * 2) + 2;
                        Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                    }
                    Console.Write("\r\n");

                    for (int y = 0; y < gridY.Length; y++)
                    {
                        AnsiConsole.Write(darkGreenPixel);
                        posCursor = 2;
                        Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                        for (int x = 0; x < gridX.Length; x++)
                        {
                            var s = snake1[index];
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
                                AnsiConsole.Write(darkGreenPixel);
                                posCursor = (x * 2) + 4;
                                Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                            }
                            else
                            {
                                if (y == fruit.First().posY && x == fruit.First().posX)
                                {
                                    AnsiConsole.Write(orangePixel);
                                    posCursor = (x * 2) + 4;
                                    Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                                }
                                else
                                {
                                    AnsiConsole.Write(greenPixel);
                                    posCursor = (x * 2) + 4;
                                    Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                                }
                            }
                        }
                        AnsiConsole.Write(darkGreenPixel);
                        posCursor = 56;
                        Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                        Console.Write("\r\n");
                    }
                    for (int x = 0; x <= gridX.Length + 1; x++)
                    {
                        AnsiConsole.Write(darkGreenPixel);
                        posCursor = (x * 2) + 2;
                        Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
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
        }

    }
}
