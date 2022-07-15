using System.Collections.Generic;
using System.Collections;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic
{
    public class Cell : IEnumerable<Tile>
    {
        private readonly List<Tile> tilesInCell;
        public int CellX { get; private set; }
        public int CellY { get; private set; }
        public Tile TopTile { get => tilesInCell[^1]; }
        public bool IsWall { get => tilesInCell[0] is Wall; }

        public Cell(int x, int y)
        {
            tilesInCell = new List<Tile>();
            CellX = x;
            CellY = y;
        }

        public void AddTile(Tile tile)
        {
            tilesInCell.Add(tile);
        }

        public void RemoveTile(Tile tile)
        {
            tilesInCell.Remove(tile);
        }

        IEnumerator<Tile> IEnumerable<Tile>.GetEnumerator() => tilesInCell.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => tilesInCell.GetEnumerator();
    }
}
