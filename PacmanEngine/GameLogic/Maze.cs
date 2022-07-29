using System;
using System.Collections;
using PacmanEngine.Maps;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic
{
    public class Maze : IEnumerable
    {
        private readonly Cell[,] map;
        private readonly char[,] startingLayout;

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

        public Maze(string pathToMap)
        {
            HookEventsToMaze();
            char[,] mapLayout = MapLoader.LoadMapLayout(pathToMap);
            startingLayout = mapLayout;
            map = new Cell[mapLayout.GetLength(0), mapLayout.GetLength(1)];
            FillMap(mapLayout);
        }

        public void Restart()
        {
            FillMap(startingLayout);
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

        private void SetStartingCoordinates(Tile entityTile)
        {
            var entityStartingCoords = (entityTile.CoordX, entityTile.CoordY);
            map[entityTile.CoordX, entityTile.CoordY].AddTile(new EmptyTile(entityTile.CoordX, entityTile.CoordY));

            switch (entityTile)
            {
                case Pacman:
                    PacmanStartingCoords = entityStartingCoords;
                    break;
                case RedGhost:
                    RedStartingCoords = entityStartingCoords;
                    RedGhostTile = entityTile;
                    break;
                case PinkGhost:
                    PinkStartingCoords = entityStartingCoords;
                    break;
                case CyanGhost:
                    CyanStartingCoords = entityStartingCoords;
                    break;
                case OrangeGhost:
                    OrangeStartingCoords = entityStartingCoords;
                    break;
            }
        }

        private void HookEventsToMaze()
        {
            Pacman.PacmanTileCreated += (pacmanTile) => SetStartingCoordinates(pacmanTile);
            RedGhost.RedGTileCreated += (redTile) => SetStartingCoordinates(redTile);
            PinkGhost.PinkGTileCreated += (pinkTile) => SetStartingCoordinates(pinkTile);
            CyanGhost.CyanGTileCreated += (cyanTile) => SetStartingCoordinates(cyanTile);
            OrangeGhost.OrangeGTileCreated += (orangeTile) => SetStartingCoordinates(orangeTile);

            EatableTile.EatableTileCreated += () => DotCount++;
            EatableTile.EatableTileEaten += () => DotCount--;
        }

        IEnumerator IEnumerable.GetEnumerator() => map.GetEnumerator();
    }
}
