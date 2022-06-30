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
            map = MapLoader.LoadMap(@"GameContent\PacmanMap.txt");
            Player = GetPacmanTile();

            DotCount = 10;
            EatableTile.TileEaten += () => DotCount--;
        }

        private Tile GetPacmanTile()
        {
            foreach (Tile tile in map)
            {
                if (tile is Pacman pacman) return pacman;
            }
            return null;
        }
    }
}
