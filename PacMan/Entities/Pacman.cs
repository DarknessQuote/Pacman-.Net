using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Tiles;

namespace PacMan.Entities
{    
    class Pacman : Tile
    {
        enum Direction
        {
            UP = ConsoleKey.W,
            DOWN = ConsoleKey.S,
            LEFT = ConsoleKey.A,
            RIGHT = ConsoleKey.D
        }

        public Pacman(int x, int y)
            : base (x, y, 'c') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
        }

        public void Move(Tile[,] map, ConsoleKey direction)
        {
            map[x, y] = new EmptyTile(x, y);
            (int x, int y) estLocation;

            switch (direction)
            {
                case (ConsoleKey)Direction.UP:
                    estLocation = map[x - 1, y].GetCoordinates();
                    break;
                case (ConsoleKey)Direction.DOWN:
                    estLocation = map[x + 1, y].GetCoordinates();
                    break;
                case (ConsoleKey)Direction.LEFT:
                    estLocation = map[x, y - 1].GetCoordinates();
                    break;
                case (ConsoleKey)Direction.RIGHT:
                    estLocation = map[x, y + 1].GetCoordinates();
                    break;
                default:
                    estLocation = GetCoordinates();
                    break;
            }

            if (map[estLocation.x, estLocation.y] is Wall)
            {
                estLocation = GetCoordinates();
            }

            map[estLocation.x, estLocation.y] = new Pacman(estLocation.x, estLocation.y);
            x = estLocation.x;
            y = estLocation.y;
        }
    }
}
