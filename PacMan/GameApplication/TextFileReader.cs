using System;
using System.IO;

namespace PacMan.GameApplication
{
    static class TextFileReader
    {
        public static string ReadFromFile(string pathToFile) => File.ReadAllText(pathToFile);
    }
}
