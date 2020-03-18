using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Owners : INotifyPropertyChanged
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

        public Towns Town;
        public int TownID;

        public ObservableCollection<PhoneNumbers> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumbers>();
        public string CompleteName => $"{FirstName} {LastName}";
        public string Resume => $"{CompleteName}";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
