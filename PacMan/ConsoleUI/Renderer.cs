using System;
using PacmanConsole.ConsoleUI.Screens;

namespace PacmanConsole.ConsoleUI
{
    class Renderer
    {
        private IScreen currentScreen;

        public Renderer()
        {
            currentScreen = new IntroScreen(this);
            currentScreen.OnLoad();
        }

        public void Render() => currentScreen.Render();

        public void HandleInput(ConsoleKey key) => currentScreen.HandleInput(key);

        public void SwitchScreens(IScreen newScreen)
        {
            currentScreen = newScreen;
            currentScreen.OnLoad();
        }
    }
}
