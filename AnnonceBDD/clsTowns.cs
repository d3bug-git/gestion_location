using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class clsTowns : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string NameTown { get; set; }
        public string PostalCode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
