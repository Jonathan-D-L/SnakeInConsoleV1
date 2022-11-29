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

namespace SnakeInConsoleV1.Models
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
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public List<Snake> GetSnake()
        {
            if (snakeLength.Count == 0)
            {
                snakeLength.Add(new Snake { PosX = 13, PosY = 11 });
                snakeLength.Add(new Snake { PosX = 13, PosY = 12 });
                snakeLength.Add(new Snake { PosX = 13, PosY = 13 });
            }
            return snakeLength;
        }
        public List<Snake> GetSnakeTail()
        {
            var last = snakeLength[^1];
            var prior = snakeLength[^2];
            var posY = 0;
            var posX = 0;
            if (prior.PosY == last.PosY)
            {
                if (prior.PosX < last.PosX)
                {
                    posY = last.PosY;
                    posX = last.PosX + 1;
                }
                if (prior.PosX > last.PosX)
                {
                    posY = last.PosY;
                    posX = last.PosX - 1;
                }
            }
            if (prior.PosX == last.PosX)
            {
                if (prior.PosY < last.PosY)
                {
                    posY = last.PosY + 1;
                    posX = last.PosX;
                }
                if (prior.PosY > last.PosY)
                {
                    posY = last.PosY - 1;
                    posX = last.PosX;
                }
            }
            snakeLength.Add(new Snake { PosX = posX, PosY = posY });
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
                    currentY = s.PosY;
                    prevX = currentX;
                    currentX = s.PosX;
                    if (prevX != -1 && prevY != -1)
                    {
                        s.PosX = prevX;
                        s.PosY = prevY;
                    }
                }
                if (action == 'w')
                {
                    snakeLength.Select(s => s).First().PosY--;
                }
                if (action == 's')
                {
                    snakeLength.Select(s => s).First().PosY++;
                }
                if (action == 'a')
                {
                    snakeLength.Select(s => s).First().PosX--;
                }
                if (action == 'd')
                {
                    snakeLength.Select(s => s).First().PosX++;
                }
            }
        }
    }
}
