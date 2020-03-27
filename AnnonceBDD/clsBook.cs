using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace AnnonceBDD
{
    public class Book : INotifyPropertyChanged
    {
        public readonly int MIN_ADULT = 1;
        public readonly int MIN_CHILD = 0;
        public readonly int MAX_PERSONS = 20;
        public int AdvertID { get; set; }
        public Advert Advert { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        private DateTime _DateArrival;
        public DateTime DateArrival
        {
            get => _DateArrival;
            set
            {
                if (value == null ) { throw new ArgumentNullException($"{nameof(DateArrival)} : La date d'arrivée doit être antérieure à la date de départ."); }
                _DateArrival = value;
            }
        }
        private DateTime _DateDeparture;
        public DateTime DateDeparture
        {
            get => _DateDeparture;
            set
            {
                if (value == null) { throw new ArgumentNullException($"{nameof(DateDeparture)} : La date de départ doit être postérieure à la date d'arrivée."); }
                _DateDeparture = value;
            }
        }
         
        private int _NbAdults;
        public int NbAdults
        {
            get => _NbAdults; set
            {
                if (value < MIN_ADULT)
                {
                    throw new ArgumentNullException($"{nameof(NbAdults)} : Il doit y avoir au moins {MIN_ADULT} adulte(s).");
                }
                _NbAdults = value;
            }
        }
        private int _NbChildren;
        public int NbChildren
        {
            get => _NbChildren; set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException($"{nameof(NbChildren)} : Il doit y avoir au moins {MIN_CHILD} enfant(s).");
                }
                _NbChildren = value;
            }
        }
        public string Message { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
