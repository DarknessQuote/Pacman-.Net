using GameContent;

namespace PacMan.Tiles
{
    class Wall : Tile
    {
        public Wall(int x, int y)
            : base (x, y, Constants.WALL_TILE, Constants.WALL_COLOR) { }
    }
}
