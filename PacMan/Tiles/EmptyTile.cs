using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Tiles
{
    class EmptyTile : Tile
    {
        public EmptyTile(int x, int y)
            : base(x, y, ' ') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            base.Draw();
        }
    }
}
