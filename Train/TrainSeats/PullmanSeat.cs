using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Utils;

namespace Train
{
    public class PullmanSeat : TrainSeat
    {
        public static readonly int PULLMAN_COST_PERCENTAGE = 10; 

        public PullmanSeat(int number) : base(number)
        {
            // empty
        }

        public override float CalculatePrice(float basePrice)
        {
            return basePrice + Percentage.Calculate(basePrice, PULLMAN_COST_PERCENTAGE);
        }
    }
}