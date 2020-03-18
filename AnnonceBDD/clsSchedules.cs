using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD 
{
    public class Schedules : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public float price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;

}
}
