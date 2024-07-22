using CollectFourCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestsForServices
{
    [TestClass]
    public class TestingRating
    {
        [TestMethod]
        public void RatingAddTestFor1Rate()
        {
            //Tabulka
            Rating rating = new Rating();
            //Komenty
            Rate rate = new Rate("Adrian", 5);

            //Pridavanie
            rating.RattingAdd(rate);

            //Podmienky
            var WhatShouldBeInTable = 1;
            var WhatIsInTable = rating.GetCommentsTable.Count();

            //Asser
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }

        [TestMethod]
        public void RatingAddTestForLotsOfRates()
        {
            //Tabulka
            Rating rating = new Rating();

            //Komenty
            Rate Adrian = new Rate("Adrian",5);
            Rate Matus = new Rate("Matus",3);
            Rate Agata = new Rate("Agata", 1);

            //Pridavanie
            rating.RattingAdd(Adrian);
            rating.RattingAdd(Matus);
            rating.RattingAdd(Agata);

            //Podmienky
            var WhatShouldBeInTable = 3;
            var WhatIsInTable = rating.GetCommentsTable.Count();

            //Assert
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }

        [TestMethod]
        public void RatingAddTestForNoRate()
        {
            //Tabulka
            Rating rating = new Rating();

            //Komenty
            //Nepridavam

            //Pridavanie
            //Nepridavam

            //Podmienky
            var WhatShouldBeInTable = 0;
            var WhatIsInTable = rating.GetCommentsTable.Count();

            //Assert
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }
        [TestMethod]
        public void TestingCountRate3()
        {
            //Tabulka
            Rating rating = new Rating();

            //Komenty
            Rate Adrian = new Rate("Adrian", 5);
            Rate Matus = new Rate("Matus", 3);
            Rate Agata = new Rate("Agata", 1);

            //Pridavanie
            rating.RattingAdd(Adrian);
            rating.RattingAdd(Matus);
            rating.RattingAdd(Agata);

            //Podmienky
            
            var WhatIExpect = 3;
            var WhatIsResult = rating.CountRating();

            //Assert
            Assert.AreEqual(WhatIExpect, WhatIsResult);
        }
        [TestMethod]
        public void TestingCountRate4()
        {
            //Tabulka
            Rating rating = new Rating();

            //Komenty
            Rate Adrian = new Rate("Adrian", 5);
            Rate Matus = new Rate("Matus", 3);
            Rate Agata = new Rate("Agata", 4);

            //Pridavanie
            rating.RattingAdd(Adrian);
            rating.RattingAdd(Matus);
            rating.RattingAdd(Agata);

            //Podmienky

            var WhatIExpect = 4;
            var WhatIsResult = rating.CountRating();

            //Assert
            Assert.AreEqual(WhatIExpect, WhatIsResult);
        }
        [TestMethod]
        public void TestingCountRateFloat()
        {
            //Tabulka
            Rating rating = new Rating();

            //Komenty
            Rate Adrian = new Rate("Adrian", 5);
            Rate Matus = new Rate("Matus", 5);
            Rate Agata = new Rate("Agata", 2);
            Rate Sandra = new Rate("Sandra", 3);

            //Pridavanie
            rating.RattingAdd(Adrian);
            rating.RattingAdd(Matus);
            rating.RattingAdd(Agata);
            rating.RattingAdd(Sandra);

            //Podmienky

            var WhatIExpect = 3.75;
            var WhatIsResult = rating.CountRating();

            //Assert
            Assert.AreEqual(WhatIExpect, WhatIsResult);
        }
    }
}
