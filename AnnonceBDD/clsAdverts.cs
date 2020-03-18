using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
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
        public string StreetNumber { get; set; }
        public string Street { get; set; }

        public int OwnerID { get; set; }
        public Owners Owner { get; set; }
        public int CategoryID { get; set; }
        public Categories Category { get; set; }
        public int TownID { get; set; }
        public Towns Town { get; set; }
        /// <summary>
        /// Cardinalité de type [M:N], côté N : Plusieurs books possibles par Advert.
        /// </summary>
        public ObservableCollection<Books> Books { get; set; } = new ObservableCollection<Books>();
        public ObservableCollection<Schedules> Schedules { get; set; } = new ObservableCollection<Schedules>();
        public ObservableCollection<Pictures> Pictures { get; set; } = new ObservableCollection<Pictures>();
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
