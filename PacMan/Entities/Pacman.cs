using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    class Pacman : Tile
    {
        public Pacman(int x, int y)
            : base (x, y, ConsoleColor.Yellow, 'c') {}
    }
}
