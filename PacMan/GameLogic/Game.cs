using System;
using PacMan.Entities;

namespace PacMan.GameLogic
{
    class Game
    {
        private readonly Maze maze;
        private readonly Player player;

        public GameState State { get; private set; }
        public int Score { get; private set; }
        public int Lives { get; private set; }

        public event Action<int> ScoreAdded;

        public Game(Maze maze, int score = 0, int lives = 3)
        {
            this.maze = maze;
            player = new Player(maze.Player, maze);
            Score = score;
            Lives = lives;
            State = GameState.Playing;

            player.OnDotEaten += () => AddScore(10);
            player.OnPowerPelletEaten += () => AddScore(30);
        }

        public void Update()
        {
            player.Move();
            if (maze.DotCount == 0)
            {
                State = GameState.Won;
            }
        }

        public void GetInput(ConsoleKey input)
        {
            player.ChangeDirection(input);
        }

        private void AddScore(int scoreToAdd)
        {
            Score += scoreToAdd;
            ScoreAdded?.Invoke(Score);
        }
    }

    enum GameState 
    {
        Playing,
        Won,
        Lost
    }
}
