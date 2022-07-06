using System.IO;

namespace PacMan.GameApplication
{
    static class MapLoader
    {
        public static char[,] LoadMapLayout(string pathToMap)
        {
            string[] layoutStrings = File.ReadAllLines(pathToMap);
            char[,] layout = new char[layoutStrings[0].Length, layoutStrings.Length];
            return FillArray(layout, layoutStrings);
        }

        private static char[,] FillArray(char[,] layout, string[] mapLayout)
        {
            for (int y = 0; y < layout.GetLength(1); y++)
            {
                string currentRow = mapLayout[y];

                for (int x = 0; x < layout.GetLength(0); x++)
                {
                    char tile = currentRow[x];
                    layout[x, y] = tile;
                }
            }

            return layout;
        }
    }
}
