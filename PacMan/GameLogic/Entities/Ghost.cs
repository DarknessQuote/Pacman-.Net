using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic.Entities
{
    class Ghost : Entity
    {
        private Player Pacman { get; set; }
        private Cell TargetCell { get => Pacman.CurrentCell; }
        private Direction OppositeDirection
        {
            get
            {
                return CurrentDirection switch
                {
                    Direction.UP => Direction.DOWN,
                    Direction.LEFT => Direction.RIGHT,
                    Direction.RIGHT => Direction.LEFT,
                    Direction.DOWN => Direction.UP,
                    _ => Direction.NONE
                };
            }
        }

        public Ghost(Maze maze, (int X, int Y) startingCoords, Player pacman)
            : base (maze, startingCoords)
        {
           Pacman = pacman;
        }

        protected override Direction GetDirection()
        {
            List<Direction> availableDirections = GetAllAvailableDirections();

            return availableDirections.Count switch
            {
                0 => OppositeDirection,
                1 => availableDirections[0],
                _ => GetBestDirection(availableDirections)
            };
        }

        protected override void ProcessCell()
        {

        }

        private List<Direction> GetAllAvailableDirections()
        {
            var allDirections = new List<Direction>()
            {
                Direction.UP,
                Direction.LEFT,
                Direction.RIGHT,
                Direction.DOWN
            };
            var availableDirections = new List<Direction>();

            foreach (Direction direction in allDirections)
            {
                if (direction == OppositeDirection || GetNextCell(direction).IsWall)
                {
                    continue;
                }
                availableDirections.Add(direction);
            }
            return availableDirections;
        }

        private double CalculateDistanceToTarget(Cell cell)
        {
            double distanceX = cell.CellX - TargetCell.CellX;
            double distanceY = cell.CellY - TargetCell.CellY;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        private Direction GetBestDirection(List<Direction> directions)
        {
            double minimalDistance = CalculateDistanceToTarget(GetNextCell(directions[0]));
            Direction bestDirection = directions[0];

            foreach (Direction direction in directions)
            {
                double distanceToTarget = CalculateDistanceToTarget(GetNextCell(direction));
                if (distanceToTarget < minimalDistance)
                {
                    minimalDistance = distanceToTarget;
                    bestDirection = direction;
                }
            }

            return bestDirection;
        }
    }
}
