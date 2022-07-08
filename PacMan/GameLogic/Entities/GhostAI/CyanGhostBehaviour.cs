namespace PacMan.GameLogic.Entities.GhostAi
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
            Cell redGhostCell = ghost.Maze.GetBlinkyCell();
            int targetCellX = redGhostCell.CellX + 2 * (pacmanNextCell.CellX - redGhostCell.CellX);
            int targetCellY = redGhostCell.CellY + 2 * (pacmanNextCell.CellY - redGhostCell.CellY);
            return ghost.Maze[targetCellX, targetCellY];
        }
    }
}
