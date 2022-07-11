using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Utils;

namespace Train
{
    public class ExecutiveSeat : TrainSeat
    {
        public static readonly int EXECUTIVE_COST_PERCENTAGE = 7;

        public ExecutiveSeat(int number) : base(number)
        {
            // empty
        }

        public override float CalculatePrice(float basePrice)
        {
            float newBase = basePrice + Percentage.Calculate(basePrice, PullmanSeat.PULLMAN_COST_PERCENTAGE);
            return newBase + Percentage.Calculate(newBase, EXECUTIVE_COST_PERCENTAGE);
        }
    }
}