using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;

namespace PacMan.GameLogic
{
    static class MapLoader
    {
        public static Tile[,] LoadMap(string pathToMap)
        {
            string[] mapLayout = ReadFromFile(pathToMap);
            Tile[,] map = CreateMap(mapLayout);
            return FillMap(map, mapLayout);
        }

        private static string[] ReadFromFile(string pathToMap)
        {
            string pathToProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPath = Path.Combine(pathToProject, pathToMap);
            return File.ReadAllLines(fullPath);
        }

        private static Tile[,] CreateMap(string[] mapLayout)
        {
            return new Tile[mapLayout[0].Length, mapLayout.Length];
        }

        private static Tile[,] FillMap(Tile[,] map, string[] mapLayout)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                string currentRow = mapLayout[y];

                for (int x = 0; x < map.GetLength(0); x++)
                {
                    char tile = currentRow[x];
                    map[x, y] = Tile.CreateTile(tile, x, y);
                }
            }

            return map;
        }
    }
}
