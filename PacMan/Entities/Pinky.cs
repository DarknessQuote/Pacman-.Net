using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    class Pinky : Tile
    {
        public Pinky(int x, int y)
            : base(x, y, 'A') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            base.Draw();
        }
    }
}
