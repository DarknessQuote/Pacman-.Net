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

        public Cell()
        {
            tilesInCell = new LinkedList<Tile>();
        }

        public void AddTile(Tile tile)
        {
            tilesInCell.AddFirst(tile);
        }

        public void RemoveTile()
        {
            tilesInCell.RemoveFirst();
        }
    }
}
