using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PacMan.GameLogic;
using PacMan.GameView;

namespace PacMan.GameApplication
{
    class GameProcess
    {
        private Renderer renderer;

        public GameProcess()
        {
            renderer = new Renderer();
            InitializeOptions();

            renderer.Render();
            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    renderer.HandleInput(key);
                }
                renderer.Render();
                Thread.Sleep(50);
            }
        }

        private void InitializeOptions()
        {
            Console.Title = "PacMan";
            Console.CursorVisible = false;
        }
    }
}
