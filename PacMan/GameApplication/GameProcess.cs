using System;
using System.Threading;
using System.Diagnostics;
using PacMan.GameLogic;
using PacMan.GameView;

namespace PacMan.GameApplication
{
    class GameProcess
    {
        private const int frameRate = 150;
        private readonly Renderer renderer = new();

        public GameProcess()
        {
            InitializeOptions();
            GameLoop();
        }

        private void GameLoop()
        {
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

        private void InitializeOptions()
        {
            Console.Title = "PacMan";
            Console.CursorVisible = false;
        }
    }
}
