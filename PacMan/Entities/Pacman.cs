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

        public Pacman(int y, int x)
            : base (y, x, 'c') {}

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
        }

        public void Move(Map map, ConsoleKey direction)
        {
            map.SetTile(y, x, new EmptyTile(y, x));
            Tile estLocation;

            switch (direction)
            {
                case (ConsoleKey)Direction.UP:
                    estLocation = map.GetTile(y, x - 1);
                    break;
                case (ConsoleKey)Direction.DOWN:
                    estLocation = map.GetTile(y, x + 1);
                    break;
                case (ConsoleKey)Direction.LEFT:
                    estLocation = map.GetTile(y - 1, x);
                    break;
                case (ConsoleKey)Direction.RIGHT:
                    estLocation = map.GetTile(y + 1, x);
                    break;
                default:
                    estLocation = map.GetTile(y, x);
                    break;
            }

            if (estLocation is Wall)
            {
                estLocation = map.GetTile(y, x);
            }

            x = estLocation.x;
            y = estLocation.y;
            map.SetTile(y, x, new Pacman(y, x));
        }
    }
}
