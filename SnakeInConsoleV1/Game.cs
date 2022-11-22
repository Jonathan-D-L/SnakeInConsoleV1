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
            var orangePixel = new CanvasImage("images\\OrangePixel.png");
            var getSnake = new Snake();
            var action = '0';
            bool readKey = false;
            var gridY = new int[24];
            var gridX = new int[54];
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
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    getSnake.MoveSnake(action);
                    int prev = 0;
                    int current = 0;
                    foreach (var s in snake)
                    {
                        prev = current;
                        current = s.posY;
                        for (int i = 0; i < current-prev; i++)
                        {
                            Console.Write("\r\n");
                        }
                        for (int y = 0; y < gridY.Length; y++)
                        {

                            for (int x = 0; x < gridX.Length; x++)
                            {
                                if (x == s.posX && y == s.posY)
                                {
                                    Console.Write("[]");
                                }
                                else if (x != s.posX && y == s.posY)
                                {
                                    Console.Write("| ");
                                }
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
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