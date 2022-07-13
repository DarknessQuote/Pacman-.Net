using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class Pacman : Tile
    {
        public static event Action<Tile> PacmanTileCreated;
        public Pacman(int x, int y) : base(x, y)
        {
            PacmanTileCreated?.Invoke(this);
        }
    }
}
