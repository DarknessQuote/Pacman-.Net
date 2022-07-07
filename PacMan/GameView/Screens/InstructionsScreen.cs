using System;
using PacMan.GameApplication;

namespace PacMan.GameView.Screens
{
    class InstructionsScreen : IScreen
    {
        private readonly Renderer renderer;

        public InstructionsScreen(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public void OnLoad()
        {
            Console.Clear();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(125, 18);
                Console.SetBufferSize(125, 18);
            }
            Console.Write(TextFileReader.ReadFromFile(@"GameContent\Instructions.txt"));
        }

        public void Render() { }

        public void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                renderer.SwitchScreens(new IntroScreen(renderer));
            }
        }
    }
}
