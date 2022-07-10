using System;

namespace PacMan.GameLogic.Tiles
{
    class PinkGhost : Tile
    {
        public static event Action<Tile> PinkGTileCreated;

        public PinkGhost(int x, int y) : base(x, y)
        {
            PinkGTileCreated?.Invoke(this);
        }
    }
}
