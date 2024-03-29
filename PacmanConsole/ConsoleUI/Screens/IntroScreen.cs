﻿using System;
using System.IO;

namespace PacmanConsole.ConsoleUI.Screens
{
    class IntroScreen : IScreen
    {        
        private readonly Renderer renderer;
        private readonly string[] optionsStrings;
        private string selectedOption;
        private int selectedOptionIndex;

        public IntroScreen(Renderer renderer)
        {
            this.renderer = renderer;
            optionsStrings = new string[] { "New Game", "Instructions", "Exit" };
            selectedOption = optionsStrings[0];
            selectedOptionIndex = 0;
        }

        public void OnLoad()
        {
            Console.Clear();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(38, 20);
                Console.SetBufferSize(38, 20);
            }

            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(File.ReadAllText(@"Resources\IntroPicture.txt"));
            Console.ResetColor();
        }

        public void Render()
        {
            int i = 11;
            foreach (string option in optionsStrings)
            {
                Console.SetCursorPosition(19 - (option.Length / 2), i++);
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
                    SelectOption();
                    break;
            }

            void ScrollMenu(int index)
            {
                if (index == -1 || index == optionsStrings.Length)
                {
                    selectedOptionIndex = Math.Abs(Math.Abs(index) - optionsStrings.Length);
                }

                selectedOption = optionsStrings[selectedOptionIndex];
            }
        }

        private void SelectOption()
        {
            switch ((MenuOptions)selectedOptionIndex)
            {
                case MenuOptions.NewGame:
                    renderer.SwitchScreens(new GameScreen(renderer));
                    break;
                case MenuOptions.Instructions:
                    renderer.SwitchScreens(new InstructionsScreen(renderer));
                    break;
                case MenuOptions.Exit:
                    renderer.IsRunning = false;
                    break;
            }
        }

        enum MenuOptions
        {
            NewGame,
            Instructions,
            Exit
        }
    }
}
