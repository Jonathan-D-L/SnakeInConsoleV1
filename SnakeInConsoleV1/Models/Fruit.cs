﻿using System;
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
            var getSnake = new Snake();
            var snake = getSnake.GetSnake();
            var rand = new Random();
            while (true)
            {
                var randX = posX = rand.Next(0, 28);
                var randY = posY = rand.Next(0, 26);
                if (snake.All(s => s.posX != randX) && snake.All(s => s.posY != randY))
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
        public List<Fruit> GetFruitPos()
        {
            return fruit;
        }
    }
}
