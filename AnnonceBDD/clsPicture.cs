using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
   public class Picture : INotifyPropertyChanged
   {
        public int ID { get; set; }
        private string cPath;
        public string Path {
            get => cPath;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException($"{nameof(Path)} : Veuillez spécifiez une image (valeur NULL ou chaine vide).");
                }
                cPath = value;
            }
        }
        public int AdvertID { get; set; }
        public Advert Advert { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
