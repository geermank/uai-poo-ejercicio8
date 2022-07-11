using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    public class Passenger
    {
        private int dni;
        private string firstName;
        private string lastName;

        public Passenger(int dni, string firstName, string lastName)
        {
            this.dni = dni;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Dni
        {
            get { return dni; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public String LastName
        {
            get { return lastName; }
        }
    }
}