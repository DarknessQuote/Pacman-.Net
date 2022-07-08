using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Pacman : Tile
    {
        public static event Action<Tile> PacmanTileCreated;
        public Pacman(int x, int y)
            : base(x, y, TileVisuals.PACMAN_TILE, TileVisuals.PACMAN_COLOR)
        {
            PacmanTileCreated?.Invoke(this);
        }
    }
}
