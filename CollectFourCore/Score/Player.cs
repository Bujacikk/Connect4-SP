using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFour
{
    [Serializable] 
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
       
        public Player(string name)
        {
            Id = Id;
            Name = name;
            Score = 1100;
        }
        public Player()
        {
            Id = Id;
            Name = Name;
            Score = 1100;
        }
        public void ScoreMinus()
        {
            Score -= 50;
        }
    }
}
