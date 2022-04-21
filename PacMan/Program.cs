using System;

namespace PacMan
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(28, 32);

            new Level(Console.WindowHeight-1, Console.WindowWidth-1);
            Console.ReadKey();
        }
    }
}
