using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Tile
    {
        public int y;
        public int x;
        public char tileSymbol;

        public Tile(int y, int x, char symbol)
        {
            this.y = y;
            this.x = x;
            tileSymbol = symbol;
        }

        public virtual void Draw()
        {
            Console.Write(tileSymbol);
        }
    }
}
