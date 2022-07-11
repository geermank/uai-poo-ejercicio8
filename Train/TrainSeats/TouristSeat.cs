using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    public class TouristSeat : TrainSeat
    {
        public TouristSeat(int number) : base(number)
        {
            // empty
        }

        public override float CalculatePrice(float basePrice)
        {
            return basePrice;
        }
    }
}