using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeInConsoleV1
{
    internal class Game
    {
        public void PlayGame()
        {
            var bluePixel = new CanvasImage("images\\BluePixel.png");
            var greenPixel = new CanvasImage("images\\GreenPixel.png");
            var darkGreenPixel = new CanvasImage("images\\DarkGreenPixel.png");
            var orangePixel = new CanvasImage("images\\OrangePixel.png");
            var getSnake = new Snake();
            var action = '0';
            bool readKey = false;
            var gridY = new int[26];
            var gridX = new int[28];
            while (true)
            {
                var snake = getSnake.SnakeLength();
                //var posCursor = X.Length + 1;
                //Console.SetCursorPosition(posCursor, Console.CursorTop - 1);
                if (readKey == true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    action = key.KeyChar; // if not wasd dont
                    readKey = false;
                }
                int index = 0;
                int posCursor = 0;
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    getSnake.MoveSnake(action);
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
                            var s = snake[0];
                            if (y == s.posY && x == s.posX)
                            {
                                if (index == snake.Count - 1)
                                {
                                    index = 0;
                                }
                                index++;
                                AnsiConsole.Write(bluePixel);
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
                    System.Threading.Thread.Sleep(500);
                }
                action = '0';
                readKey = true;
            }
        }

    }
}

//int yCount = 0;
//int xCount = 0;
//foreach (var s in snake)
//{
//    if (s.posX == xCount)
//    {
//        for (int x = xCount; x <= s.posX; x++)
//        {
//            if (s.posX == x)
//            {
//                Console.Write("[]");
//                xCount = 0;
//                break;
//            }
//            else
//            {
//                Console.Write("  ");
//            }
//        }
//    }
//    else
//    {
//        for (int y = yCount; y <= s.posY; y++)
//        {
//            if (s.posY == y)
//            {
//                for (int x = xCount; x <= s.posX; x++)
//                {
//                    if (s.posX == x)
//                    {
//                        Console.Write("[]");
//                        xCount =x;
//                        yCount =y;
//                        break;
//                    }
//                    else
//                    {
//                        Console.Write("  ");
//                    }
//                }
//                break;
//            }
//            else
//            {
//                Console.Write("\r\n");
//            }
//        }
//    }
//}