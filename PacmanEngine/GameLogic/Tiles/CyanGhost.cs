using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class CyanGhost : Tile
    {
        public static event Action<Tile> CyanGTileCreated;

        public CyanGhost(int x, int y) : base(x, y)
        {
            CyanGTileCreated?.Invoke(this);
        }
    }
}
