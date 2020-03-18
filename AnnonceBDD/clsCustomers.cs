using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Customers : INotifyPropertyChanged
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
        public string CompleteName => $"{FirstName} {LastName}";
        public string Resume => $"{CompleteName}";

        public int TownID { get; set; }
        public Towns Town { get; set; }


        public ObservableCollection<Books> Books { get; set; } = new ObservableCollection<Books>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
