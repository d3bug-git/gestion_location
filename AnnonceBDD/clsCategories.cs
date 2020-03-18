using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnnonceBDD
{
   public class Categories : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
