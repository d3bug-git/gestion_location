using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnnonceBDD
{
    public class Adverts : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NbRooms { get; set; }
        public int NbBeds { get; set; }
        public int NbBathrooms { get; set; }
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
