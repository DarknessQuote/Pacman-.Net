using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public class PowerPellet : EatableTile
    {
        public static event Action OnPowerPelletEaten;

        public PowerPellet(int x, int y) : base(x, y) { }

        public override void Process()
        {
            if (!IsEaten)
            {
                Eat();
                OnPowerPelletEaten?.Invoke();
            }
        }
    }
}
