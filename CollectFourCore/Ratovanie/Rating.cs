using CollectFourCore.Ratovanie;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CollectFourCore
{
    public class Rating : RateInterface
    {
        List<Rate> rateTable;
        public Rating()
        {
            rateTable = new List<Rate>();
        }
        public List<Rate> GetCommentsTable
        {
            get
            { return rateTable; }
        }
        public void Serialize()
        {
            using (StreamWriter file = File.CreateText(@"C:\temp\rating.json"))
            {
                if (file == null) return;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, rateTable);
            }
        }

        public void Deserialize()
        {
            using (StreamReader file = File.OpenText(@"C:\temp\rating.json"))
            {
                if (file == null) return;
                JsonSerializer serializer = new JsonSerializer();
                rateTable = (List<Rate>)serializer.Deserialize(file, typeof(List<Rate>));
            }
        }

        public void PrintRating()       //Upravit
        {
            Console.WriteLine();
            Deserialize();
            var finalRate = CountRating();
            Console.WriteLine(finalRate);
        }
        public void RattingAdd(Rate rate)      //Upravit
        {
            GetCommentsTable.Add(rate);
            Serialize();
        }

        public double CountRating()
        {
            int count = rateTable.Count();
            int rateOfGame = 0;
            double finalRate = 0;
            foreach (Rate rate in rateTable)
            {
                rateOfGame = rateOfGame + rate.Rating;
                finalRate = Math.Round((double)rateOfGame / count, 2);

            }
            return finalRate;
        }

        public IList<Rate> GetRate()
        {
            throw new NotImplementedException();
        }
    }
   
}