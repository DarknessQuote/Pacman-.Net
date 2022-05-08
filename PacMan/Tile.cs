using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Tile
    {
        protected int x;
        protected int y;
        protected char tileSymbol;

        public Tile(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            tileSymbol = symbol;
        }

        public virtual void Draw()
        {
            Console.Write(tileSymbol);
        }

        public (int, int) GetCoordinates()
        {
            return (x, y);
        }
    }
}
