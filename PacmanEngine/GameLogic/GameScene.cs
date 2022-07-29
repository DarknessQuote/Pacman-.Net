using PacmanEngine.GameLogic.Entities;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic
{
    public class GameScene
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
        public Statistics Statistics { get; private set; }

        public GameScene(Maze maze, Statistics startingStats)
        {
            this.maze = maze;
            Statistics = startingStats;

            entities = new Entity[]
            {
                player = new Player(maze),
                blinky = Ghost.GetGhost("Blinky", maze, player),
                pinky = Ghost.GetGhost("Pinky", maze, player),
                inky = Ghost.GetGhost("Inky", maze, player),
                clyde = Ghost.GetGhost("Clyde", maze, player)
            };
            ghosts = new Ghost[] { blinky, pinky, inky, clyde };

            Dot.OnDotEaten += () => Statistics.AddScore(10);
            PowerPellet.OnPowerPelletEaten += () => Statistics.AddScore(50);
            Entity.OnEntityMoved += (cell1, cell2) =>
            {
                cell1.TopTile.Draw();
                cell2.TopTile.Draw();
            };
        }

        public void UpdateGameState()
        {
            foreach (var entity in entities)
            {
                entity.Update();
                CheckForGhostCollision();

                if (State == GameState.Lost) break;
            }

            if (maze.DotCount == 0 && State != GameState.Lost)
            {
                Statistics.UpdateFinalScore();
                Statistics.IncreaseGamesWonCounter();
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
                Statistics.RewardForEatenGhost();
            }
            else
            {
                Statistics.RemoveLife();
                if (Statistics.Lives == 0)
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
