using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class PinkGhost : Tile
    {
        public static event Action<Tile> PinkGTileCreated;

        public PinkGhost(int x, int y)
            : base(x, y, TileVisuals.GHOST_TILE, TileVisuals.PINK_GHOST_COLOR)
        {
            PinkGTileCreated?.Invoke(this);
        }
    }
}
