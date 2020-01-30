using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace ListView
{
    public class Repository
    {
     
        public static List<Employee> employees;

        public Repository()
        {
           employees = new List<Employee>() {
                

            };
            /*new Employee("Miles", "Teg", "Bashar", new DateTime(9243, 5, 14), 534939),
                new Employee("Thufir", "Hawat", "Mentat", new DateTime(8932, 2, 24), 357098),
                new Employee("Jens", "Pedersen", "Dealer", new DateTime(2019, 3, 18), 69000)*/
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee person)
        {
            employees.Add(person);
        }
        
        public static bool GetEmployeesFromFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            employees = new List<Employee>();
            bool doesFileExist = fileDialog.CheckFileExists;
           
            if(doesFileExist)
            {
                using(StreamReader reader = new StreamReader(fileDialog.OpenFile(), Encoding.Default))
                {
                    string document = "";
                    string firstName = "";
                    string lastName = "";
                    string position = "";
                    double yearlySalary = 0;
                    DateTime hireDate = new DateTime();
                    while((document = reader.ReadLine()) != null)
                    {
                        string[] employeeData = document.Split(',');
                        for(int i = 0; i < employeeData.Length; i += 5)
                        {
                            firstName = employeeData[i];
                        }
                        for(int i = 1; i < employeeData.Length; i += 5)
                        {
                            lastName = employeeData[i];
                        }
                        for(int i = 2; i < employeeData.Length; i += 5)
                        {
                            position = employeeData[i];
                        }
                        for(int i = 3; i < employeeData.Length; i += 5)
                        {
                            double.TryParse(employeeData[i], out yearlySalary);
                        }
                        for(int i = 4; i < employeeData.Length; i += 5)
                        {
                            DateTime.TryParse(employeeData[i], out hireDate);
                        }
                        Employee employee = new Employee(firstName, lastName, position, hireDate, yearlySalary);
                        employees.Add(employee);
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Ups, noget gik galt xD");
                Environment.Exit(0);
                return false;
            }


        }
    }
}
