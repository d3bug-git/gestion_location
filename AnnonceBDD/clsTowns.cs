using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Towns : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string NameTown { get; set; }
        public string PostalCode { get; set; }

        public Countries Country;
        public int CountryID;

        public ObservableCollection<Customers> Costumers { get; set; } = new ObservableCollection<Customers>();
        public ObservableCollection<Owners> Owners { get; set; } = new ObservableCollection<Owners>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
