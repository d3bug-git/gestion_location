using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class PhoneNumber : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Tel { get; set; }

        public Customer Customer;
        public int CustomerID;

        public Owner Owner;
        public int OwnerID;

        public Country Country;
        public int CountryID;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
