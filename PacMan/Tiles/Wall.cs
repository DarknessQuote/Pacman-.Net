using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Tiles
{
    class Wall : Tile
    {
        public Wall(int x, int y)
            : base(x, y, ConsoleColor.DarkBlue, '#') {}
    }
}
