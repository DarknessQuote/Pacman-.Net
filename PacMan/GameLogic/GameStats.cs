using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameLogic
{
    class GameStats
    {
        public int Score { get; private set; }
        public int Lives { get; private set; }
        public int GamesWon { get; private set; }
        public int GhostsEaten { get; private set; }

        public event Action OnScoreChange;
        public event Action OnLivesChange;

        public GameStats()
        {
            Score = 0;
            GamesWon = 0;
            Lives = 3;
        }

        public void AddScore(int score)
        {
            Score += score;
            OnScoreChange?.Invoke();
        }

        public void RemoveLife()
        {
            Lives--;
            OnLivesChange?.Invoke();
        }

        public void IncreaseGamesWonCounter() => GamesWon++;

        public void RewardForEatenGhost()
        {
            GhostsEaten++;
            AddScore(200);
        }

        public void CalculateFinalScore()
        {
            Score += Lives * 200;
        }
    }
}
