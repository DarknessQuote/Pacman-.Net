using System;

namespace PacmanEngine.GameLogic.Tiles
{
    public abstract class EatableTile : Tile
    {
        public static event Action EatableTileCreated;
        public static event Action EatableTileEaten;
        public static event Action<EatableTile> ChangeTileVisual;

        public bool IsEaten { get; set; } = false;

        public EatableTile(int x, int y) : base(x, y) 
        {
            EatableTileCreated?.Invoke();
        }

        protected void Eat()
        {
            IsEaten = true;
            EatableTileEaten?.Invoke();
            ChangeTileVisual?.Invoke(this);
        }
    }
}
