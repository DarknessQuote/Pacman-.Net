namespace PacmanEngine.GameLogic.Entities.GhostAi
{
    class PinkGhostBehaviour : GhostBehaviour
    {
        protected override Cell ChaseCell { get => ghost.PacmanTarget.GetNextCell(ghost.PacmanTarget.CurrentDirection, 2); }
        protected override Cell ScatterCell { get => ghost.Maze[0, 0]; }

        public PinkGhostBehaviour(Ghost ghost)
            : base(ghost) { }
    }
}
