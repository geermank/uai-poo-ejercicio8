using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    public abstract class TrainSeat
    {
        private int number;

        public int Number
        {
            get { return number; }
        }

        public TrainSeat(int number)
        {
            this.number = number;
        }

        public abstract float CalculatePrice(float basePrice);
    }
}