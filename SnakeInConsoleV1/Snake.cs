using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeInConsoleV1
{
    public class Snake
    {
        List<Snake> snakeLength = new();
        private int _posY;
        private int _posX;
        private Snake(int posY, int posX)
        {
            _posY = posY;
            _posX = posX;
        }
        public Snake()
        {
        }
        public int posY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public int posX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public List<Snake> SnakeLength()
        {
            if (snakeLength.Count == 0)
            {
                var snakeStart0 = new Snake(posX = 4, posY = 4); //maxX = 56, maxY = 26.
                snakeLength.Add(snakeStart0);
                var snakeStart1 = new Snake(posX = 5, posY = 4);
                snakeLength.Add(snakeStart1);
                var snakeStart2 = new Snake(posX = 6, posY = 4);
                snakeLength.Add(snakeStart2);
                var snakeStart3 = new Snake(posX = 6, posY = 5);
                snakeLength.Add(snakeStart3);
            }
            return snakeLength;

        }

        public void MoveSnake(char action)
        {
            bool input = false;
            if (action == 'w')
            {
                snakeLength.Select(s => s).First().posY--;
                input = true;
            }
            if (action == 's')
            {
                snakeLength.Select(s => s).First().posY++;
                input = true;
            }
            if (action == 'a')
            {
                snakeLength.Select(s => s).First().posX--;
                input = true;
            }
            if (action == 'd')
            {
                snakeLength.Select(s => s).First().posX++;
                input = true;
            }
            if (input == true)
            {
                int prevY = 0;
                int currentY = 0;
                int prevX = 0;
                int currentX = 0;
                var i = 0;
                foreach (var s in snakeLength)
                {
                    prevY = currentY;
                    currentY = s.posY;
                    prevX = currentX;
                    currentX = s.posX;
                    if (i != 0)
                    {
                        s.posY = prevY;
                        s.posX = prevX;
                    }
                    else
                    {
                        i++;
                    }
                }
                input = false;
            }

        }
    }
}
