using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
