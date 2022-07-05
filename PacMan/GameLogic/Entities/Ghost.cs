using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic.Entities
{
    class Ghost : Entity
    {
        private GhostBehaviour behaviour;

        public GhostState State { get; private set; } = GhostState.Scatter;
        public Direction OppositeDirection
        {
            get
            {
                return CurrentDirection switch
                {
                    Direction.UP => Direction.DOWN,
                    Direction.LEFT => Direction.RIGHT,
                    Direction.RIGHT => Direction.LEFT,
                    Direction.DOWN => Direction.UP,
                    _ => Direction.NONE
                };
            }
        }
        public Player Pacman { get; private set; }


        public static Ghost GetGhost(string name, Maze maze, Player pacman)
        {
            switch (name)
            {
                case "Blinky":
                    Ghost blinky = new(maze, pacman, maze.BlinkyStartingCoords);
                    blinky.behaviour = new RedGhostBehaviour(blinky);
                    return blinky;
                default:
                    throw new Exception("Invalid Ghost name");
            }
        }

        private Ghost(Maze maze, Player pacman, (int, int) startingCoords)
            : base (maze, startingCoords)
        {
            Pacman = pacman;
        }


        protected override Direction GetDirection() => behaviour.GetDirection();

        protected override void ProcessCell()
        {

        }
    }
}
