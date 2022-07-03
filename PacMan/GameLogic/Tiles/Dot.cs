using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Dot : EatableTile
    {
        public Dot(int x, int y)
            : base(x, y, Constants.DOT_TILE, Constants.DOT_COLOR) { }
    }
}
