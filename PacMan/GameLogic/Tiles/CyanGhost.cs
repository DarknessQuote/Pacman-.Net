using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class CyanGhost : Tile
    {
        public static event Action<Tile> CyanGTileCreated;

        public CyanGhost(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.CYAN_GHOST_COLOR)
        {
            CyanGTileCreated?.Invoke(this);
        }
    }
}
