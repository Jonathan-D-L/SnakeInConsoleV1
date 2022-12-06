using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeInConsoleV1.Models;
using Spectre.Console;

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
            var getGrid = Grid.Instance;
            var grid = getGrid.GetGrid();
            grid.RemoveAll(g => snake.Exists(s => s.PosX == g.PosX && s.PosY == g.PosY));
            grid.RemoveAll(g => fruit.Exists(f => f.PosX == g.PosX && f.PosY == g.PosY));
            var newFruitPos = grid[rand.Next(grid.Count)];
            fruit.Clear();
            fruit.Add(new Fruit { PosX = newFruitPos.PosX, PosY = newFruitPos.PosY });
            return fruit;
        }
        public List<Fruit> GetFruitPos()
        {
            return fruit;
        }
    }
}
