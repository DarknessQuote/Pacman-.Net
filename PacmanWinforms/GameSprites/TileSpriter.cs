using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PacmanEngine.GameLogic;
using PacmanEngine.GameLogic.Tiles;
using PacmanEngine.GameLogic.Entities;

namespace PacmanWinforms.GameSprites
{
    class TileSpriter
    {
        private readonly Dictionary<string, WinformsVisual> visuals;

        public TileSpriter(Graphics graphics)
        {
            visuals = new()
            {
                { "pacman", new WinformsVisual(graphics, Image.FromFile("GameSprites/pacman.png")) },
                { "redGhost", new WinformsVisual(graphics, Image.FromFile("GameSprites/redghost.png")) },
                { "pinkGhost", new WinformsVisual(graphics, Image.FromFile("GameSprites/pinkghost.png")) },
                { "cyanGhost", new WinformsVisual(graphics, Image.FromFile("GameSprites/cyanghost.png")) },
                { "orangeGhost", new WinformsVisual(graphics, Image.FromFile("GameSprites/orangeghost.png")) },
                { "scaredGhost", new WinformsVisual(graphics, Image.FromFile("GameSprites/scaredghost.png")) },
                { "wall", new WinformsVisual(graphics, Image.FromFile("GameSprites/wall.png")) },
                { "dot", new WinformsVisual(graphics, Image.FromFile("GameSprites/dot.png")) },
                { "powerPellet", new WinformsVisual(graphics, Image.FromFile("GameSprites/powerpellet.png")) },
                { "emptySpace", new WinformsVisual(graphics, Image.FromFile("GameSprites/emptyspace.png")) },
            };

            EatableTile.ChangeTileVisual += (eTile) => eTile.Visual = visuals["emptySpace"];
            Ghost.OnFrightenedStart += (ghost) => ghost.Visual = visuals["scaredGhost"];
            Ghost.OnFrightenedEnd += (ghost) =>
            {
                switch (ghost)
                {
                    case RedGhost:
                        ghost.Visual = visuals["redGhost"];
                        break;
                    case PinkGhost:
                        ghost.Visual = visuals["pinkGhost"];
                        break;
                    case CyanGhost:
                        ghost.Visual = visuals["cyanGhost"];
                        break;
                    case OrangeGhost:
                        ghost.Visual = visuals["orangeGhost"];
                        break;
                }
            };
        }

        public void AttachSpritesToTiles(Maze maze)
        {
            foreach (Cell cell in maze)
            {
                foreach (Tile tile in cell)
                {
                    tile.Visual = tile switch
                    {
                        Wall => visuals["wall"],
                        Dot => visuals["dot"],
                        PowerPellet => visuals["powerPellet"],
                        Pacman => visuals["pacman"],
                        RedGhost => visuals["redGhost"],
                        PinkGhost => visuals["pinkGhost"],
                        CyanGhost => visuals["cyanGhost"],
                        OrangeGhost => visuals["orangeGhost"],
                        _ => visuals["emptySpace"]
                    };
                }
            }
        }
    }
}
