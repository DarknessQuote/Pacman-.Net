using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    abstract class EatableTile : Tile
    {
        public static event Action EatableTileCreated;
        public static event Action EatableTileEaten;

        public bool IsEaten { get; set; } = false;

        public EatableTile(int x, int y, char texture, ConsoleColor color) :
            base(x, y, texture, color) 
        {
            EatableTileCreated?.Invoke();
        }

        public void Eat()
        {
            TileTexture = Constants.EMPTY_TILE;
            IsEaten = true;
            EatableTileEaten?.Invoke();
        }
    }
}
