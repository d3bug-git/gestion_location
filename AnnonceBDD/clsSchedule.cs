using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace AnnonceBDD
{
    public class Schedule : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private float cPrix;
        public float Price
        {
            get => cPrix;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"{nameof(Price)} : Le prix doit être suppérieur à 0.");
                }
                cPrix = value;
            }
        }
        private DateTime cStartDate;
        public DateTime StartDate
        {
            get => cStartDate;
            set
            {
                if (EndDate != null && value > EndDate)
                {
                    throw new ArgumentException($"{nameof(StartDate)} : La date de début doit être antérieure à la date de fin.");
                }
                if (value < DateTime.Now) 
                { 
                    throw new ArgumentException($"{nameof(StartDate)} : La date de début doit être égale ou postérieure à la date du jour."); 
                }
                cStartDate = value;
            }
        }
        private DateTime cEndDate;
        public DateTime EndDate
        {
            get => cEndDate;
            set
            {
                if (StartDate != null && value < StartDate)
                {
                    throw new ArgumentException($"{nameof(EndDate)} : La date de fin doit être postérieure à la date de début.");
                }
                if (value < DateTime.Now) 
                { 
                    throw new ArgumentException($"{nameof(EndDate)} : La date de fin doit être égale ou postérieure à la date du jour."); 
                }
                cEndDate = value;
            }
        }
        public int AdvertID { get; set; }
        public Advert Advert { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

