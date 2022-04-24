using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Tiles
{
    class Dot : Tile
    {
        public Dot(int x, int y)
            : base(x, y, '·') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
        }
    }
}
