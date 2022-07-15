using System;
using System.Collections;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic
{
    public class Maze : IEnumerable
    {
        private readonly Cell[,] map;

        internal Tile RedGhostTile { get; private set; }
        internal (int X, int Y) PacmanStartingCoords { get; private set; }
        internal (int X, int Y) RedStartingCoords { get; private set; }
        internal (int X, int Y) PinkStartingCoords { get; private set; }
        internal (int X, int Y) CyanStartingCoords { get; private set; }
        internal (int X, int Y) OrangeStartingCoords { get; private set; }
        internal int DotCount { get; private set; }
        public int Width { get => map.GetLength(0); }
        public int Height { get => map.GetLength(1); }        

        public Cell this[int x, int y]
        {
            get
            {
                if (x < 0 || x > (Width - 1))
                {
                    x = Math.Abs(Width - Math.Abs(x));
                }
                if (y < 0 || y > (Height - 1))
                {
                    y = Math.Abs(Height - Math.Abs(y));
                }

                return map[x, y];
            }

            set
            {
                map[x, y] = value;
            }
        }

        public Maze()
        {
            HookEventsToMaze();
            char[,] mapLayout = MapLoader.LoadMapLayout("PacmanMap.txt");
            map = new Cell[mapLayout.GetLength(0), mapLayout.GetLength(1)];
            FillMap(mapLayout);            
        }

        private void FillMap(char[,] layout)
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

        private void HookEventsToMaze()
        {
            Pacman.PacmanTileCreated += (pacmanTile) =>
            {
                PacmanStartingCoords = (pacmanTile.CoordX, pacmanTile.CoordY);
                map[pacmanTile.CoordX, pacmanTile.CoordY].AddTile(new EmptyTile(pacmanTile.CoordX, pacmanTile.CoordY));
            };
            RedGhost.RedGTileCreated += (redTile) =>
            {
                RedStartingCoords = (redTile.CoordX, redTile.CoordY);
                map[redTile.CoordX, redTile.CoordY].AddTile(new EmptyTile(redTile.CoordX, redTile.CoordY));
                RedGhostTile = redTile;
            };
            PinkGhost.PinkGTileCreated += (pinkTile) =>
            {
                PinkStartingCoords = (pinkTile.CoordX, pinkTile.CoordY);
                map[pinkTile.CoordX, pinkTile.CoordY].AddTile(new EmptyTile(pinkTile.CoordX, pinkTile.CoordY));
            };
            CyanGhost.CyanGTileCreated += (cyanTile) =>
            {
                CyanStartingCoords = (cyanTile.CoordX, cyanTile.CoordY);
                map[cyanTile.CoordX, cyanTile.CoordY].AddTile(new EmptyTile(cyanTile.CoordX, cyanTile.CoordY));
            };
            OrangeGhost.OrangeGTileCreated += (orangeTile) =>
            {
                OrangeStartingCoords = (orangeTile.CoordX, orangeTile.CoordY);
                map[orangeTile.CoordX, orangeTile.CoordY].AddTile(new EmptyTile(orangeTile.CoordX, orangeTile.CoordY));
            };

            EatableTile.EatableTileCreated += () => DotCount++;
            EatableTile.EatableTileEaten += () => DotCount--;
        }

        IEnumerator IEnumerable.GetEnumerator() => map.GetEnumerator();
    }
}
