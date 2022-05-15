using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;
using PacMan.Entities;

namespace PacMan
{
    class Map
    {
        private Tile[,] field;

        public Map(int height, int width)
        {
            field = new Tile[height, width];
            GenerateLayout();
        }

        private void GenerateLayout()
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                for (int y = 0; y < field.GetLength(0); y++)
                {
                    if ((x == 0) || (x == field.GetLength(1) - 1) || (y == 0) || (y == field.GetLength(0) - 1))
                    {
                        field[y, x] = new Wall(y, x);
                        continue;
                    }
                    field[y, x] = new Dot(y, x);
                }
            }
            field[4, 4] = new Pacman(4, 4);
        }

        public void PrintLevel()
        {
            Console.Clear();
            for (int x = 0; x < field.GetLength(1); x++)
            {
                for (int y = 0; y < field.GetLength(0); y++)
                {
                    field[y, x].Draw();
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Tile GetTile(int y, int x)
        {
            return field[y, x];
        }

        public void SetTile(int y, int x, Tile tile)
        {
            field[y, x] = tile;
        }
    }
}
