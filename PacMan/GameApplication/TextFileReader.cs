using System;
using System.IO;

namespace PacMan.GameApplication
{
    static class TextFileReader
    {
        public static string ReadFromFile(string pathToFile)
        {
            string pathToProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPath = Path.Combine(pathToProject, pathToFile);
            return File.ReadAllText(fullPath);
        }
    }
}
