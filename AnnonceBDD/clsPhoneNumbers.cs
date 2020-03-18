using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class PhoneNumbers : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Tel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
