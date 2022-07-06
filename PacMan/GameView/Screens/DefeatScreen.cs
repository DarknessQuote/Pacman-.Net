using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameView.Screens
{
    class DefeatScreen : IScreen
    {
        private readonly Renderer renderer;

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
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(20, 20);
                Console.SetBufferSize(20, 20);
            }

            Console.WriteLine("You lost, loser");
            Console.WriteLine($"Final score: {scoreDisplay}");
            Console.WriteLine($"Games won: {gamesWonDisplay}");
            Console.WriteLine($"Ghosts eaten: {ghostsEatenDisplay}\n");
            Console.WriteLine("Press Enter to return to main menu");
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
