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
        Tile[,] map;

        public Level(int height, int width)
        {
            GenerateLevel(height, width);
            PrintLevel(map);
        }

        private void GenerateLevel(int height, int width)
        {
            map = new Tile[height, width];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (x == 0 || x == height-1 || y == 0 || y == width-1)
                    {
                        map[x, y] = new Wall(x, y);
                        continue;
                    }
                    map[x, y] = new Dot(x, y);
                }
                Console.WriteLine();
            }
        }

        private void PrintLevel(Tile[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y].Draw();
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
