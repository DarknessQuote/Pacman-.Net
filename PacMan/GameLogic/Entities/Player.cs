using System;
using PacMan.GameLogic;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic.Entities
{
    class Player : Entity
    {
        private Direction ChangedDirection { get; set; }

        public static event Action OnDotEaten;
        public static event Action OnPowerPelletEaten;

        public Player(Maze maze, (int, int) startingCoords)
            : base(maze, startingCoords) { }

        public void ChangeDirection(ConsoleKey input)
        {
            ChangedDirection = input switch
            {
                ConsoleKey.W => Direction.UP,
                ConsoleKey.A => Direction.LEFT,
                ConsoleKey.D => Direction.RIGHT,
                ConsoleKey.S => Direction.DOWN,
                _ => CurrentDirection
            };
        }

        protected override Direction GetDirection()
        {
            if (CurrentDirection == ChangedDirection || GetNextCell(ChangedDirection).IsWall)
            {
                if (NextCell.IsWall)
                {
                    CurrentDirection = Direction.NONE;
                }
                return CurrentDirection;
            }            
            return ChangedDirection;
        }

        protected override void ProcessCell()
        {
            foreach (Tile tile in CurrentCell)
            {
                if (tile is Dot dot && !dot.IsEaten)
                {
                    dot.Eat();
                    OnDotEaten?.Invoke();
                }
                if (tile is PowerPellet pp && !pp.IsEaten)
                {
                    pp.Eat();
                    OnPowerPelletEaten?.Invoke();
                }
                if (tile is Blinky)
                {
                    ProcessGhostTouch();
                }
            }
        }
    }
}
