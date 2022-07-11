using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Utils;

namespace Train
{
    public class Trip
    {
        private static readonly int INTERMEDIATE_STATION_DISCOUNT_PERCENTAGE = 2;
        private static readonly float INTERMEDIATE_STATION_STOP_TIME_IN_HOURS = 0.16f; // 10' en 1 hr (10/60)

        private List<Station> destinations;
        private float distanceBetweenEndsInKm;
        private float fixedPrice;
        private Train train;
        private List<Ticket> soldTickets;

        public Trip(Station origin,
                    Station finalDestination,
                    List<Station> intermidiateDestinations,
                    float distanceBetweenEndsInKm,
                    float fixedPrice,
                    Train train)
        {
            destinations = new List<Station>();
            destinations.AddRange(intermidiateDestinations);
            destinations.Insert(0, origin);
            destinations.Add(finalDestination);
            this.distanceBetweenEndsInKm = distanceBetweenEndsInKm;
            this.fixedPrice = fixedPrice;
            this.train = train;
            this.soldTickets = new List<Ticket>();
        }

        public List<Ticket> SoldTickets
        {
            get
            {
                return soldTickets;
            }
        }

        public float TripCost
        {
            get
            {
                int discountPercentage = GetDiscountBasedOnIntermediateStations();
                return fixedPrice - Percentage.Calculate(fixedPrice, discountPercentage);
            }
        }

        public float TripRecaudation
        {
            get
            {
                return soldTickets.Sum(t => t.Price);
            }
        }

        public float TripDurationInHours
        {
            get
            {
                return (distanceBetweenEndsInKm / train.AverageSpeed) + 
                    (GetNumberOfIntermediateStations() * INTERMEDIATE_STATION_STOP_TIME_IN_HOURS);
            }
        }

        public List<TrainSeat> AvailableSeats
        {
            get
            {
                var soldSeats = (from ticket in soldTickets
                                 select ticket.TrainSeat).ToList();

                var availableSeats = (from seat in train.TrainSeats
                             where !soldSeats.Contains(seat)
                             select seat).ToList();
                return availableSeats;
            }
        }

        public void RegisterTicket(Ticket ticket)
        {
            soldTickets.Add(ticket);
        }

        private int GetDiscountBasedOnIntermediateStations()
        {
            return GetNumberOfIntermediateStations() * INTERMEDIATE_STATION_DISCOUNT_PERCENTAGE;
        }

        private int GetNumberOfIntermediateStations()
        {
            if (destinations.Count == 2)
            {
                // no tiene destinos intermedios, no hay descuento
                return 0;
            }
            // las estaciones intermedias van desde el index 1 al anteultimo
            List<Station> intermediateStations = destinations.GetRange(1, destinations.Count - 2);
            return intermediateStations.Count;
        }
    }
}