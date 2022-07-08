using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class Dot : EatableTile
    {
        public static event Action OnDotEaten;

        public Dot(int x, int y)
            : base(x, y, TileVisuals.DOT_TILE, TileVisuals.DOT_COLOR) { }

        public override void Process()
        {
            if (!IsEaten)
            {
                Eat();
                OnDotEaten?.Invoke();
            }
        }
    }
}
