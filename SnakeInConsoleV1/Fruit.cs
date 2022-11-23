using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
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
        public List<Fruit> SpawnFruit()
        {
            bool snakeEatFruit = false;
            var getSnake = new Snake();
            var snake = getSnake.SnakeLength(snakeEatFruit);
            var rand = new Random();
            while (true)
            {
                var randX = posX = rand.Next(0, 28);
                var randY = posY = rand.Next(0, 26);
                if (!snake.Any(s => s.posX == randX) && !snake.Any(s => s.posY == randY))
                {
                    fruit.Add(new Fruit { posX = randX, posY = randY });
                    if (fruit.Count > 1)
                    {
                        fruit.RemoveAt(0);
                    }
                    break;
                }
            }
            return fruit;
        }
    }
}
