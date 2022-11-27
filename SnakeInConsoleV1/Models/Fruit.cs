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
            while (true)
            {
                var rand = new Random();
                var randX = rand.Next(0, 28);
                var randY = rand.Next(0, 26);
                bool fruitUnderSnake = snake.Any(s => s.PosX == randX && s.PosY == randY);
                if (fruitUnderSnake == false)
                {
                    fruit.Add(new Fruit { PosX = randX, PosY = randY });
                    if (fruit.Count > 1)
                    {
                        fruit.RemoveAt(0);
                    }
                    break;
                }

            }
            return fruit;
        }
        public List<Fruit> GetFruitPos()
        {
            return fruit;
        }
    }
}
