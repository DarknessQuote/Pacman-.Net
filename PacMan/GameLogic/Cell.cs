using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;

namespace PacMan.GameLogic
{
    class Cell
    {
        private LinkedList<Tile> tilesInCell;
        public int CellX { get; private set; }
        public int CellY { get; private set; }

        public Cell(int x, int y)
        {
            tilesInCell = new LinkedList<Tile>();
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
    }
}
