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
        private (int X, int Y) StartingCoords { get; set; }
        private Cell CurrentCell { get => maze[player.CoordX, player.CoordY]; }

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
            if (PacmanDirection == Direction.NONE) return;
            Cell nextCell = GetNextCell(PacmanDirection, 1);
            if (nextCell.IsWall)
            {
                PacmanDirection = Direction.NONE;
                return;
            }
            ChangePlayerCoordinates(nextCell);
            ProcessCell();
        }

        public void ChangeDirection(ConsoleKey input)
        {
            Direction directionChanged = input switch
            {
                ConsoleKey.W => Direction.UP,
                ConsoleKey.A => Direction.LEFT,
                ConsoleKey.D => Direction.RIGHT,
                ConsoleKey.S => Direction.DOWN,
                _ => PacmanDirection
            };

            if (GetNextCell(directionChanged, 1).IsWall) return;
            PacmanDirection = directionChanged;
        }

        private Cell GetNextCell(Direction direction, int distance)
        {
            return direction switch
            {
                Direction.UP => maze[player.CoordX, player.CoordY - distance],
                Direction.RIGHT => maze[player.CoordX + distance, player.CoordY],
                Direction.LEFT => maze[player.CoordX - distance, player.CoordY],
                Direction.DOWN => maze[player.CoordX, player.CoordY + distance],
                Direction.NONE => CurrentCell,
                _ => null
            };
        }

        private void ChangePlayerCoordinates(Cell nextCell)
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
