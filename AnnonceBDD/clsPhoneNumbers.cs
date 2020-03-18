using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class clsPhoneNumbers : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Tel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
