using System;

namespace PacMan.GameLogic.Tiles
{
    class RedGhost : Tile
    {
        public static event Action<Tile> RedGTileCreated;

        public RedGhost(int x, int y) : base(x, y)
        {
            RedGTileCreated?.Invoke(this);
        }
    }
}
