﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class clsBooks : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }
        public int NbAdults { get; set; }
        public int NbChildren { get; set; }

        public string Message { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}