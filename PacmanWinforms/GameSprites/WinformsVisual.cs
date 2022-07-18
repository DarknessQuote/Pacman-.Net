using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanWinforms.GameSprites
{
    class WinformsVisual : IVisual
    {
        private readonly Graphics graphics;
        private readonly Image sprite;

        public WinformsVisual(Graphics graphics, Image sprite)
        {
            this.graphics = graphics;
            this.sprite = sprite;
        }

        public void Draw(int x, int y)
        {
            graphics.DrawImage(sprite, x*14, y*14, 14, 14);
        }
    }
}
