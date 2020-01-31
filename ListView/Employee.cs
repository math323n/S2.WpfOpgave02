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
        private string fullName;
        private double yearlySalaryEmployee;

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
            get;
            set;
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                fullName = value;
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

        public string YearlySalaryEmployee
        {
            get
            {
               
                return $"{YearlySalary} DKK";
            }
            set
            {
                ;
            }
        }
        public string HiredEmployeeDate
        {
            get
            {
                return $"{HireDate.ToString("yyyy. MMMM, dd")}";
            }
            set
            {
                ;
            }
        }

        public string EmployeeInfo => $"{FirstName} {LastName} {Position} {HireDate} {YearlySalary}";
     
        
        
    }

}
