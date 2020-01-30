using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {

        private ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;

        }
        public void WriteToFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Title = "Gem textfil";
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;
            if(fileDialog.ShowDialog() == true)
            {

                foreach(Employee repositoryEmployee in viewModel.Employees)
                {
                    Repository.employees.Add(repositoryEmployee);
                    string currentEmployee = $"{repositoryEmployee.FirstName}, {repositoryEmployee.LastName}, {repositoryEmployee.Position}, {repositoryEmployee.HireDate.ToShortDateString()}, {repositoryEmployee.YearlySalary}";
                    File.AppendAllLines(fileDialog.FileName, new string[]
                   {
                     currentEmployee
               });
                }
            }
        }


        public void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = listView_employees.SelectedItem as Employee;
            viewModel.SelectedEmployee = selectedEmployee;
        }


        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile();
        }

    }
}

