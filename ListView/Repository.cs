using System;
using System.Collections.Generic;
using System.Text;

namespace ListView
{
    public class Repository
    {
        private List<Employee> employees;

        public Repository()
        {
            employees = new List<Employee>() {
                new Employee("Miles", "Teg", "Bashar", new DateTime(9243,5,14), 534939),
                new Employee("Thufir", "Hawat", "Mentat", new DateTime(8932, 2, 24), 357098),
                new Employee("Jens", "Pedersen", "Dealer", new DateTime(2019, 3, 18), 69000)

            };
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee person)
        {
            employees.Add(person);
        }
    }
}
