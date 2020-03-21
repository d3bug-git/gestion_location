using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;

namespace AnnonceBDD
{
    public class Advert : INotifyPropertyChanged
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int NbRooms { get; set; }
        public int NbBeds { get; set; }
        public int NbBathrooms { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }

        public int OwnerID { get; set; }
        public Owner Owner { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int TownID { get; set; }
        public Town Town { get; set; }
        /// <summary>
        /// Cardinalité de type [M:N], côté N : Plusieurs books possibles par Advert.
        /// </summary>
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Schedule> Schedules { get; set; } = new ObservableCollection<Schedule>();
        public ObservableCollection<Picture> Pictures { get; set; } = new ObservableCollection<Picture>();
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
