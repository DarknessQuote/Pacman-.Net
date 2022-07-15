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
        public void ChangeDirection(int keyCode)
        {
            NewDirection = keyCode switch
            {
                87 => Direction.UP,    // W key
                65 => Direction.LEFT,  // A key
                68 => Direction.RIGHT, // D key
                83 => Direction.DOWN,  // S key
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
