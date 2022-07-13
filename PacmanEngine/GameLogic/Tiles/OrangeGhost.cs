using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class OrangeGhost : Tile
    {
        public static event Action<Tile> OrangeGTileCreated;

        public OrangeGhost(int x, int y) : base(x, y)
        {
            OrangeGTileCreated?.Invoke(this);
        }
    }
}
