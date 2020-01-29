﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfItemsControlOpgave01
{
    public class Repository
    {
        public static List<Person> persons;

        public Repository()
        {
            GetPeopleFromFile("C:/Users/math323n/Desktop/person_database.txt");
        }

        public List<Person> GetAll()
        {
            return persons;
        }

        public void Add(Person person)
        {
            persons.Add(person);
        }
        public static bool GetPeopleFromFile(string path)
        {
            persons = new List<Person>();
            bool fileExists = File.Exists(path);
            if(fileExists)
            {
                using(StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    string document = "";
                    string firstName = "";
                    string lastName = "";
                    string email = "";
                    int phoneNumber = 0;
                    while((document = reader.ReadLine()) != null)
                    {
                        string[] personData = document.Split(',');
                        for(int i = 0; i < personData.Length; i += 4)
                        {
                            firstName = personData[i];
                        }
                        for(int i = 1; i < personData.Length; i += 4)
                        {
                            lastName = personData[i];
                        }
                        for(int i = 2; i < personData.Length; i += 4)
                        {
                            email = personData[i];
                        }
                        for(int i = 3; i < personData.Length; i += 4)
                        {
                            int.TryParse(personData[i], out phoneNumber);
                        }
                        Person person = new Person(firstName, lastName, email, phoneNumber);
                        persons.Add(person);
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("ADVARSEL! Kunne ikke forbinde til textfilen, tjek din sti!");
                return false;
            }
        }
    }
}