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
        readonly int height;
        readonly int width;
        Tile[,] map;

        public Level(int height, int width)
        {
            this.height = height;
            this.width = width;
            map = new Tile[height, width];
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height-1 || j == 0 || j == width-1)
                    {
                        map[i, j] = new Wall(i, j);
                        continue;
                    }
                    map[i, j] = new Dot(i, j);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
