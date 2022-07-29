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

        public MapSelectForm()
        {
            InitializeComponent();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            string mapPath = (sender as Button).Tag.ToString();
            var maze = new Maze(mapPath);

            GameForm game = new(maze);
            Hide();
            game.ShowDialog();
            Close();
        }
    }
}
