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

namespace WpfItemsControlOpgave01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {

        private ViewModel viewModel;
        private string buttonState;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
            ReadOnlyTextBox();
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = listBox.SelectedItem as Person;
            viewModel.SelectedPerson = selectedPerson;
        }

        private void submitPerson_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile("C:/Users/math323n/Desktop/person_database.txt");


        }
        public bool WriteToFile(string path)
        {
            bool fileExists = File.Exists(path);
            if(fileExists)
            {
                int.TryParse(phoneNumberBox.Text, out int phoneNumber);
                if(phoneNumber != 0)
                {
                    Person newPerson = new Person(firstNameBox.Text, lastNameBox.Text, emailNameBox.Text, phoneNumber);
                    viewModel.Person.Add(newPerson);
                    using(StreamWriter sr = File.AppendText(path))
                    {
                        sr.WriteLine($"{newPerson.FirstName},{newPerson.LastName},{newPerson.Email},{newPerson.PhoneNumber}");
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Telefonnummeret skal kun være tal!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void ReadOnlyTextBox()
        {
            textBlockFirstName.IsReadOnly = true;
            textBlockFirstName.BorderThickness = new System.Windows.Thickness(0);

            textBlockLastName.IsReadOnly = true;
            textBlockLastName.BorderThickness = new System.Windows.Thickness(0);

            textBlockEmail.IsReadOnly = true;
            textBlockEmail.BorderThickness = new System.Windows.Thickness(0);

            textBlockPhoneNumber.IsReadOnly = true;
            phoneNumberBox.BorderThickness = new System.Windows.Thickness(0);
        }

        private void TextBoxWriteable()
        {
            textBlockFirstName.IsReadOnly = false;
            textBlockFirstName.BorderThickness = new System.Windows.Thickness(1);

            textBlockLastName.IsReadOnly = false;
            textBlockLastName.BorderThickness = new System.Windows.Thickness(1);

            textBlockEmail.IsReadOnly = false;
            textBlockEmail.BorderThickness = new System.Windows.Thickness(1);

            textBlockPhoneNumber.IsReadOnly = false;
            phoneNumberBox.BorderThickness = new System.Windows.Thickness(1);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            // Statements for multi-functional button.
            if(buttonState == null)
            {
                buttonState = "1";

                editButton.Content = "Save";

                if(listBox.SelectedItem != null)
                {
                    TextBoxWriteable();
                }
            }
            else if(buttonState == "1")
            {
                buttonState = null;
                editButton.Content = "Edit";
                int.TryParse(textBlockPhoneNumber.Text, out int phoneNumber);

                if(viewModel.SelectedPerson != null)
                {
                    if(phoneNumber != 0)
                    {
                        Person editedPerson = new Person(
                            textBlockFirstName.Text,
                            textBlockLastName.Text,
                            textBlockEmail.Text,
                            phoneNumber);

                        viewModel.Person.Remove(viewModel.SelectedPerson);

                        viewModel.Person.Add(editedPerson);

                    }
                    else
                    {
                        MessageBox.Show("Indtast venligst et gyldigt telefonnummer", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                ReadOnlyTextBox();
            }

        }
    }
}