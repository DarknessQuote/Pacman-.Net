namespace PacmanEngine.GameLogic.Tiles
{
    public abstract class Tile
    {
        public IVisual Visual { get; set; }
        internal int CoordX { get; set; }
        internal int CoordY { get; set; }

        public Tile(int x, int y)
        {
            CoordX = x;
            CoordY = y;
        }

        internal static Tile CreateTile(char tile, int x, int y)
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

        public void Draw() => Visual.Draw(CoordX, CoordY);

        internal virtual void Process() { }
    }
}
