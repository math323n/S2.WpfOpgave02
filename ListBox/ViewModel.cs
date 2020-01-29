using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfItemsControlOpgave01
{
    public class ViewModel
    {
        private Repository repository;

        public ViewModel()
        {
            repository = new Repository();
            List<Person> persons = repository.GetAll();
            Person = new ObservableCollection<Person>(persons);
        }

        public ObservableCollection<Person> Person { get; set; }
        public Person SelectedPerson { get; set; }
    }
}