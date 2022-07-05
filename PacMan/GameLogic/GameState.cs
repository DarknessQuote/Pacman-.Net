using System;
using System.Linq;
using PacMan.GameLogic.Entities;

namespace PacMan.GameLogic
{
    class GameState
    {
        private readonly Maze maze;
        private readonly Player player;
        private readonly Ghost blinky;
        private readonly Ghost pinky;
        private readonly Ghost inky;
        private readonly Ghost clyde;

        private readonly Entity[] entities;
        private readonly Ghost[] ghosts;

        public CurrentState State { get; private set; } = CurrentState.Playing;
        public int Score { get; private set; }
        public int Lives { get; private set; }

        public event Action ScoreAdded;
        public event Action LifeLost;

        public GameState(Maze maze, int score = 0, int lives = 3)
        {
            this.maze = maze;
            Score = score;
            Lives = lives;

            entities = new Entity[]
            {
                player = new Player(maze),
                blinky = Ghost.GetGhost("Blinky", maze, player),
                pinky = Ghost.GetGhost("Pinky", maze, player),
                inky = Ghost.GetGhost("Inky", maze, player),
                clyde = Ghost.GetGhost("Clyde", maze, player)
            };
            ghosts = new Ghost[] { blinky, pinky, inky, clyde };

            Player.OnDotEaten += () => AddScore(10);
            Player.OnPowerPelletEaten += () => AddScore(50);
        }

        public void Update()
        {
            foreach (var entity in entities)
            {
                entity.Update();
                CheckForGhostCollision();

                if (Lives == 0)
                {
                    State = CurrentState.Lost;
                    break;
                }
            }

            if (maze.DotCount == 0 && State != CurrentState.Lost)
            {
                State = CurrentState.Won;
            }
        }

        public void GetInput(ConsoleKey input)
        {
            player.ChangeDirection(input);
        }

        private void CheckForGhostCollision()
        {
            foreach (Ghost ghost in ghosts)
            {
                if (ghost.CurrentCell == player.CurrentCell)
                {
                    if (ghost.State == GhostState.Frightened)
                    {
                        ghost.ReturnToStartingCoords();
                        AddScore(200);
                    }
                    else
                    {
                        foreach (Entity entity in entities)
                        {
                            entity.ReturnToStartingCoords();
                        }
                        Lives--;
                        LifeLost?.Invoke();
                    }
                }
            }
        }

        private void AddScore(int scoreToAdd)
        {
            Score += scoreToAdd;
            ScoreAdded?.Invoke();
        }
    }

    enum CurrentState 
    {
        Playing,
        Won,
        Lost
    }
}
