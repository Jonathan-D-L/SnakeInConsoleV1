using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeInConsoleV1.Models;

namespace SnakeInConsoleV1.Models
{
    public class Fruit
    {
        List<Fruit> fruit = new();
        private int _posY;
        private int _posX;
        private Fruit(int posY, int posX)
        {
            _posY = posY;
            _posX = posX;
        }
        public Fruit()
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
        public List<Fruit> SpawnFruit(List<Snake> snake)
        {
            var rand = new Random();
            var listX = new List<int>();
            var listY = new List<int>();
            bool s = true;
            bool f = true;
            fruit.Clear();
            for (int y = 0; y < 26; y++)
            {
                s = snake.Any(s => s.PosY == y);
                f = fruit.Any(f => f.PosY == y);
                if (s == false && f == false)
                {
                    listY.Add(y);
                    for (int x = 0; x < 28; x++)
                    {
                        s = snake.Any(s => s.PosX == x);
                        f = fruit.Any(f => f.PosX == x);
                        if (s == false && f == false)
                        {
                            listX.Add(x);
                        }
                    }
                }
            }
            var randX = rand.Next(listX.Count);
            var randY = rand.Next(listY.Count);
            fruit.Add(new Fruit { PosX = listX[randX], PosY = listY[randY] });
            return fruit;
        }
        public List<Fruit> GetFruitPos()
        {
            return fruit;
        }
    }
}
