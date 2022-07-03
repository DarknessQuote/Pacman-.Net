using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class PowerPellet : EatableTile
    {
        public PowerPellet(int x, int y)
            : base(x, y, Constants.POWER_PELLET_TILE, Constants.POWER_PELLET_COLOR) { }
    }
}
