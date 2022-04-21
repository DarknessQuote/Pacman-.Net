using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    class Clyde : Tile
    {
        public Clyde(int x, int y)
            : base(x, y, ConsoleColor.DarkYellow, 'A') {}
    }
}
