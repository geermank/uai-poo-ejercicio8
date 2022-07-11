namespace Train
{
    public class Ticket
    {
        private Passenger passenger;
        private Trip trip;
        private TrainSeat seat;

        public Ticket(Passenger passenger, Trip trip, TrainSeat seat)
        {
            this.passenger = passenger;
            this.trip = trip;
            this.seat = seat;
        }

        public Passenger Passenger
        {
            get { return passenger; }
        }

        public Trip Trip
        {
            get { return trip; }
        }

        public TrainSeat TrainSeat
        {
            get { return seat; }
        }

        public float Price
        {
            get
            {
                return seat.CalculatePrice(trip.TripCost);
            }
        }
    }
}