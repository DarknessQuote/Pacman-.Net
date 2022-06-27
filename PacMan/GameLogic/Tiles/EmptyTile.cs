using GameContent;

namespace PacMan.Tiles
{
    class EmptyTile : Tile
    {
        public EmptyTile(int x, int y)
            : base(x, y, Constants.EMPTY_TILE, Constants.DEFAULT_COLOR)
        { }
    }
}
