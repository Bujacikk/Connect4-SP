using CollectFour;
using System;

using System.Collections.Generic;
using System.Text;

namespace CollectFourCore
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        public String PlayerName { get; set; }
        public String Commentary { get; set; }

        public Comment(String playerName, String comment)
        {
            Id = Id;
            PlayerName = playerName;
            Commentary = comment;
        }
        public Comment()
        {
            Id = Id;
            PlayerName = PlayerName;
            Commentary = Commentary;
        }

    }
}
