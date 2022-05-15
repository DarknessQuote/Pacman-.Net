using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;
using PacMan.Entities;

namespace PacMan
{
    class Level
    {
        public Map Map { get; set; }

        public Level(int height, int width)
        {
            Map = new Map(height, width);
            UpdateLevel();
        }

        public void UpdateLevel()
        {
            Map.PrintLevel();
        }
    }
}
