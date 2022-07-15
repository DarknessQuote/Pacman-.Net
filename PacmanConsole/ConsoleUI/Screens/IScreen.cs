using System;

namespace PacmanConsole.ConsoleUI.Screens
{
    interface IScreen
    {
        public void OnLoad();
        public void Render();
        public void HandleInput(ConsoleKey key);
    }
}
