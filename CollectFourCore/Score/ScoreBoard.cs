using CollectFour;
using CollectFourCore.Score;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CollectFourCore
{
    public class Scoreboard : ScoreInterface
    {
        List<Player> tabulka;
        public Scoreboard()
        {
            tabulka = new List<Player>();
        }
        public List<Player> GetScoreboard
        {
            get
            { return tabulka; }
            
        }
        public void Serialize()
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\Adrian\source\repos\score.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, tabulka);
            }
        }

        public void Deserialize()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\Adrian\source\repos\score.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                tabulka = (List<Player>)serializer.Deserialize(file, typeof(List<Player>));
            }
        }
        
        public void PrintScoreboard()
        {
            Console.WriteLine();
            Deserialize();
            var sorting = GetScoreboard.OrderByDescending(x => x.Score).ThenBy(x => x.Name);
            foreach (Player player in sorting)
            {
                Console.WriteLine(player.Name + " " + player.Score);
            }
            Console.ReadLine();
        }
        public void PlayerAdd(Player player)
        {
            GetScoreboard.Add(player);
        }

        public IList<Player> GetTopScores()
        {
            throw new NotImplementedException();
        }
    }
}
