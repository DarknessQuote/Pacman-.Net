using System;
using System.Collections;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic
{
    class Maze : IEnumerable
    {
        private readonly Cell[,] map;

        public (int X, int Y) PacmanStartingCoords { get; private set; }
        public int DotCount { get; private set; }
        public int Width { get => map.GetLength(0); }
        public int Height { get => map.GetLength(1); }        

        public Cell this[int x, int y]
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
            Pacman.PacmanTileCreated += (pacmanTile) => PacmanStartingCoords = (pacmanTile.CoordX, pacmanTile.CoordY);
            EatableTile.EatableTileCreated += () => DotCount++;
            EatableTile.EatableTileEaten += () => DotCount--;

            char[,] mapLayout = GameApplication.MapLoader.LoadMapLayout(@"GameContent\PacmanMap.txt");
            map = new Cell[mapLayout.GetLength(0), mapLayout.GetLength(1)];
            FillMap(mapLayout);            
        }

        void FillMap(char[,] layout)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    map[x, y] = new Cell(x, y);
                    var tile = Tile.CreateTile(layout[x, y], x, y);
                    map[x, y].AddTile(tile);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => map.GetEnumerator();
    }
}
