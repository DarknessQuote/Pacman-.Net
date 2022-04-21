using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    class Blinky : Tile
    {
        public Blinky(int x, int y)
            : base(x, y, ConsoleColor.Red, 'A') {}
    }
}
