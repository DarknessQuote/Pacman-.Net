using System.IO;

namespace PacmanEngine
{
    static class MapLoader
    {
        internal static char[,] LoadMapLayout(string pathToMap)
        {
            string[] rows = File.ReadAllLines(pathToMap);
            char[,] matrix = new char[rows[0].Length, rows.Length];
            return FillMatrix(matrix, rows);
        }

        private static char[,] FillMatrix(char[,] matrix, string[] rows)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                string currentRow = rows[y];

                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    char tile = currentRow[x];
                    matrix[x, y] = tile;
                }
            }

            return matrix;
        }
    }
}
