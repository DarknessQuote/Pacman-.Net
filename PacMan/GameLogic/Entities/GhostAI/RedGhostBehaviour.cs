namespace PacMan.GameLogic.Entities.GhostAi
{
    class RedGhostBehaviour : GhostBehaviour
    {
        protected override Cell ChaseCell { get => ghost.PacmanTarget.CurrentCell; }
        protected override Cell ScatterCell { get => ghost.Maze[ghost.Maze.Width - 1, 0]; }

        public RedGhostBehaviour(Ghost ghost)
            : base(ghost) { }
    }
}
