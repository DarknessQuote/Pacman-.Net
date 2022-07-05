using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameLogic.Entities
{
    abstract class GhostBehaviour
    {
        protected Ghost ghost;

        public void HookBehaviourToGhost(Ghost ghost)
        {
            this.ghost = ghost;
        }

        public Cell GetTargetCell()
        {
            return ghost.State switch
            {
                (GhostState.Chase) => GetChaseCell(),
                (GhostState.Scatter) => GetScatterCell(),
                _ => null,
            };
        }

        protected abstract Cell GetChaseCell();

        protected abstract Cell GetScatterCell();
    }
}
