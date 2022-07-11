using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    public class Train
    {
        private List<TrainSeat> trainSeats;
        private float averageSpeed;

        public Train(List<TrainSeat> trainSeats, float averageSpeed)
        {
            this.trainSeats = trainSeats;
            this.averageSpeed = averageSpeed;
        }

        public List<TrainSeat> TrainSeats
        {
            get { return trainSeats; }
        }
        
        public float AverageSpeed
        {
            get { return averageSpeed; }
        }
    }
}