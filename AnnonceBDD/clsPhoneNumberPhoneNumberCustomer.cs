using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnnonceBDD
{
    public class PhoneNumberCustomer : INotifyPropertyChanged
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

        private Customer _Customer;
        public Customer Customer
        {
            get => _Customer; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Customer)} : Le numéro de téléphone doit être liée à une Client  (valeur NULL).");
                }
                _Customer = value;
            }
        }
        public int CustomerID { get; set; }

        private Country _Country;
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
