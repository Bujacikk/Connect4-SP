using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFourCore
{
    [Serializable]
    public class Rate
    {
        public int Id { get; set; }
        public String PlayerName { get; set; }
        public int Rating { get; set; }

        public Rate(String playerName, int rate)
        {
            Id = Id;
            PlayerName = playerName;
            Rating = rate;
        }
        public Rate()
        {
            Id = Id;
            PlayerName = PlayerName;
            Rating = Rating;
        }


    }
}