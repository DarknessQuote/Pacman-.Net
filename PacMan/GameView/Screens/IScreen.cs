using System;

namespace PacMan.GameView.Screens
{
    interface IScreen
    {
        public void OnLoad();
        public void Render();
        public void HandleInput(ConsoleKey key);
    }
}
