using System;
using GameContent;

namespace PacMan.GameLogic.Tiles
{
    class PowerPellet : EatableTile
    {
        public PowerPellet(int x, int y)
            : base(x, y, TileVisuals.POWER_PELLET_TILE, TileVisuals.POWER_PELLET_COLOR) { }
    }
}
