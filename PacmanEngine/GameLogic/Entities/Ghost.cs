using System;
using PacmanEngine.GameLogic.Tiles;
using PacmanEngine.GameLogic.Entities.GhostAi;

namespace PacmanEngine.GameLogic.Entities
{
    public class Ghost : Entity
    {
        private GhostBehaviour behaviour;
        private int stateSwitchCounter = 0;

        public static event Action<Tile> OnFrightenedStart;
        public static event Action<Tile> OnFrightenedEnd;

        internal GhostState State { get; private set; } = GhostState.Scatter;
        internal Direction OppositeDirection
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
        internal Player PacmanTarget { get; private set; }


        internal static Ghost GetGhost(string name, Maze maze, Player pacman)
        {
            switch (name)
            {
                case "Blinky":
                    Ghost red = new(maze, pacman, maze.RedStartingCoords);
                    red.behaviour = new RedGhostBehaviour(red);
                    return red;
                case "Pinky":
                    Ghost pink = new(maze, pacman, maze.PinkStartingCoords);
                    pink.behaviour = new PinkGhostBehaviour(pink);
                    return pink;
                case "Inky":
                    Ghost cyan = new(maze, pacman, maze.CyanStartingCoords);
                    cyan.behaviour = new CyanGhostBehaviour(cyan);
                    return cyan;
                case "Clyde":
                    Ghost orange = new(maze, pacman, maze.OrangeStartingCoords);
                    orange.behaviour = new OrangeGhostBehaviour(orange);
                    return orange;
                default:
                    throw new Exception("Invalid Ghost name");
            }
        }

        private Ghost(Maze maze, Player pacman, (int, int) startingCoords)
            : base (maze, startingCoords)
        {
            PacmanTarget = pacman;
            PowerPellet.OnPowerPelletEaten += () => SwitchState(GhostState.Frightened);
        }

        internal override void ReturnToStartingCoords()
        {
            base.ReturnToStartingCoords();
            SwitchState(GhostState.Scatter);
        }

        internal void SwitchState(GhostState gState)
        {
            if (gState == GhostState.Frightened)
            {
                OnFrightenedStart?.Invoke(controlledTile);
            }
            else if (State == GhostState.Frightened && gState != GhostState.Frightened)
            {
                OnFrightenedEnd?.Invoke(controlledTile);                
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
