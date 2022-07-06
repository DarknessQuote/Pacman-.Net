using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameView.Screens
{
    class DefeatScreen : IScreen
    {
        private Renderer renderer;

        public int ScoreDisplay { get; set; }
        public int GhostsEatenDisplay { get; set; }

        public DefeatScreen(Renderer renderer, int score, int ghostsEaten)
        {
            this.renderer = renderer;

            ScoreDisplay = score;
            GhostsEatenDisplay = ghostsEaten;
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
            Console.WriteLine($"Final score: {ScoreDisplay}");
            Console.WriteLine($"Ghosts eaten: {GhostsEatenDisplay}\n");
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
