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
using System.Xml.Linq;
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
                //maxX = 56, maxY = 26.
                snakeLength.Add(new Snake { posX = 13, posY = 12 });
            }
            return snakeLength;
        }

        public void MoveSnake(char action)
        {
            if (action != '0')
            {
                int prevY = -1;
                int currentY = -1;
                int prevX = -1;
                int currentX = -1;
                foreach (var s in snakeLength)
                {
                    prevY = currentY;
                    currentY = s.posY;
                    prevX = currentX;
                    currentX = s.posX;
                    if (prevX != -1 && prevY != -1)
                    {
                        s.posX = prevX;
                        s.posY = prevY;
                    }
                }
                if (action == 'w')
                {
                    snakeLength.Select(s => s).First().posY--;
                }
                if (action == 's')
                {
                    snakeLength.Select(s => s).First().posY++;
                }
                if (action == 'a')
                {
                    snakeLength.Select(s => s).First().posX--;
                }
                if (action == 'd')
                {
                    snakeLength.Select(s => s).First().posX++;
                }
            }
        }
    }
}
