using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    public class UnderThreeYearsPassenger : Passenger
    {
        private bool hasParentAuthorization;

        public UnderThreeYearsPassenger(int dni, 
                                        string firstName, 
                                        string lastName,
                                        bool hasParentAuthorization) : base(dni, firstName, lastName)
        {
            this.hasParentAuthorization = hasParentAuthorization;
        }

        public bool HasParentAuthorization
        {
            get { return hasParentAuthorization; }  
        }
    }
}