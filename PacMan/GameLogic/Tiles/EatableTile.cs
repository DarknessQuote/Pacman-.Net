using System;
using GameContent;

namespace PacMan.Tiles
{
    abstract class EatableTile : Tile
    {
        public static event Action TileEaten;

        public bool IsEaten { get; set; } = false;

        public EatableTile(int x, int y, char texture, ConsoleColor color) :
            base(x, y, texture, color) { }

        public void Eat()
        {
            tileTexture = Constants.EMPTY_TILE;
            IsEaten = true;
            TileEaten?.Invoke();
        }
    }
}
