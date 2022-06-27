using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameView.Screens
{
    interface IScreen
    {
        public void Render();
        public void HandleInput(ConsoleKey key);
    }
}
