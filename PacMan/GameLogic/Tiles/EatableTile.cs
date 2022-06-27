using System;
using GameContent;

namespace PacMan.Tiles
{
    abstract class EatableTile : Tile
    {
        public bool IsEaten { get; protected set; } = false;

        public delegate void EatableTileHandler();

        public EatableTile(int x, int y, char texture, ConsoleColor color)
            : base(x, y, texture, color) { }

        public abstract void Eat();
    }
}
