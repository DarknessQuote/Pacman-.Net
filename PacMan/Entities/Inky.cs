using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    class Inky : Tile
    {
        public Inky(int x, int y)
            : base(x, y, ConsoleColor.Cyan, 'A') {}
    }
}
