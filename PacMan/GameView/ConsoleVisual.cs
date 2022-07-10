using System;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameView
{
    class ConsoleVisual : IVisual
    {
        private char texture;
        private ConsoleColor color;

        public ConsoleVisual(char texture, ConsoleColor color)
        {
            this.texture = texture;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.Write(texture);
        }
    }
}
