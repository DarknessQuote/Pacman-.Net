using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class OrangeGhost : Tile
    {
        public static event Action<Tile> OrangeGTileCreated;

        public OrangeGhost(int x, int y)
            : base(x, y, TileVisuals.GHOST_TILE, TileVisuals.ORANGE_GHOST_COLOR)
        {
            OrangeGTileCreated?.Invoke(this);
        }
    }
}
