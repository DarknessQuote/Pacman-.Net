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
        private Maze maze;
        private GameState game;

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

            // These calculations ensure that the position of score and lives info will always be displayed
            // in the middle of the info box and on the same distance from top and bottom of the window.
            ChangeWindowSize();
            infoPosX = screenWidth - (screenInfoOffset / 2) - 3;
            scoreInfoPosY = 6;
            livesInfoPosY = screenHeight - 8;

            game.ScoreAdded += RenderScore;
            game.LifeLost += RenderLives;
        }

        public void OnLoad()
        {
            Console.Clear();
            RenderMaze();
            RenderScoreAndLivesLabels();
        }

        public void Render()
        {
            game.Update();
            RenderMaze();

            switch (game.State)
            {
                case (CurrentState.Playing):
                    return;
                case (CurrentState.Won):
                    maze = new Maze();
                    game = new GameState(maze, game.Score, game.Lives);
                    OnLoad();
                    break;
                case (CurrentState.Lost):
                    renderer.SwitchScreens(new IntroScreen(renderer));
                    break;
            }
        }

        public void HandleInput(ConsoleKey key)
        {
            game.GetInput(key);
        }

        private void RenderMaze()
        {
            foreach (Cell cell in maze)
            {
                Console.SetCursorPosition(cell.CellX, cell.CellY);
                Console.ForegroundColor = cell.GetTopLayerTile().TileColor;
                Console.Write(cell.GetTopLayerTile().TileTexture);
            }
            Console.ResetColor();
        }

        private void RenderScore()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(infoPosX, scoreInfoPosY + 1);
            Console.Write($"{game.Score:d6}");
        }

        private void RenderLives()
        {
            Console.SetCursorPosition(infoPosX, livesInfoPosY + 1);
            Console.SetCursorPosition(infoPosX, livesInfoPosY + 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i <= 3; i++)
            {
                if (i > game.Lives)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write("C ");
            }
        }

        private void RenderScoreAndLivesLabels()
        {
            Console.SetCursorPosition(infoPosX, scoreInfoPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Score:");
            RenderScore();

            Console.SetCursorPosition(infoPosX, livesInfoPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Lives:");
            RenderLives();
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
