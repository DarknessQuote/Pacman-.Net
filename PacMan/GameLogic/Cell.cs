using System.Collections.Generic;
using System.Collections;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic
{
    class Cell : IEnumerable<Tile>
    {
        private readonly List<Tile> tilesInCell;
        public int CellX { get; private set; }
        public int CellY { get; private set; }
        public bool IsWall { get => tilesInCell[0] is Wall; }

        public Cell(int x, int y)
        {
            tilesInCell = new List<Tile>();
            CellX = x;
            CellY = y;
        }

        public Tile GetTopTile()
        {
            return tilesInCell[^1];
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
