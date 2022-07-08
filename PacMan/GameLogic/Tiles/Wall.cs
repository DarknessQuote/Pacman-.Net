using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Wall : Tile
    {
        public Wall(int x, int y)
            : base (x, y, TileVisuals.WALL_TILE, TileVisuals.WALL_COLOR) { }
    }
}
