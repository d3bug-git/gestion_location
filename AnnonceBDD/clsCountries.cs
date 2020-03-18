using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Countries : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Prefix { get; set; }
        public string Indicatif { get; set; }
        public ObservableCollection<Towns> Towns { get; set; } = new ObservableCollection<Towns>();
        public ObservableCollection<PhoneNumbers> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumbers>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
