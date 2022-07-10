using System;

namespace PacMan.GameLogic.Tiles
{
    class Dot : EatableTile
    {
        public static event Action OnDotEaten;

        public Dot(int x, int y) : base(x, y) { }

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
