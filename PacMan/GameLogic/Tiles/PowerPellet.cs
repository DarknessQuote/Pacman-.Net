using GameContent;

namespace PacMan.Tiles
{
    class PowerPellet : EatableTile
    {
        public event EatableTileHandler OnPowerPelletEaten;

        public PowerPellet(int x, int y)
            : base(x, y, Constants.POWER_PELLET_TILE, Constants.POWER_PELLET_COLOR) { }

        public override void Eat()
        {
            if (!IsEaten)
            {
                tileTexture = Constants.EMPTY_TILE;
                OnPowerPelletEaten?.Invoke();
                IsEaten = true;
            }
        }
    }
}
