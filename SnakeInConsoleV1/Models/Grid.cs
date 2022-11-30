using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeInConsoleV1.Models
{
    public class Grid
    {
        List<Grid> grid = new();
        private int _posY;
        private int _posX;
        private Grid(int posY, int posX)
        {
            _posY = posY;
            _posX = posX;
        }
        public Grid()
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
        public List<Grid> GetGrid()
        {
            for (int y = 0; y < 26; y++)
            {
                for (int x = 0; x < 28; x++)
                {
                    grid.Add(new Grid { PosX = x, PosY = y });
                }
            }
            return grid;
        }
    }
}
