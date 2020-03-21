using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Owner : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string eMail { get; set; }
        public bool Sex { get; set; }
        public string Avatar { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public Town Town;
        public int TownID;

        public ObservableCollection<PhoneNumber> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumber>();
        public string CompleteName => $"{FirstName} {LastName}";
        public string Resume => $"{CompleteName}";

        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
