using GameContent;

namespace PacMan.Tiles
{
    class Pacman : Tile
    {
        public Pacman(int x, int y)
            : base(x, y, Constants.PACMAN_TILE, Constants.PACMAN_COLOR) { }
    }
}
