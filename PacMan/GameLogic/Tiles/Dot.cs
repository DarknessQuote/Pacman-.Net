using GameContent;

namespace PacMan.Tiles
{
    class Dot : EatableTile
    {
        public event EatableTileHandler OnDotEaten;

        public Dot(int x, int y)
            : base(x, y, Constants.DOT_TILE, Constants.DOT_COLOR) { }

        public override void Eat()
        {
            if (!IsEaten)
            {
                tileTexture = Constants.EMPTY_TILE;
                OnDotEaten?.Invoke();
                IsEaten = true;
            }
        }
    }
}
