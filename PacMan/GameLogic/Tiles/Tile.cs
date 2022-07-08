using System;

namespace PacMan.GameLogic.Tiles
{
    abstract class Tile
    {
        public char TileTexture { get; set; }
        public ConsoleColor TileColor { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Tile(int x, int y, char texture, ConsoleColor color)
        {
            CoordX = x;
            CoordY = y;
            TileTexture = texture;
            TileColor = color;
        }

        public static Tile CreateTile(char tile, int x, int y)
        {
            return tile switch
            {
                'c' => new Pacman(x, y),
                'B' => new RedGhost(x, y),
                'P' => new PinkGhost(x, y),
                'I' => new CyanGhost(x, y),
                'C' => new OrangeGhost(x, y),
                '#' => new Wall(x, y),
                '·' => new Dot(x, y),
                'o' => new PowerPellet(x, y),
                _ => new EmptyTile(x, y)
            };
        }
    }
}
