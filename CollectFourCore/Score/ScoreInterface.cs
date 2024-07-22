using CollectFour;
using System.Collections.Generic;

namespace CollectFourCore.Score
{
    public interface ScoreInterface
    {
        public void PrintScoreboard();
        public void PlayerAdd(Player player);
        public IList<Player> GetTopScores();
    }
}
