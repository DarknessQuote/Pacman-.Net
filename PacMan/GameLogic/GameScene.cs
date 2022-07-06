using System;
using System.Linq;
using PacMan.GameLogic.Entities;

namespace PacMan.GameLogic
{
    class GameScene
    {
        private readonly Maze maze;
        private readonly Ghost blinky;
        private readonly Ghost pinky;
        private readonly Ghost inky;
        private readonly Ghost clyde;
        public readonly Player player;

        private readonly Entity[] entities;
        private readonly Ghost[] ghosts;

        public GameState State { get; private set; } = GameState.Playing;
        public GameStats Stats { get; private set; }

        public GameScene(Maze maze, GameStats startingStats)
        {
            this.maze = maze;
            Stats = startingStats;

            entities = new Entity[]
            {
                player = new Player(maze),
                blinky = Ghost.GetGhost("Blinky", maze, player),
                pinky = Ghost.GetGhost("Pinky", maze, player),
                inky = Ghost.GetGhost("Inky", maze, player),
                clyde = Ghost.GetGhost("Clyde", maze, player)
            };
            ghosts = new Ghost[] { blinky, pinky, inky, clyde };

            player.OnDotEaten += () => Stats.AddScore(10);
            player.OnPowerPelletEaten += () => Stats.AddScore(50);
        }

        public void Update()
        {
            foreach (var entity in entities)
            {
                entity.Update();
                CheckForGhostCollision();

                if (State == GameState.Lost) break;
            }

            if (maze.DotCount == 0 && State != GameState.Lost)
            {
                Stats.CalculateFinalScore();
                Stats.IncreaseGamesWonCounter();
                State = GameState.Won;
            }
        }

        private void CheckForGhostCollision()
        {
            foreach (Ghost ghost in ghosts)
            {
                if (ghost.CurrentCell == player.CurrentCell)
                {
                    ProcessGhostCollision(ghost);
                }
            }
        }

        private void ProcessGhostCollision(Ghost ghost)
        {
            if (ghost.State == GhostState.Frightened)
            {
                ghost.ReturnToStartingCoords();
                Stats.RewardForEatenGhost();
            }
            else
            {
                Stats.RemoveLife();
                if (Stats.Lives == 0)
                {
                    State = GameState.Lost;
                    return;
                }
                foreach (Entity entity in entities)
                {
                    entity.ReturnToStartingCoords();
                }
            }
        }
    }
}
