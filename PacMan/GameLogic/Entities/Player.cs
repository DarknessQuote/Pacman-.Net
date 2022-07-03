using System;
using PacMan.GameLogic;
using PacMan.Tiles;

namespace PacMan.Entities
{
    class Player
    {
        private readonly Tile player;
        private readonly Maze maze;        
        private Direction playerDirection;
        private (int X, int Y) StartingCoords { get; set; }

        public event Action OnDotEaten;
        public event Action OnPowerPelletEaten;

        public Player(Maze maze)
        {
            this.maze = maze;
            StartingCoords = maze.PlayerStartingCoords;
            player = maze[StartingCoords.X, StartingCoords.Y].GetTopTile();

            playerDirection = Direction.NONE;
        }

        public void Move()
        {
            if (playerDirection == Direction.NONE) return;
            Cell nextCell = GetNextCell(playerDirection);
            if (nextCell.GetTopTile() is Wall)
            {
                playerDirection = Direction.NONE;
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
                _ => playerDirection
            };

            if (GetNextCell(directionChanged).GetTopTile() is Wall) return;
            playerDirection = directionChanged;
        }

        private Cell GetNextCell(Direction direction)
        {
            return direction switch
            {
                Direction.UP => maze[player.CoordX, player.CoordY - 1],
                Direction.RIGHT => maze[player.CoordX + 1, player.CoordY],
                Direction.LEFT => maze[player.CoordX - 1, player.CoordY],
                Direction.DOWN => maze[player.CoordX, player.CoordY + 1],
                Direction.NONE => maze[player.CoordX, player.CoordY],
                _ => null
            };
        }

        private void ChangePlayerCoordinates(Cell nextCell)
        {
            maze[player.CoordX, player.CoordY].RemoveTile();
            player.CoordX = nextCell.CellX;
            player.CoordY = nextCell.CellY;
            maze[player.CoordX, player.CoordY].AddTile(player);
        }

        private void ProcessCell()
        {
            foreach (Tile tile in maze[player.CoordX, player.CoordY])
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
