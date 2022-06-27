using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic;

namespace PacMan.GameView.Screens
{
    class GameScreen : IScreen
    {
        private int screenWidth;
        private int screenHeight;
        private const int screenScoreOffset = 8;

        private readonly Maze maze;
        private readonly GameState state;

        public GameScreen()
        {
            maze = new Maze();
            state = new GameState(maze);
            ChangeWindowSize();
        }

        public void Render()
        {
            state.Update();
            RenderMaze();
            RenderScoreAndLives();
        }

        public void HandleInput(ConsoleKey key)
        {
            state.GetInput(key);
        }

        private void RenderMaze()
        {
            for (int x = 0; x < maze.Width; x++)
            {
                for (int y = 0; y < maze.Height; y++)
                {
                    maze[x, y].DrawTile();
                }
            }
        }

        private void RenderScoreAndLives()
        {
            Console.SetCursorPosition(screenWidth - 7, 6);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Score:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(screenWidth - 7, 7);
            Console.Write($"{state.Score:d6}");

            Console.SetCursorPosition(screenWidth - 7, screenHeight - 7);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Lives:");
            Console.SetCursorPosition(screenWidth - 7, screenHeight - 6);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < state.Lives; i++)
            {
                Console.Write("C ");
            }
        }

        private void ChangeWindowSize()
        {
            screenWidth = maze.Width + screenScoreOffset;
            screenHeight = maze.Height;

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(screenWidth, screenHeight);
                Console.SetBufferSize(screenWidth, screenHeight);
            }
        }

    }
}
