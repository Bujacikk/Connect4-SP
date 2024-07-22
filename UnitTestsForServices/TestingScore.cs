using CollectFour;
using CollectFourCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestsForServices
{
    [TestClass]
    public class TestingScore
    {
        
        [TestMethod]
        public void ScoreAddTestFor1Score()
        {
            //Tabulka
            Scoreboard scoreboard = new Scoreboard();

            //Komenty
            Player player = new Player("Adrian");

            //Pridavanie
            scoreboard.PlayerAdd(player);

            //Podmienky
            var WhatShouldBeInTable = 1;
            var WhatIsInTable = scoreboard.GetScoreboard.Count();

            //Asser
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }
        [TestMethod]
        public void ScoreAddTestFor3Score()
        {
            //Tabulka
            Scoreboard scoreboard = new Scoreboard();

            //Komenty
            Player Adrian = new Player("Adrian");
            Player Matus = new Player("Matus");
            Player Erik = new Player("Erik");

            //Pridavanie
            scoreboard.PlayerAdd(Adrian);
            scoreboard.PlayerAdd(Matus);
            scoreboard.PlayerAdd(Erik);

            //Podmienky
            var WhatShouldBeInTable = 3;
            var WhatIsInTable = scoreboard.GetScoreboard.Count();

            //Asser
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }

        [TestMethod]
        public void ScoreAddTestForZeroScore()
        {
            //Tabulka
            Scoreboard scoreboard = new Scoreboard();

            //Komenty

            //Pridavanie

            //Podmienky
            var WhatShouldBeInTable = 0;
            var WhatIsInTable = scoreboard.GetScoreboard.Count();

            //Asser
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }
        
    }
}
