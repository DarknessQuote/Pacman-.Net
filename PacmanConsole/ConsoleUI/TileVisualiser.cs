using System;
using System.Collections.Generic;
using PacmanEngine.GameLogic;
using PacmanEngine.GameLogic.Entities;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanConsole.ConsoleUI
{
    class TileVisualiser
    {
        private static readonly Dictionary<string, ConsoleVisual> visuals = new()
        {
            {"pacman", new ConsoleVisual('C', ConsoleColor.Yellow) },
            {"redGhost", new ConsoleVisual('A', ConsoleColor.DarkRed) },
            {"pinkGhost", new ConsoleVisual('A', ConsoleColor.Magenta) },
            {"cyanGhost", new ConsoleVisual('A', ConsoleColor.Cyan) },
            {"orangeGhost", new ConsoleVisual('A', ConsoleColor.DarkYellow) },
            {"scaredGhost", new ConsoleVisual('V', ConsoleColor.Blue) },
            {"wall", new ConsoleVisual('#', ConsoleColor.DarkBlue) },
            {"dot", new ConsoleVisual('·', ConsoleColor.Yellow) },
            {"powerPellet", new ConsoleVisual('o', ConsoleColor.Yellow) },
            {"emptySpace", new ConsoleVisual(' ', ConsoleColor.Black) },
        };

        static TileVisualiser()
        {
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

        public static void AttachVisualsToTiles(Maze maze)
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
