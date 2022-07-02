using System;
using System.Linq;
using PacMan.Tiles;

namespace PacMan.GameLogic
{
    class Maze
    {
        private readonly Tile[,] map;

        public Tile Player { get; private set; }
        public int DotCount { get; private set; }
        public int Width { get => map.GetLength(0); }
        public int Height { get => map.GetLength(1); }        

        public Tile this[int x, int y]
        {
            get
            {
                if (x < 0 || x > (Width - 1))
                {
                    return map[Width - Math.Abs(x), y];
                }
                else if (y < 0 || y > (Height - 1))
                {
                    return map[x, Height - Math.Abs(y)];
                }
                else
                {
                    return map[x, y];
                }
            }

            set
            {
                map[x, y] = value;
            }
        }

        public Maze()
        {
            Pacman.PacmanTileCreated += (pacmanTile) => Player = pacmanTile;
            EatableTile.EatableTileCreated += () => DotCount++;
            EatableTile.EatableTileEaten += () => DotCount--;

            char[,] mapLayout = MapLoader.LoadMapLayout(@"GameContent\PacmanMap.txt");
            map = new Tile[mapLayout.GetLength(0), mapLayout.GetLength(1)];
            FillMap();

            void FillMap()
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        map[x, y] = Tile.CreateTile(mapLayout[x, y], x, y);
                    }
                }
            }
        }
    }
}
