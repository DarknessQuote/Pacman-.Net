﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic.Entities
{
    class Ghost : Entity
    {
        public GhostState State { get; private set; }
        private GhostBehaviour Behaviour { get; set; }
        public Player Pacman { get; private set; }
        private Cell TargetCell { get => Behaviour.GetTargetCell(); }
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

        public static Ghost GetGhost(string name, Maze maze, Player pacman)
        {
            return name switch
            {
                "Blinky" => new Ghost(new RedGhostBehaviour(), maze, maze.BlinkyStartingCoords, pacman),
                _ => throw new Exception("Invalid ghost name")
            };
        }

        private Ghost(GhostBehaviour behaviour, Maze maze, (int X, int Y) startingCoords, Player pacman)
            : base (maze, startingCoords)
        {
            Behaviour = behaviour;
            behaviour.HookBehaviourToGhost(this);
            Pacman = pacman;
            State = GhostState.Scatter;
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
            foreach (Tile tile in CurrentCell)
            {
                if (tile is Pacman)
                {
                    ProcessGhostTouch();
                }
            }
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

            return allDirections
                .Where(d => d != OppositeDirection && !(GetNextCell(d).IsWall))
                .ToList();
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
