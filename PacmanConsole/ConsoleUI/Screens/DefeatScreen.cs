using System;
using System.IO;
using PacmanEngine.GameLogic;

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

        public DefeatScreen(Renderer renderer, GameStats gameStats)
        {
            this.renderer = renderer;
            scoreDisplay = gameStats.Score;
            gamesWonDisplay = gameStats.GamesWon;
            ghostsEatenDisplay = gameStats.GhostsEaten;
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
            Console.WriteLine(File.ReadAllText(@"Resources\DefeatPicture.txt"));

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
