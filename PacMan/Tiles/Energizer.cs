using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Tiles
{
    class Energizer : Tile
    {
        public Energizer(int x, int y)
            : base(x, y, 'o') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
        }
    }
}
