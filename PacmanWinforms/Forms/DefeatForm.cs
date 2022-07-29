using System;
using System.Windows.Forms;
using PacmanEngine.GameLogic;

namespace PacmanWinforms.Forms
{
    public partial class DefeatForm : Form
    {
        public DefeatForm(Statistics stats)
        {
            InitializeComponent();

            totalScoreLabel.Text = stats.Score.ToString();
            gamesWonLabel.Text = stats.GamesWon.ToString();
            ghostsEatenLabel.Text = stats.GhostsEaten.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
