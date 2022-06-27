using System;

namespace PacMan.Tiles
{
    abstract class Tile
    {
        protected char tileTexture;
        protected ConsoleColor tileColor;

        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Tile(int x, int y, char texture, ConsoleColor color)
        {
            CoordX = x;
            CoordY = y;
            tileTexture = texture;
            tileColor = color;
        }

        public static Tile CreateTile(char tile, int x, int y)
        {
            return tile switch
            {
                'c' => new Pacman(x, y),
                '#' => new Wall(x, y),
                '·' => new Dot(x, y),
                'o' => new PowerPellet(x, y),
                '\0' => new EmptyTile(x, y),
                _ => new EmptyTile(x, y)
            };
        }

        public void DrawTile()
        {
            Console.SetCursorPosition(CoordX, CoordY);
            Console.ForegroundColor = tileColor;
            Console.Write(tileTexture);
        }
    }
}
