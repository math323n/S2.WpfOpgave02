using System;
using System.Collections.Generic;
using System.Text;

namespace WpfItemsControlOpgave01
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string email;
        private int phoneNumber;

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
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public Person(string firstName, string lastName, string email, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string FullName => $"{FirstName} {LastName}";

    }
}