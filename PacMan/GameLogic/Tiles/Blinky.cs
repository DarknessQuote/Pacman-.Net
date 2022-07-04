using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Blinky : Tile
    {
        public static event Action<Tile> BlinkyTileCreated;

        public Blinky(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.BLINKY_COLOR)
        {
            BlinkyTileCreated?.Invoke(this);
        }
    }
}
