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
            Cell blinkyCell = ghost.Maze.GetBlinkyCell();
            int targetCellX = pacmanNextCell.CellX * 2 - blinkyCell.CellX;
            int targetCellY = pacmanNextCell.CellY * 2 - blinkyCell.CellY;
            return ghost.Maze[targetCellX, targetCellY];
        }
    }
}
