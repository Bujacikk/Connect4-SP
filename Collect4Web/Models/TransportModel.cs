using CollectFour;
using CollectFourCore;
using CollectFourCore.Ratovanie;
using System.Collections.Generic;

namespace Collect4Web.Models
{
    public class TransportModel
    {
        public Field MyField { get; set; }
        public string MyText { get; set; }
        public IList<Player> Score { get; set; }
        public IList<Comment> Comments { get; set; }
        public double Rate { get; set; }
        public int Diff { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }


    }
}
