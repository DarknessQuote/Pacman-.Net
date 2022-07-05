using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameLogic.Entities
{
    class RedGhostBehaviour : GhostBehaviour
    {
        protected override Cell ChaseCell { get => ghost.Pacman.CurrentCell; }
        protected override Cell ScatterCell { get => ghost.Maze[ghost.Maze.Width - 1, 0]; }

        public RedGhostBehaviour(Ghost ghost)
            : base(ghost) { }
    }
}
