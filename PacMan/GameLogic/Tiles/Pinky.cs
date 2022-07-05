using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Pinky : Tile
    {
        public static event Action<Tile> PinkyTileCreated;

        public Pinky(int x, int y)
            : base(x, y, Constants.GHOST_TILE, Constants.PINKY_COLOR)
        {
            PinkyTileCreated?.Invoke(this);
        }
    }
}
