using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Town : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string NameTown { get; set; }
        public string PostalCode { get; set; }

        public Country Country;
        public int CountryID;

        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();
        public ObservableCollection<Owner> Owners { get; set; } = new ObservableCollection<Owner>();
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
