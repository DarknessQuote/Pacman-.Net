using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Dot : EatableTile
    {
        public Dot(int x, int y)
            : base(x, y, TileVisuals.DOT_TILE, TileVisuals.DOT_COLOR) { }
    }
}
