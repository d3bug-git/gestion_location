using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Towns : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string NameTown { get; set; }
        public string PostalCode { get; set; }

        public ObservableCollection<Adverts> Adverts { get; set; } = new ObservableCollection<Adverts>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
