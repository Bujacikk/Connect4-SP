using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFourCore.Ratovanie
{
    public interface RateInterface
    {
        void PrintRating();
        void RattingAdd(Rate rate);
        double CountRating();
        public IList<Rate> GetRate();
    }
}
