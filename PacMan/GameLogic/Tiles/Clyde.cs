using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Clyde : Tile
    {
        public static event Action<Tile> ClydeTileCreated;

        public Clyde(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.CLYDE_COLOR)
        {
            ClydeTileCreated?.Invoke(this);
        }
    }
}
