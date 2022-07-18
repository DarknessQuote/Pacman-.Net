using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacmanEngine.GameLogic;

namespace PacmanWinforms.Forms
{
    public partial class MapSelectForm : Form
    {
        Maze maze;

        public MapSelectForm()
        {
            InitializeComponent();
        }

        private void SwitchToGameForm()
        {
            GameForm game = new(maze);
            Hide();
            game.ShowDialog();
            Close();
        }

        private void Map1Button_Click(object sender, EventArgs e)
        {
            maze = new Maze(@"Maps\Map1.txt");
            SwitchToGameForm();
        }

        private void Map2Button_Click(object sender, EventArgs e)
        {
            maze = new Maze(@"Maps\Map2.txt");
            SwitchToGameForm();
        }

        private void Map3Button_Click(object sender, EventArgs e)
        {
            maze = new Maze(@"Maps\Map3.txt");
            SwitchToGameForm();
        }

        private void Map4Button_Click(object sender, EventArgs e)
        {
            maze = new Maze(@"Maps\Map4.txt");
            SwitchToGameForm();
        }
    }
}
