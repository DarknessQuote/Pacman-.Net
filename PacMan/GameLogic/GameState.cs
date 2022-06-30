using System;
using PacMan.Entities;

namespace PacMan.GameLogic
{
    class GameState
    {
        private readonly Maze maze;
        private readonly Player player;

        public int Score { get; set; }
        public int Lives { get; set; }

        public GameState(Maze maze, int score = 0, int lives = 3)
        {
            this.maze = maze;
            Score = score;
            Lives = lives;
            player = new Player(maze.Player, maze);

            player.OnDotEaten += AddScore;
            player.OnPowerPelletEaten += AddScore;
        }

        public void Update()
        {
            player.Move();
            if (maze.DotCount == 0) Environment.Exit(0);
        }

        public void GetInput(ConsoleKey input)
        {
            player.ChangeDirection(input);
        }

        private void AddScore(int scoreToAdd)
        {
            Score += scoreToAdd;
        }
    }
}
