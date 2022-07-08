using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class RedGhost : Tile
    {
        public static event Action<Tile> RedGTileCreated;

        public RedGhost(int x, int y)
            : base(x, y, TileVisuals.GHOST_TILE, TileVisuals.RED_GHOST_COLOR)
        {
            RedGTileCreated?.Invoke(this);
        }
    }
}
