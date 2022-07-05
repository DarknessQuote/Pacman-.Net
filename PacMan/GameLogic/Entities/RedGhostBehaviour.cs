using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameLogic.Entities
{
    class RedGhostBehaviour : GhostBehaviour
    {
        protected override Cell GetChaseCell() => ghost.Pacman.CurrentCell;

        protected override Cell GetScatterCell() => ghost.Maze[ghost.Maze.Width - 1, 0];
    }
}
