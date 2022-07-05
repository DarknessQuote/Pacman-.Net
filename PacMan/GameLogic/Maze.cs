using System;
using System.Collections;
using System.Linq;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic
{
    class Maze : IEnumerable
    {
        private readonly Cell[,] map;
        private Tile blinky;

        public (int X, int Y) PacmanStartingCoords { get; private set; }
        public (int X, int Y) BlinkyStartingCoords { get; private set; }
        public (int X, int Y) PinkyStartingCoords { get; private set; }
        public (int X, int Y) InkyStartingCoords { get; private set; }
        public (int X, int Y) ClydeStartingCoords { get; private set; }
        public int DotCount { get; private set; }
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
            Pacman.PacmanTileCreated += (pacmanTile) => PacmanStartingCoords = (pacmanTile.CoordX, pacmanTile.CoordY);
            Blinky.BlinkyTileCreated += (blinkyTile) =>
            {
                BlinkyStartingCoords = (blinkyTile.CoordX, blinkyTile.CoordY);
                blinky = blinkyTile;
            };
            Pinky.PinkyTileCreated += (pinkyTile) => PinkyStartingCoords = (pinkyTile.CoordX, pinkyTile.CoordY);
            Inky.InkyTileCreated += (inkyTile) => InkyStartingCoords = (inkyTile.CoordX, inkyTile.CoordY);
            Clyde.ClydeTileCreated += (clydeTile) => ClydeStartingCoords = (clydeTile.CoordX, clydeTile.CoordY);
            EatableTile.EatableTileCreated += () => DotCount++;
            EatableTile.EatableTileEaten += () => DotCount--;

            char[,] mapLayout = GameApplication.MapLoader.LoadMapLayout(@"GameContent\PacmanMap.txt");
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

        public Cell GetBlinkyCell()
        {
            foreach (Cell cell in map)
            {
                if (cell.Contains(blinky)) return cell;
            }
            throw new Exception("No Blinky in maze");
        }

        IEnumerator IEnumerable.GetEnumerator() => map.GetEnumerator();
    }
}
