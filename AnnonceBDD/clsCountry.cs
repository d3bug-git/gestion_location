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
        public string cNameCountry;
        public string NameCountry
        {
            get => cNameCountry;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException($"{nameof(NameCountry)} : Le pays doit être nommé.");
                }
            }
        }

        public string Prefix { get; set; }
        public string Indicatif { get; set; }
        public ObservableCollection<Town> Towns { get; set; } = new ObservableCollection<Town>();
        public ObservableCollection<PhoneNumberCustomer> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumberCustomer>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
