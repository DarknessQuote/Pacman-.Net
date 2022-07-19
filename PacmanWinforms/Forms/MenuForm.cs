using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinforms.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            MapSelectForm mapSelect = new();
            Hide();
            mapSelect.ShowDialog();
            Show();
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            InstructionsForm instruct = new();
            instruct.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
