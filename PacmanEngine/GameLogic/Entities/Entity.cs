using System;
using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic.Entities
{
    public abstract class Entity
    {
        protected Tile controlledTile;
        internal Maze Maze { get; private set; }
        protected (int X, int Y) StartingCoords { get; set; }
        protected internal Direction CurrentDirection { get; protected set; } = Direction.NONE;
        internal Cell CurrentCell { get => Maze[controlledTile.CoordX, controlledTile.CoordY]; }
        internal Cell NextCell { get => GetNextCell(CurrentDirection); }
        internal Cell PreviousCell { get; set; }

        public static event Action<Cell, Cell> OnEntityMoved;

        public Entity(Maze maze, (int X, int Y) startingCoords)
        {
            Maze = maze;
            StartingCoords = startingCoords;
            controlledTile = maze[startingCoords.X, startingCoords.Y].TopTile;
        }

        internal void Update()
        {
            CurrentDirection = GetDirection();
            PreviousCell = CurrentCell;
            MoveToCell(NextCell);
            ProcessCell();
            OnEntityMoved?.Invoke(CurrentCell, PreviousCell);
        }

        internal virtual void ReturnToStartingCoords()
        {
            PreviousCell = CurrentCell;
            MoveToCell(Maze[StartingCoords.X, StartingCoords.Y]);
            OnEntityMoved?.Invoke(CurrentCell, PreviousCell);
            CurrentDirection = Direction.NONE;
        }

        internal Cell GetNextCell(Direction direction, int distance = 1)
        {
            return direction switch
            {
                Direction.UP => Maze[controlledTile.CoordX, controlledTile.CoordY - distance],
                Direction.RIGHT => Maze[controlledTile.CoordX + distance, controlledTile.CoordY],
                Direction.LEFT => Maze[controlledTile.CoordX - distance, controlledTile.CoordY],
                Direction.DOWN => Maze[controlledTile.CoordX, controlledTile.CoordY + distance],
                _ => CurrentCell
            };
        }

        protected abstract Direction GetDirection();

        private void MoveToCell(Cell cell)
        {
            CurrentCell.RemoveTile(controlledTile);
            cell.AddTile(controlledTile);
            controlledTile.CoordX = cell.CellX;
            controlledTile.CoordY = cell.CellY;
        }

        protected abstract void ProcessCell();
    }
}
