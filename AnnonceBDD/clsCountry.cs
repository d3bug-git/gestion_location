using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Country : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string NameCountry { get; set; }
        public string Prefix { get; set; }
        public string Indicatif { get; set; }
        public ObservableCollection<Town> Towns { get; set; } = new ObservableCollection<Town>();
        public ObservableCollection<PhoneNumberCustomer> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumberCustomer>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
