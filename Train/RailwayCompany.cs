using System.Collections.Generic;
using Train.Passengers;
using System.Linq;
using System;

namespace Train
{
    public class RailwayCompany
    {
        private List<Trip> trips;
        private List<Train> trains;

        public RailwayCompany()
        {
            trips = new List<Trip>();
            trains = new List<Train>();
        }

        public List<Trip> Trips
        {
            get
            {
                return trips;
            }
        }

        public void SellTicketToRegularPassenger(string firstName, string lastName, int dni, Trip trip, TrainSeat seat)
        {
            Passenger passenger = new Passenger(dni, firstName, lastName);
            trip.RegisterTicket(new Ticket(passenger, trip, seat));
        }

        public void SellTicketToPassengerWithChildren(string firstName, 
                                                      string lastName, 
                                                      int dni, 
                                                      List<Passenger> children,
                                                      Trip trip, 
                                                      TrainSeat seat)
        {
            Passenger passenger = new PassengerWithChildren(dni, firstName, lastName, children);
            trip.RegisterTicket(new Ticket(passenger, trip, seat));
        }

        public Passenger CreateUnderagePassenger(string firstName, string lastName, int dni, bool hasParentAuthorization)
        {
            return new UnderThreeYearsPassenger(dni, firstName, lastName, hasParentAuthorization);
        }

        public float CompanyRecaudation
        {
            get
            {
                return trips.Sum(t => t.TripRecaudation);
            }
        }

        public float TouristRecaudation
        {
            get
            {
                Predicate<TrainSeat> touristSeatCheck = trainSeat => trainSeat is TouristSeat;
                return GetSeatTypeRecaudation(touristSeatCheck);
            }
        }

        public float PullmanRecaudation
        {
            get
            {
                Predicate<TrainSeat> touristSeatCheck = trainSeat => trainSeat is PullmanSeat;
                return GetSeatTypeRecaudation(touristSeatCheck);
            }
        }

        public float ExecutiveRecaudation
        {
            get
            {
                Predicate<TrainSeat> touristSeatCheck = trainSeat => trainSeat is ExecutiveSeat;
                return GetSeatTypeRecaudation(touristSeatCheck);
            }
        }

        private float GetSeatTypeRecaudation(Predicate<TrainSeat> typeCheck)
        {
            List<Ticket> soldTicktes = GetAllSoldTickets();

            var recaudation = (from t in soldTicktes
                               where typeCheck(t.TrainSeat)
                               select t.Price).ToList().Sum();
            return recaudation;
        }

        public int PassengersCount
        {
            get
            {
                List<Ticket> soldTicktes = GetAllSoldTickets();
                int passengersCount = 0;

                foreach(Ticket t in soldTicktes)
                {
                     if (t.Passenger is PassengerWithChildren)
                    {
                        passengersCount += 
                            (t.Passenger as PassengerWithChildren).UnderThreeYearsChildren.Count;
                    } else 
                    {
                        passengersCount++;
                    }
                }

                return passengersCount;
            }
        }

        private List<Ticket> GetAllSoldTickets()
        {
            List<Ticket> soldTicktes = new List<Ticket>();
            trips.ForEach(trip => soldTicktes.AddRange(trip.SoldTickets));
            return soldTicktes;
        }
    }
}