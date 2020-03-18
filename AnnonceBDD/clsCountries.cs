using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class clsCountries : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Prefix { get; set; }
        public string Indicatif { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
