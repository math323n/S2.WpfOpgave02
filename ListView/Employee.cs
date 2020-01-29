using System;
using System.Collections.Generic;
using System.Text;

namespace ListView
{
    public class Employee
    {
        // Fields
        private string firstName;
        private string lastName;
        private string position;
        private DateTime hireDate;
        private double yearlySalary;

        // Contructors
        public Employee(string firstName, string lastName, string position, DateTime hireDate, double yearlySalary)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            HireDate = hireDate;
            YearlySalary = yearlySalary;

        }

        // Properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public DateTime HireDate
        {
            get
            {
                return hireDate;
            }
            set
            {
                hireDate = value;
            }
        }
        public double YearlySalary
        {
            get
            {
                return yearlySalary;
            }
            set
            {
                yearlySalary = value;
            }
        }


        public string FullName => $"{FirstName} {LastName}";
        public string FirstNameAndPosition => $"{FirstName} {Position}";
        public string YearlySalaryEmployee => $"{YearlySalary} DKK";
    }
}
