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
        protected Maze maze;

        private (int X, int Y) StartingCoords { get; set; }
        public Direction CurrentDirection { get; protected set; }
        protected Cell CurrentCell { get => maze[controlledTile.CoordX, controlledTile.CoordY]; }
        protected Cell NextCell { get => GetNextCell(CurrentDirection, 1); }

        public Entity(Maze maze, (int X, int Y) startingCoords)
        {
            this.maze = maze;
            StartingCoords = startingCoords;
            controlledTile = maze[StartingCoords.X, StartingCoords.Y].GetTopLayerTile();
            CurrentDirection = Direction.NONE;
        }

        public void Move()
        {
            GetDirection();
            MoveToNextCell();
            ProcessCell();
        }

        protected abstract void GetDirection();

        private void MoveToNextCell()
        {
            CurrentCell.RemoveTile(controlledTile);
            NextCell.AddTile(controlledTile);
            controlledTile.CoordX = NextCell.CellX;
            controlledTile.CoordY = NextCell.CellY;
        }

        protected abstract void ProcessCell();

        protected Cell GetNextCell(Direction direction, int distance)
        {
            return direction switch
            {
                Direction.UP => maze[controlledTile.CoordX, controlledTile.CoordY - distance],
                Direction.RIGHT => maze[controlledTile.CoordX + distance, controlledTile.CoordY],
                Direction.LEFT => maze[controlledTile.CoordX - distance, controlledTile.CoordY],
                Direction.DOWN => maze[controlledTile.CoordX, controlledTile.CoordY + distance],
                _ => CurrentCell
            };
        }
    }
}
