using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Entities;
using PacMan.Tiles;

namespace PacMan
{
    class Game
    {
        public Game()
        {
            Console.CursorVisible = false;
            Level level = new Level(27, 31);
            GameLoop(level);
        }
        public void GameLoop(Level level)
        {
            Pacman player = (Pacman)level.map[13, 15];
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                player.Move(level.map, input);
                level.PrintLevel();
            }
        }
    }
}
