using System;
using PacMan.GameLogic;
using PacMan.Tiles;

namespace PacMan.Entities
{
    class Player
    {
        private readonly Tile player;
        private readonly Maze maze;        
        private Direction _playerDirection;
        private Tile tileUnderneath;

        public Player(Tile player, Maze maze)
        {
            this.player = player;
            this.maze = maze;

            _playerDirection = Direction.NONE;
            tileUnderneath = new EmptyTile(player.CoordX, player.CoordY);
        }

        public void Move()
        {
            if (_playerDirection == Direction.NONE) return;
            Tile nextTile = GetNextTile(_playerDirection);
            if (nextTile is Wall)
            {
                _playerDirection = Direction.NONE;
                return;
            }
            ChangePlayerCoordinates(nextTile);
            ProcessCollisions();
        }

        public void ChangeDirection(ConsoleKey input)
        {
            Direction directionChanged = input switch
            {
                ConsoleKey.W => Direction.UP,
                ConsoleKey.A => Direction.LEFT,
                ConsoleKey.D => Direction.RIGHT,
                ConsoleKey.S => Direction.DOWN,
                _ => _playerDirection
            };

            if (GetNextTile(directionChanged) is Wall) return;
            _playerDirection = directionChanged;
        }

        private Tile GetNextTile(Direction direction)
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

        private void ChangePlayerCoordinates(Tile nextTile)
        {
            maze[player.CoordX, player.CoordY] = tileUnderneath;
            player.CoordX = nextTile.CoordX;
            player.CoordY = nextTile.CoordY;
            tileUnderneath = maze[player.CoordX, player.CoordY];
            maze[player.CoordX, player.CoordY] = player;
        }

        private void ProcessCollisions()
        {
            switch (tileUnderneath)
            {
                case (EatableTile eTile):
                    eTile.Eat();
                    break;
            }
        }
    }
}
