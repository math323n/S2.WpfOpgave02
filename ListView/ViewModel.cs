using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ListView
{
    public class ViewModel
    {
        public Repository repository;

        public ViewModel()
        {
            repository = new Repository();

            List<Employee> employees = repository.GetAll();

            Employees = new ObservableCollection<Employee>(employees);
        }
        public void LoadFromTextFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if(openDialog.ShowDialog() == true)
            {

                string line;
                StreamReader fileRead = new StreamReader(openDialog.FileName);
                while((line = fileRead.ReadLine()) != null)
                {
                    string[] employeeData = line.Split(", ");
                    double.TryParse(employeeData[4], out double salary);
                    DateTime.TryParse(employeeData[3], out DateTime hireDate);

                    Employees.Add(new Employee(employeeData[0],
                          employeeData[1], employeeData[2], hireDate,
                         salary));


                }
            }

        }

        public ObservableCollection<Employee> Employees { get; set; }

        public Employee SelectedEmployee { get; set; }
    }
}
