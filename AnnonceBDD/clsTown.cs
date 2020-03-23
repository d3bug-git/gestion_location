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

        public Countries Country;
        public int CountryID;

        public ObservableCollection<Adverts> Adverts { get; set; } = new ObservableCollection<Adverts>();
        public ObservableCollection<Owners> Owners { get; set; } = new ObservableCollection<Owners>();
        public ObservableCollection<Customers> Customers { get; set; } = new ObservableCollection<Customers>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
