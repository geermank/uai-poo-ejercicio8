using System;
using System.Collections.Generic;

namespace Train
{
    public class TrainSeatGenerator
    {

        public static List<TrainSeat> GenerateTouristSeats(int firstSeat, int lastSeat)
        {
            TrainSeat seatGenerator(int number) => new TouristSeat(number);
            return GenerateSeats(firstSeat, lastSeat, seatGenerator);
        }

        public static List<TrainSeat> GeneratePullmanSeats(int firstSeat, int lastSeat)
        {
            TrainSeat seatGenerator(int number) => new PullmanSeat(number);
            return GenerateSeats(firstSeat, lastSeat, seatGenerator);
        }

        public static List<TrainSeat> GenerateExecutiveSeats(int firstSeat, int lastSeat)
        {
            TrainSeat seatGenerator(int number) => new ExecutiveSeat(number);
            return GenerateSeats(firstSeat, lastSeat, seatGenerator);
        }

        private static List<TrainSeat> GenerateSeats(int firstSeat, int lastSeat, Func<int, TrainSeat> creator)
        {
            List<TrainSeat> seats = new List<TrainSeat>();

            int currentSeat = firstSeat;
            while (currentSeat <= lastSeat)
            {
                seats.Add(creator(currentSeat));
                currentSeat++;
            }

            return seats;
        }
    }
}