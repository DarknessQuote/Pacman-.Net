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
using PacmanWinforms.GameSprites;

namespace PacmanWinforms.Forms
{
    public partial class GameForm : Form
    {
        Maze maze;
        GameScene gameScene;
        GameStats gameStats;
        TileSpriter spriter;
        bool isDrawn = false;

        public GameForm(Maze maze)
        {
            InitializeComponent();
            this.maze = maze;
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"{gameStats.Score:d6}";
        }

        private void UpdateLivesLabel()
        {
            livesLabel.Text = $"{gameStats.Lives}";
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!isDrawn)
            {
                foreach (Cell cell in maze)
                {
                    cell.TopTile.Draw();
                }
                isDrawn = true;
            }
            gameScene.UpdateGameState();

            switch (gameScene.State)
            {
                case (GameState.Playing):
                    return;
                case (GameState.Won):
                    RestartLevel();
                    break;
                case (GameState.Lost):
                    gameTimer.Enabled = false;
                    DefeatForm form = new(gameStats);
                    Hide();
                    form.ShowDialog();
                    Close();
                    break;
            }
        }

        private void RestartLevel()
        {
            maze.Restart();
            spriter.AttachSpritesToTiles(maze);
            gameScene = new GameScene(maze, gameStats);
            isDrawn = false;
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gameTimer.Enabled = !(gameTimer.Enabled);
            }
            else
            {
                gameScene.player.ChangeDirection((int)e.KeyCode);
            }
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            gameStats = new GameStats();
            gameScene = new(maze, gameStats);
            spriter = new(mapPanel.CreateGraphics());
            spriter.AttachSpritesToTiles(maze);
            UpdateScoreLabel();
            UpdateLivesLabel();
            gameTimer.Enabled = true;

            gameStats.OnScoreChange += () => UpdateScoreLabel();
            gameStats.OnLivesChange += () => UpdateLivesLabel();
        }
    }
}
