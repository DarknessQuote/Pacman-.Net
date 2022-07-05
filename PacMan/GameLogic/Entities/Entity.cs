﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameLogic.Tiles;

namespace PacMan.GameLogic.Entities
{
    abstract class Entity
    {
        protected Tile controlledTile;

        public static event Action OnGhostTouch;

        public Maze Maze { get; private set; }
        private (int X, int Y) StartingCoords { get; set; }
        public Direction CurrentDirection { get; protected set; }
        public Cell CurrentCell { get => Maze[controlledTile.CoordX, controlledTile.CoordY]; }
        protected Cell NextCell { get => GetNextCell(CurrentDirection); }        
        
        public Entity(Maze maze, (int X, int Y) startingCoords)
        {
            Maze = maze;
            StartingCoords = startingCoords;
            controlledTile = maze[StartingCoords.X, StartingCoords.Y].GetTopLayerTile();
            CurrentDirection = Direction.NONE;
        }

        public void Update
            ()
        {
            CurrentDirection = GetDirection();
            MoveToCell(NextCell);
            ProcessCell();
        }

        public void ReturnToStartingCoords()
        {
            MoveToCell(Maze[StartingCoords.X, StartingCoords.Y]);
            CurrentDirection = Direction.NONE;
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

        protected Cell GetNextCell(Direction direction, int distance = 1)
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

        protected void ProcessGhostTouch()
        {
            OnGhostTouch?.Invoke();
        }
    }
}
