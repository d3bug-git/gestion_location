using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class PhoneNumberOwner : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private string _Tel { get; set; }
        public string Tel
        {
            get => _Tel; set
            {
                if (value == null ||value=="")
                {
                    throw new ArgumentNullException($"{nameof(Tel)} : Le numéro de téléphone (valeur NULL ou chaine vide).");
                }
                _Tel = value;
            }
        }

        private Owner _Owner { get; set; }
        public Owner Owner
        {
            get => _Owner; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Owner)} : Le numéro de téléphone doit être liée à une Propriétaire  (valeur NULL).");
                }
                _Owner = value;
            }
        }
        public int OwnerID { get; set; }

        private Country _Country { get; set; }
        public Country Country
        {
            get => _Country; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Country)} : Le numéro de téléphone doit être liée à un pays  (valeur NULL).");
                }
                _Country = value;
            }
        }
        public int CountryID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
