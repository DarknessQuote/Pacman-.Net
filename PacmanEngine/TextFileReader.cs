using System;
using System.IO;

namespace PacmanEngine
{
    public static class TextFileReader
    {
        public static string ReadFromFile(string pathToFile) => File.ReadAllText(pathToFile);
    }
}
