using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameView.Screens
{
    class IntroScreen : IScreen
    {        
        private readonly Renderer renderer;
        private readonly string[] menuOptions;
        private string selectedOption;
        private int selectedOptionIndex;

        public IntroScreen(Renderer renderer)
        {
            this.renderer = renderer;
            menuOptions = new string[] { "1. Start game", "2. Exit" };
            selectedOption = menuOptions[0];
            selectedOptionIndex = 0;
        }

        public void OnLoad()
        {
            Console.Clear();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(20, 20);
                Console.SetBufferSize(20, 20);
            }
        }

        public void Render()
        {
            int i = 0;
            foreach (string option in menuOptions)
            {
                Console.SetCursorPosition(0, i++);
                if (option == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine(option);
                Console.ResetColor();
            }
        }

        public void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case (ConsoleKey.UpArrow):
                    if (selectedOptionIndex == 0) break;
                    selectedOption = menuOptions[selectedOptionIndex - 1];
                    selectedOptionIndex -= 1;
                    break;
                case (ConsoleKey.DownArrow):
                    if (selectedOptionIndex == menuOptions.Length - 1) break;
                    selectedOption = menuOptions[selectedOptionIndex + 1];
                    selectedOptionIndex += 1;
                    break;
                case (ConsoleKey.Enter):
                    SelectOption(selectedOption);
                    break;
            }
        }

        private void SelectOption(string option)
        {
            if (option == menuOptions[0])
            {
                renderer.SwitchScreens(new GameScreen(renderer));
            }
            else if (option == menuOptions[1])
            {
                Environment.Exit(0);
            }
        }
    }
}
