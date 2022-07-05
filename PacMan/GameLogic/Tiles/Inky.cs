using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Inky : Tile
    {
        public static event Action<Tile> InkyTileCreated;

        public Inky(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.INKY_COLOR)
        {
            InkyTileCreated?.Invoke(this);
        }
    }
}
