using PacmanEngine.GameLogic.Tiles;

namespace PacmanEngine.GameLogic.Entities
{
    public abstract class Entity
    {
        protected Tile controlledTile;
        public Maze Maze { get; private set; }
        protected (int X, int Y) StartingCoords { get; set; }
        public Direction CurrentDirection { get; protected set; } = Direction.NONE;
        public Cell CurrentCell { get => Maze[controlledTile.CoordX, controlledTile.CoordY]; }
        public Cell NextCell { get => GetNextCell(CurrentDirection); }

        public Entity(Maze maze, (int X, int Y) startingCoords)
        {
            Maze = maze;
            StartingCoords = startingCoords;
            controlledTile = maze[startingCoords.X, startingCoords.Y].GetTopTile();
        }

        public void Update()
        {
            CurrentDirection = GetDirection();
            MoveToCell(NextCell);
            ProcessCell();
        }

        public virtual void ReturnToStartingCoords()
        {
            MoveToCell(Maze[StartingCoords.X, StartingCoords.Y]);
            CurrentDirection = Direction.NONE;
        }

        public Cell GetNextCell(Direction direction, int distance = 1)
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
