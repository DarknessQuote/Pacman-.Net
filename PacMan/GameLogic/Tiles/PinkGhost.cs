using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class PinkGhost : Tile
    {
        public static event Action<Tile> PinkGTileCreated;

        public PinkGhost(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.PINK_GHOST_COLOR)
        {
            PinkGTileCreated?.Invoke(this);
        }
    }
}
