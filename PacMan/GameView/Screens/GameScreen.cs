using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PacMan.GameLogic;

namespace PacMan.GameView.Screens
{
    class GameScreen : IScreen
    {
        private readonly Renderer renderer;
        private readonly Maze maze;
        private readonly GameState game;

        private int screenWidth;
        private int screenHeight;
        private const int screenInfoOffset = 8;

        private int infoPosX;
        private int scoreInfoPosY;
        private int livesInfoPosY;

        public GameScreen(Renderer renderer)
        {
            this.renderer = renderer;
            maze = new Maze();
            game = new GameState(maze);

            game.ScoreAdded += RenderScore;
        }

        public void OnLoad()
        {
            // These calculations ensure that the position of score and lives info will always be displayed
            // in the middle of the info box and on the same distance from top and bottom of the window.
            ChangeWindowSize();
            infoPosX = screenWidth - (screenInfoOffset / 2) - 3;
            scoreInfoPosY = 6;
            livesInfoPosY = screenHeight - 8;

            Console.Clear();
            RenderMaze();
            RenderScoreAndLivesLabels();
        }

        public void Render()
        {
            game.Update();
            RenderMaze();
            if (game.State == CurrentState.Won)
            {
                renderer.SwitchScreens(new IntroScreen(renderer));
            }
        }

        public void HandleInput(ConsoleKey key)
        {
            game.GetInput(key);
        }

        private void RenderMaze()
        {
            for (int x = 0; x < maze.Width; x++)
            {
                for (int y = 0; y < maze.Height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = maze[x, y].GetTopTile().TileColor;
                    Console.Write(maze[x, y].GetTopTile().TileTexture);
                }
            }
            Console.ResetColor();
        }

        private void RenderScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(infoPosX, scoreInfoPosY + 1);
            Console.Write($"{score:d6}");
        }

        private void RenderLives(int lives)
        {
            Console.SetCursorPosition(infoPosX, livesInfoPosY + 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < lives; i++)
            {
                Console.Write("C ");
            }
        }

        private void RenderScoreAndLivesLabels()
        {
            Console.SetCursorPosition(infoPosX, scoreInfoPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Score:");
            RenderScore(game.Score);

            Console.SetCursorPosition(infoPosX, livesInfoPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Lives:");
            RenderLives(game.Lives);
        }

        private void ChangeWindowSize()
        {
            screenWidth = maze.Width + screenInfoOffset;
            screenHeight = maze.Height;

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(screenWidth, screenHeight);
                Console.SetBufferSize(screenWidth, screenHeight);
            }
        }
    }
}
