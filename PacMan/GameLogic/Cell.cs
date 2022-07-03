using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;

namespace PacMan.GameLogic
{
    class Cell : IEnumerable<Tile>
    {
        private readonly LinkedList<Tile> tilesInCell;
        public int CellX { get; private set; }
        public int CellY { get; private set; }

        public Cell(int x, int y)
        {
            tilesInCell = new LinkedList<Tile>();
            AddTile(new EmptyTile(x, y));

            CellX = x;
            CellY = y;
        }

        public Tile GetTopTile()
        {
            return tilesInCell.Last.Value;
        }

        public Tile GetUnderneathTile()
        {
            return tilesInCell.Last.Previous.Value;
        }

        public void AddTile(Tile tile)
        {
            tilesInCell.AddLast(tile);
        }

        public void RemoveTile()
        {
            tilesInCell.RemoveLast();
        }

        IEnumerator<Tile> IEnumerable<Tile>.GetEnumerator() => tilesInCell.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => tilesInCell.GetEnumerator();
    }
}
