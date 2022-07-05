namespace PacMan.GameLogic.Entities.GhostAi
{
    class OrangeGhostBehaviour : GhostBehaviour
    {
        protected override Cell ChaseCell { get => GetOrangeChaseCell(); }
        protected override Cell ScatterCell { get => ghost.Maze[0, ghost.Maze.Height - 1]; }

        public OrangeGhostBehaviour(Ghost ghost)
            : base(ghost) { }

        private Cell GetOrangeChaseCell()
        {
            if (CalculateDistanceBetweenCells(ghost.CurrentCell, ghost.PacmanTarget.CurrentCell) <= 8)
            {
                return ScatterCell;
            }
            return ghost.PacmanTarget.CurrentCell;
        }
    }
}
