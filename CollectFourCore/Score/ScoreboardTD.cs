using CollectFour;
using CollectFourCore.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectFourCore.Score
{
    public class ScoreboardTD : ScoreInterface
    {

        public void PlayerAdd(Player player)
        {
            using (var context = new CollectFourContext())
            {
                context.Scores.Add(player);
                context.SaveChanges();
            }
        }

        public IList<Player> GetTopScores()
        {
            using (var context = new CollectFourContext())
            {
                return (from s in context.Scores orderby s.Score descending select s).Take(20).ToList();
            }
        }

        public void PrintScoreboard()
        {
            Console.WriteLine();

            foreach (var score in GetTopScores())
            {
                Console.WriteLine("{0} {1}", score.Name, score.Score);
            }

            Console.ReadLine();
        }

    }
}
