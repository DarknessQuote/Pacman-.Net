using System;
using System.Diagnostics;
using System.Threading;
using PacmanConsole.ConsoleUI;

namespace PacMan
{
    class Program
    {
        static void Main()
        {
            Console.Title = "PacMan";
            Console.CursorVisible = false;
            GameLoop();
        }

        static void GameLoop()
        {
            int frameRate = 120;
            Renderer renderer = new();
            var sw = new Stopwatch();

            while (true)
            {
                sw.Start();

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    renderer.HandleInput(key);
                }
                renderer.Render();

                sw.Stop();
                int elapsed = (int)sw.ElapsedMilliseconds;
                sw.Reset();

                int target = (elapsed > frameRate) ? 0 : frameRate - elapsed;
                Thread.Sleep(target);
            }
        }
    }
}
