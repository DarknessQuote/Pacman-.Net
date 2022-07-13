using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic.Entities.GhostAi
{
    class CyanGhostBehaviour : GhostBehaviour
    {
        protected override Cell ChaseCell { get => GetCyanChaseCell(); }
        protected override Cell ScatterCell { get => ghost.Maze[ghost.Maze.Width - 1, ghost.Maze.Height - 1]; }

        public CyanGhostBehaviour(Ghost ghost)
            : base(ghost) { }

        private Cell GetCyanChaseCell()
        {
            Cell pacmanNextCell = ghost.PacmanTarget.GetNextCell(ghost.PacmanTarget.CurrentDirection, 2);
            Tile redGhostCell = ghost.Maze.RedGhostTile;
            int targetCellX = redGhostCell.CoordX + 2 * (pacmanNextCell.CellX - redGhostCell.CoordX);
            int targetCellY = redGhostCell.CoordY + 2 * (pacmanNextCell.CellY - redGhostCell.CoordY);
            return ghost.Maze[targetCellX, targetCellY];
        }
    }
}
