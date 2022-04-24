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
        protected ConsoleColor tileColor;
        protected char tileSymbol;

        public Tile(int x, int y, ConsoleColor color, char symbol)
        {
            this.x = x;
            this.y = y;
            tileColor = color;
            tileSymbol = symbol;
        }

        public void Draw()
        {
            Console.ForegroundColor = tileColor;
            Console.Write(tileSymbol);
        }

        public (int, int) GetTile()
        {
            return (x, y);
        }
    }
}
