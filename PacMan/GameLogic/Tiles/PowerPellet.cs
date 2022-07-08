using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class PowerPellet : EatableTile
    {
        public static event Action OnPowerPelletEaten;

        public PowerPellet(int x, int y)
            : base(x, y, TileVisuals.POWER_PELLET_TILE, TileVisuals.POWER_PELLET_COLOR) { }

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
