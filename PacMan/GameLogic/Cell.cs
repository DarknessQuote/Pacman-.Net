using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic
{
    class Cell : IEnumerable<Tile>
    {
        private readonly LinkedList<Tile> tilesInCell;
        public int CellX { get; private set; }
        public int CellY { get; private set; }
        public bool IsWall { get => GetTopLayerTile() is Wall; }

        public Cell(int x, int y)
        {
            tilesInCell = new LinkedList<Tile>();
            AddTile(new EmptyTile(x, y));

            CellX = x;
            CellY = y;
        }

        public Tile GetTopLayerTile()
        {
            return tilesInCell.First.Value;
        }

        public void AddTile(Tile tile)
        {
            tilesInCell.AddFirst(tile);
        }

        public void RemoveTile(Tile tile)
        {
            tilesInCell.Remove(tile);
        }

        IEnumerator<Tile> IEnumerable<Tile>.GetEnumerator() => tilesInCell.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => tilesInCell.GetEnumerator();
    }
}
