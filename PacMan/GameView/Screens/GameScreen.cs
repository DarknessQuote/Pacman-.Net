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
        private readonly GameStats gameStats;
        private Maze maze;
        private GameScene gameScene;
        private bool isPaused;

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
            gameStats = new GameStats();
            gameScene = new GameScene(maze, gameStats);

            gameStats.OnScoreChange += () => RenderScore();
            gameStats.OnLivesChange += () => RenderLives();
        }

        public void OnLoad()
        {
            Console.Clear();
            ChangeWindowSize();
            RenderMaze();
            RenderScoreAndLivesLabels();
        }

        public void Render()
        {
            if (!isPaused)
            {
                gameScene.UpdateGameState();
                RenderMaze();
                switch (gameScene.State)
                {
                    case (GameState.Playing):
                        return;
                    case (GameState.Won):
                        DoGameEndingAnimation();
                        maze = new Maze();
                        gameScene = new GameScene(maze, gameStats);
                        OnLoad();
                        break;
                    case (GameState.Lost):
                        DoGameEndingAnimation();
                        renderer.SwitchScreens(
                            new DefeatScreen(renderer, gameStats.Score, gameStats.GamesWon, gameStats.GhostsEaten));
                        break;
                }
            }
        }

        public void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case (ConsoleKey.W):
                case (ConsoleKey.A):
                case (ConsoleKey.S):
                case (ConsoleKey.D):
                    gameScene.player.ChangeDirection(key);
                    break;
                case (ConsoleKey.P):
                    if (isPaused) isPaused = false;
                    else isPaused = true;
                    break;
            }
            gameScene.player.ChangeDirection(key);
        }

        private void RenderMaze()
        {
            foreach (Cell cell in maze)
            {
                Console.SetCursorPosition(cell.CellX, cell.CellY);
                Console.ForegroundColor = cell.GetTopTile().TileColor;
                Console.Write(cell.GetTopTile().TileTexture);
            }
            Console.ResetColor();
        }

        private void RenderScore()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(infoPosX, scoreInfoPosY + 1);
            Console.Write($"{gameStats.Score:d6}");
        }

        private void RenderLives()
        {
            Console.SetCursorPosition(infoPosX, livesInfoPosY + 1);
            Console.SetCursorPosition(infoPosX, livesInfoPosY + 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i <= 3; i++)
            {
                if (i > gameStats.Lives)
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

        private void DoGameEndingAnimation()
        {
            Thread.Sleep(500);
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', screenWidth));
                Thread.Sleep(40);
            }
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

            // These calculations ensure that the position of score and lives info will always be displayed
            // in the middle of the info box and on the same distance from top and bottom of the window.
            infoPosX = screenWidth - (screenInfoOffset / 2) - 3;
            scoreInfoPosY = 6;
            livesInfoPosY = screenHeight - 8;
        }
    }
}
