using System;
using GameContent;
using PacMan.GameLogic.Entities.GhostAi;

namespace PacMan.GameLogic.Entities
{
    class Ghost : Entity
    {
        private GhostBehaviour behaviour;
        private readonly ConsoleColor mainColor;
        private int stateSwitchCounter = 0;

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
        public Player PacmanTarget { get; private set; }


        public static Ghost GetGhost(string name, Maze maze, Player pacman)
        {
            switch (name)
            {
                case "Blinky":
                    Ghost blinky = new(maze, pacman, maze.BlinkyStartingCoords);
                    blinky.behaviour = new RedGhostBehaviour(blinky);
                    return blinky;
                case "Pinky":
                    Ghost pinky = new(maze, pacman, maze.PinkyStartingCoords);
                    pinky.behaviour = new PinkGhostBehaviour(pinky);
                    return pinky;
                case "Inky":
                    Ghost inky = new(maze, pacman, maze.InkyStartingCoords);
                    inky.behaviour = new CyanGhostBehaviour(inky);
                    return inky;
                case "Clyde":
                    Ghost clyde = new(maze, pacman, maze.ClydeStartingCoords);
                    clyde.behaviour = new OrangeGhostBehaviour(clyde);
                    return clyde;
                default:
                    throw new Exception("Invalid Ghost name");
            }
        }

        private Ghost(Maze maze, Player pacman, (int, int) startingCoords)
            : base (maze, startingCoords)
        {
            PacmanTarget = pacman;
            mainColor = controlledTile.TileColor;
            Player.OnPowerPelletEaten += () => SwitchState(GhostState.Frightened);
        }

        public override void ReturnToStartingCoords()
        {
            base.ReturnToStartingCoords();
            SwitchState(GhostState.Scatter);
        }
        public void SwitchState(GhostState gState)
        {
            if (gState == GhostState.Frightened)
            {
                controlledTile.TileTexture = Constants.SCARED_GHOST_TILE;
                controlledTile.TileColor = Constants.SCARED_GHOST_COLOR;
            }
            else
            {
                controlledTile.TileTexture = Constants.GHOST_TILE;
                controlledTile.TileColor = mainColor;
            }

            State = gState;
            CurrentDirection = OppositeDirection;
            stateSwitchCounter = 0;            
        }

        protected override Direction GetDirection()
        {
            UpdateStateSwitchCounter();
            return behaviour.GetDirection();
        }

        protected override void ProcessCell()
        {

        }

        private void UpdateStateSwitchCounter()
        {
            if (State == GhostState.Scatter && stateSwitchCounter >= 50)
            {
                SwitchState(GhostState.Chase);
                return;
            }
            else if ((State == GhostState.Chase && stateSwitchCounter >= 100) ||
                     (State == GhostState.Frightened && stateSwitchCounter >= 50))
            {
                SwitchState(GhostState.Scatter);
                return;
            }

            stateSwitchCounter++;
        }
    }
}
