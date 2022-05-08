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
        public Tile[,] map;

        public Level(int height, int width)
        {
            GenerateLevel(height, width);
            PrintLevel();
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
                    map[x, y] = new EmptyTile(x, y);
                }
            }

            map[height / 2, width / 2] = new Pacman(height / 2, width / 2);
        }

        public void PrintLevel()
        {
            Console.Clear();
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
