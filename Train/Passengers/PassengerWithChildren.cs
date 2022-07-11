using System.Collections.Generic;

namespace Train.Passengers
{
    public class PassengerWithChildren : Passenger
    {
        private List<Passenger> underThreeYearsChildren;

        public PassengerWithChildren(int dni,
                                     string firstName, 
                                     string lastName, 
                                     List<Passenger> passengers) : base(dni, firstName, lastName)
        {
            this.underThreeYearsChildren = passengers;
        }

        public List<Passenger> UnderThreeYearsChildren
        {
            get { return underThreeYearsChildren; }
        }
    }
}
