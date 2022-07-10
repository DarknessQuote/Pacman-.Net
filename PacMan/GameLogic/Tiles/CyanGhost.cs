using System;

namespace PacMan.GameLogic.Tiles
{
    class CyanGhost : Tile
    {
        public static event Action<Tile> CyanGTileCreated;

        public CyanGhost(int x, int y) : base(x, y)
        {
            CyanGTileCreated?.Invoke(this);
        }
    }
}
