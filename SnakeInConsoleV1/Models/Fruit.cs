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
            var xPos = 0;
            var yPos = 0;
            for (int x = 0; x < 28; x++)
            {
                bool snX = snake.Any(s => s.PosY == x);
                bool fnX = fruit.Any(f => f.PosY == x);
                if (snX == false && fnX == false)
                {
                    listX.Add(xPos);
                }
                xPos++;
            }
            for (int y = 0; y < 26; y++)
            {
                bool snY = snake.Any(s => s.PosY == y);
                bool fnY = fruit.Any(f => f.PosY == y);
                if (snY == false && fnY == false)
                {
                    listY.Add(yPos);
                }
                yPos++;
            }
            var randX = rand.Next(listX.Count);
            var randY = rand.Next(listY.Count);
            fruit.Add(new Fruit { PosX = listX[randX], PosY = listY[randY] });
            if (fruit.Count > 1)
            {
                fruit.RemoveAt(0);
            }
            return fruit;
        }
        public List<Fruit> GetFruitPos()
        {
            return fruit;
        }
    }
}
