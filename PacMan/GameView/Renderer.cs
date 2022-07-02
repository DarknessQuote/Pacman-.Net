using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic;
using PacMan.GameView.Screens;

namespace PacMan.GameView
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
