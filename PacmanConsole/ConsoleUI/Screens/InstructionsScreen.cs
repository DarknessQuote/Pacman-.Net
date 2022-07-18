using System;
using System.IO;

namespace PacmanConsole.ConsoleUI.Screens
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
            Console.Write(File.ReadAllText(@"Resources\Instructions.txt"));
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
