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

        protected override void GetDirection()
        {
            var availableDirections = CheckAllDirections();


            if (availableDirections.Count == 0)
            {
                CurrentDirection = OppositeDirection;
            }
            if (availableDirections.Count == 1)
            {
                CurrentDirection = availableDirections[0];
            }
            if (availableDirections.Count >= 2)
            {
                double minimalDistance = CalculateDistance(GetNextCell(availableDirections[0], 1));
                Direction bestDirection = availableDirections[0];

                foreach (Direction direction in availableDirections)
                {
                    double distanceToTarget = CalculateDistance(GetNextCell(direction, 1));
                    if (distanceToTarget < minimalDistance)
                    {
                        minimalDistance = distanceToTarget;
                        bestDirection = direction;
                    }
                }

                CurrentDirection = bestDirection;
            }
        }

        protected override void ProcessCell()
        {

        }

        private List<Direction> CheckAllDirections()
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
                if (direction == OppositeDirection || GetNextCell(direction, 1).IsWall)
                {
                    continue;
                }
                availableDirections.Add(direction);
            }

            return availableDirections;
        }

        private double CalculateDistance(Cell cell)
        {
            double distanceX = cell.CellX - TargetCell.CellX;
            double distanceY = cell.CellY - TargetCell.CellY;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }
    }
}
