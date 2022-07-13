using System;
using System.Collections.Generic;
using System.Linq;

namespace PacmanEngine.GameLogic.Entities.GhostAi
{
    abstract class GhostBehaviour
    {
        protected Ghost ghost;
        private Cell TargetCell { get => ghost.State == GhostState.Chase ? ChaseCell : ScatterCell; }
        protected abstract Cell ChaseCell { get; }
        protected abstract Cell ScatterCell { get; }

        public GhostBehaviour(Ghost ghost)
        {
            this.ghost = ghost;
        }

        public Direction GetDirection()
        {
            List<Direction> availableDirections = GetAllAvailableDirections();

            if (ghost.State == GhostState.Frightened)
            {
                return GetDirectionForFrightened(availableDirections);
            }

            return availableDirections.Count switch
            {
                0 => ghost.OppositeDirection,
                1 => availableDirections[0],
                _ => GetBestDirection(availableDirections)
            };
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
            return allDirections
                .Where(d => d != ghost.OppositeDirection && !(ghost.GetNextCell(d).IsWall))
                .ToList();
        }

        private Direction GetDirectionForFrightened(List<Direction> directions)
        {
            if (!(ghost.NextCell.IsWall))
            {
                return ghost.CurrentDirection;
            }

            Random rand = new();
            return directions[rand.Next(0, directions.Count - 1)];
        }

        protected static double CalculateDistanceBetweenCells(Cell firstCell, Cell secondCell)
        {
            double distanceX = firstCell.CellX - secondCell.CellX;
            double distanceY = firstCell.CellY - secondCell.CellY;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        private Direction GetBestDirection(List<Direction> directions)
        {
            double minimalDistance = CalculateDistanceBetweenCells(ghost.GetNextCell(directions[0]), TargetCell);
            Direction bestDirection = directions[0];

            foreach (Direction direction in directions)
            {
                double distanceToTarget = CalculateDistanceBetweenCells(ghost.GetNextCell(direction), TargetCell);
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
