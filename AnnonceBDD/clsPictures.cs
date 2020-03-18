using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
   public class Pictures : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string path { get; set; }

        public int AdvertID { get; set; }
        public Adverts Advert { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
