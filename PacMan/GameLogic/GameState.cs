using System;
using PacMan.Entities;

namespace PacMan.GameLogic
{
    class GameState
    {
        private readonly Maze maze;
        private readonly Player player;

        public CurrentState State { get; private set; }
        public int Score { get; private set; }
        public int Lives { get; private set; }

        public event Action<int> ScoreAdded;

        public GameState(Maze maze, int score = 0, int lives = 3)
        {
            this.maze = maze;
            player = new Player(maze);
            Score = score;
            Lives = lives;
            State = CurrentState.Playing;

            player.OnDotEaten += () => AddScore(10);
            player.OnPowerPelletEaten += () => AddScore(30);
        }

        public void Update()
        {
            player.Move();
            if (maze.DotCount == 0)
            {
                State = CurrentState.Won;
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

    enum CurrentState 
    {
        Playing,
        Won,
        Lost
    }
}
