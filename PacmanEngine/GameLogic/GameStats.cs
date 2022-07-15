using System;

namespace PacmanEngine.GameLogic
{
    public class GameStats
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

        internal void AddScore(int score)
        {
            Score += score;
            OnScoreChange?.Invoke();
        }

        internal void RemoveLife()
        {
            Lives--;
            OnLivesChange?.Invoke();
        }

        internal void IncreaseGamesWonCounter() => GamesWon++;

        internal void RewardForEatenGhost()
        {
            GhostsEaten++;
            AddScore(200);
        }

        internal void UpdateFinalScore()
        {
            Score += Lives * 200;
        }
    }
}
