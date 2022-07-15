using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class Dot : EatableTile
    {
        public static event Action OnDotEaten;

        public Dot(int x, int y) : base(x, y) { }

        internal override void Process()
        {
            if (!IsEaten)
            {
                Eat();
                OnDotEaten?.Invoke();
            }
        }
    }
}
