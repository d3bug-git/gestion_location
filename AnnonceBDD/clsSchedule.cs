using System;
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
        public DateTime StartDate { get; set; }        
        public DateTime EndDate { get; set; }
        public int AdvertID { get; set; }
        public Advert Advert { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

