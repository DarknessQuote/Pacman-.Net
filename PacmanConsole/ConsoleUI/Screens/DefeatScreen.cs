using System;
using PacmanEngine;

namespace PacmanConsole.ConsoleUI.Screens
{
    class DefeatScreen : IScreen
    {
        private readonly Renderer renderer;
        private const int screenWidth = 29;
        private const int screenHeight = 25;

        private readonly int scoreDisplay;
        private readonly int gamesWonDisplay;
        private readonly int ghostsEatenDisplay;

        public DefeatScreen(Renderer renderer, int score, int gamesWon, int ghostsEaten)
        {
            this.renderer = renderer;

            scoreDisplay = score;
            gamesWonDisplay = gamesWon;
            ghostsEatenDisplay = ghostsEaten;
        }

        public void OnLoad()
        {
            Console.Clear();
            Console.ResetColor();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(screenWidth, screenHeight);
                Console.SetBufferSize(screenWidth, screenHeight);
            }

            Console.SetCursorPosition(0, 2);
            Console.WriteLine(TextFileReader.ReadFromFile(@"GameContent\DefeatPicture.txt"));

            Console.WriteLine("\nSorry, but you lost");
            Console.WriteLine($"Final score: {scoreDisplay}");
            Console.WriteLine($"Games won: {gamesWonDisplay}");
            Console.WriteLine($"Ghosts eaten: {ghostsEatenDisplay}");
            Console.WriteLine("\nPress Enter");
        }

        public void Render() { }

        public void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                renderer.SwitchScreens(new IntroScreen(renderer));
            }
        }
    }
}
