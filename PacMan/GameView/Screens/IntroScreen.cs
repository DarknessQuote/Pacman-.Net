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
            menuOptions = new string[] { "New Game", "Exit" };
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

            Console.SetCursorPosition(7, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pacman");
            Console.ResetColor();
        }

        public void Render()
        {
            int i = 0;
            foreach (string option in menuOptions)
            {
                Console.SetCursorPosition(10 - (option.Length / 2), 4 + i++);
                if (option == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
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
                    ScrollMenu(--selectedOptionIndex);
                    break;
                case (ConsoleKey.DownArrow):
                    ScrollMenu(++selectedOptionIndex);
                    break;
                case (ConsoleKey.Enter):
                    SelectOption(selectedOption);
                    break;
            }

            void ScrollMenu(int index)
            {
                if (index == -1 || index == menuOptions.Length)
                {
                    selectedOptionIndex = Math.Abs(Math.Abs(index) - menuOptions.Length);
                }

                selectedOption = menuOptions[selectedOptionIndex];
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
