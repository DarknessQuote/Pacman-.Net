using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class RedGhost : Tile
    {
        public static event Action<Tile> RedGTileCreated;

        public RedGhost(int x, int y) : base(x, y)
        {
            RedGTileCreated?.Invoke(this);
        }
    }
}
