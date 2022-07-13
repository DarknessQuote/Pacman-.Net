using System;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic.Entities
{
    public class Player : Entity
    {
        private Direction NewDirection { get; set; }      

        public Player(Maze maze) 
            : base(maze, maze.PacmanStartingCoords) { }

        public override void ReturnToStartingCoords()
        {
            base.ReturnToStartingCoords();
            NewDirection = Direction.NONE;
        }
        public void ChangeDirection(ConsoleKey input)
        {
            NewDirection = input switch
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
            if (!GetNextCell(NewDirection).IsWall) return NewDirection;
            if (NextCell.IsWall) return Direction.NONE;
            return CurrentDirection;

        }

        protected override void ProcessCell()
        {
            foreach (Tile tile in CurrentCell)
            {
                tile.Process();
            }
        }
    }
}
