using System;
using PacMan.GameLogic;
using PacMan.Tiles;

namespace PacMan.Entities
{
    class Player
    {
        private readonly Tile player;
        private readonly Maze maze;        

        public Direction PacmanDirection { get; private set; }
        private Direction ChangedDirection { get; set; }
        private (int X, int Y) StartingCoords { get; set; }
        private Cell CurrentCell { get => maze[player.CoordX, player.CoordY]; }
        private Cell NextCell { get => GetNextCell(PacmanDirection, 1); }

        public event Action OnDotEaten;
        public event Action OnPowerPelletEaten;

        public Player(Maze maze)
        {
            this.maze = maze;
            StartingCoords = maze.PacmanStartingCoords;
            player = maze[StartingCoords.X, StartingCoords.Y].GetTopLayerTile();

            PacmanDirection = Direction.NONE;
        }

        public void Move()
        {
            GetDirection();
            MoveToNextCell(NextCell);
            ProcessCell();
        }

        private void GetDirection()
        {
            if (PacmanDirection == ChangedDirection || GetNextCell(ChangedDirection, 1).IsWall)
            {
                if (NextCell.IsWall)
                {
                    PacmanDirection = Direction.NONE;
                }
                return;
            }            
            PacmanDirection = ChangedDirection;
        }

        public void ChangeDirection(ConsoleKey input)
        {
            ChangedDirection = input switch
            {
                ConsoleKey.W => Direction.UP,
                ConsoleKey.A => Direction.LEFT,
                ConsoleKey.D => Direction.RIGHT,
                ConsoleKey.S => Direction.DOWN,
                _ => PacmanDirection
            };
        }

        private Cell GetNextCell(Direction direction, int distance)
        {
            return direction switch
            {
                Direction.UP => maze[player.CoordX, player.CoordY - distance],
                Direction.RIGHT => maze[player.CoordX + distance, player.CoordY],
                Direction.LEFT => maze[player.CoordX - distance, player.CoordY],
                Direction.DOWN => maze[player.CoordX, player.CoordY + distance],
                _ => CurrentCell
            };
        }

        private void MoveToNextCell(Cell nextCell)
        {
            CurrentCell.RemoveTile(player);
            nextCell.AddTile(player);
            player.CoordX = nextCell.CellX;
            player.CoordY = nextCell.CellY;
        }

        private void ProcessCell()
        {
            foreach (Tile tile in CurrentCell)
            {
                if (tile is Dot dot && !dot.IsEaten)
                {
                    dot.Eat();
                    OnDotEaten?.Invoke();
                }
                if (tile is PowerPellet pp && !pp.IsEaten)
                {
                    pp.Eat();
                    OnPowerPelletEaten?.Invoke();
                }
            }
        }
    }
}
