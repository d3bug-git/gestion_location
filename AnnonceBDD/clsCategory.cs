using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
   public class Category : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }

        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
