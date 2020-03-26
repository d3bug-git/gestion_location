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
        public string cNameTown;
        public string NameTown
        {
            get => cNameTown;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException($"{nameof(NameTown)} : La ville doit être nommée.");
                }
            }
        }
        public string cPostalCode;
        public string PostalCode
        {
            get => cPostalCode;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException($"{nameof(PostalCode)} : La ville doit avoir un code postal.");
                }
            }
        }
        public Country Country;
        public int CountryID;

        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();
        public ObservableCollection<Owner> Owners { get; set; } = new ObservableCollection<Owner>();
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
