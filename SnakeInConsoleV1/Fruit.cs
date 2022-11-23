using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    public class Fruit
    {
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
    }
}
