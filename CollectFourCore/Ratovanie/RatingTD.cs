using CollectFourCore.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectFourCore.Ratovanie
{
    public class RatingTD : RateInterface
    {
        public void RattingAdd(Rate rate)
        {
            if (rate.Rating <= 5 && rate.Rating >= 0)
            {
            using (var context = new CollectFourContext())
                 {
                     context.Rates.Add(rate);
                     context.SaveChanges();
                 }
            }
           
        }
        public double CountRating()
        {
            IList<Rate> rates = GetRate();
            int count = rates.Count();
            int rateOfGame = 0;
            double finalRate = 0;
            foreach (Rate rate in rates)
            {
                rateOfGame = rateOfGame + rate.Rating;
                finalRate = Math.Round((double)rateOfGame / count, 2);

            }
            return finalRate;
        }

        public void PrintRating()
        {
            Console.WriteLine();
            Console.WriteLine(CountRating());
        }
        
        /*
          Console.WriteLine();
            Console.WriteLine(CountRating());
            Console.ReadLine();
         */
         
        public IList<Rate> GetRate()
        {
            using (var context = new CollectFourContext())
            {
                return (from s in context.Rates orderby s.Rating descending select s).Take(100).ToList();
            }
        }


        
    }
}
