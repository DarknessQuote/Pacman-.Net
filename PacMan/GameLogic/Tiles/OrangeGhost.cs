using System;

namespace PacMan.GameLogic.Tiles
{
    class OrangeGhost : Tile
    {
        public static event Action<Tile> OrangeGTileCreated;

        public OrangeGhost(int x, int y) : base(x, y)
        {
            OrangeGTileCreated?.Invoke(this);
        }
    }
}
