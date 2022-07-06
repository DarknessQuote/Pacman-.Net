using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class OrangeGhost : Tile
    {
        public static event Action<Tile> OrangeGTileCreated;

        public OrangeGhost(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.ORANGE_GHOST_COLOR)
        {
            OrangeGTileCreated?.Invoke(this);
        }
    }
}
