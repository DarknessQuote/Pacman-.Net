using System;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanConsole.ConsoleUI
{
    class ConsoleVisual : IVisual
    {
        private readonly char texture;
        private readonly ConsoleColor color;

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
