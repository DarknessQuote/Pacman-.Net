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
            Level level = new Level(9, 9);
            GameLoop(level);
        }
        public void GameLoop(Level level)
        {
            Pacman player = (Pacman)level.Map.GetTile(4, 4);
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                player.Move(level.Map, input);
                level.UpdateLevel();
            }
        }
    }
}
