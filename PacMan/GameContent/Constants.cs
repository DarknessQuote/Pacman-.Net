using System;

namespace GameContent
{
    class Constants
    {
        public const char EMPTY_TILE = ' ';
        public const char WALL_TILE = '#';
        public const char DOT_TILE = '·';
        public const char POWER_PELLET_TILE = 'o';
        public const char PACMAN_TILE = 'C';
        public const char GHOST_TILE = 'A';
        public const char SCARED_GHOST_TILE = 'V';

        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
        public const ConsoleColor WALL_COLOR = ConsoleColor.DarkBlue;
        public const ConsoleColor DOT_COLOR = ConsoleColor.Yellow;
        public const ConsoleColor POWER_PELLET_COLOR = ConsoleColor.Yellow;
        public const ConsoleColor PACMAN_COLOR = ConsoleColor.DarkYellow;
        public const ConsoleColor GHOST_COLOR = ConsoleColor.Red;
    }
}
