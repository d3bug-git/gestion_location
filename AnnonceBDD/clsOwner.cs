using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace AnnonceBDD
{
    public class Owner : INotifyPropertyChanged
    {
        #region Constante pour la gestion des erreurs
        private const string EMAIL_EXPRESSION = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        private const int PASSWORD_LENGTH = 8;
        private Security _security = new Security();
        #endregion

        public int ID { get; set; }
        private string _Password;
        public string Password { get=>_Password; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(Password)} : Le propriétaire doit avoir un mot de passe (valeur NULL ou mot de passe vide)."); 
                }
                if (value.Length < PASSWORD_LENGTH) { 
                    throw new ArgumentNullException($"{nameof(Password)} : Le propriétaire doit avoir un mot de passe > {PASSWORD_LENGTH} caractères"); 
                }
                _Password = this._security.GenerateHash(value);
            }
        }
        private string _FirstName;
        public string FirstName { get=>_FirstName; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(FirstName)} : Le propriétaire doit avoir un nom (valeur NULL ou chaine vide).");
                }
                _FirstName = value;
            }
        }
        private string _LastName;
        public string LastName { get=> _LastName; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(LastName)} : Le propriétaire doit avoir un prénom (valeur NULL ou chaine vide)."); 
                }
                _LastName = value;
            }
        }
        private string _Email;
        public string Email { get=>_Email; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(Email)} : Le propriétaire doit avoir une adresse email (valeur NULL ou adresse email vide).");
                }
                if (!Regex.IsMatch(value, EMAIL_EXPRESSION)) { 
                    throw new ArgumentNullException($"{nameof(Email)} : Adresse email du propriétaire invalide.");
                }
                _Email = value;
            }
        }
        public bool Sex { get; set; }
        private string _Avatar;
        public string Avatar
        {
            get => _Avatar; set
            {
                if (value == null || value == "") {
                    throw new ArgumentNullException($"{nameof(Avatar)} : Le propriétaire doit avoir un avatar (valeur NULL ou avatar vide).");
                }
                _Avatar = value;
            }
        }
        private string _Street;
        public string Street { get=>_Street; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(Street)} : Le propriétaire doit avoir une adresse (valeur NULL ou adresse vide)."); 
                }
                _Street = value;
            }
        }

        private string _StreetNumber;
        public string StreetNumber { get=>_StreetNumber; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(StreetNumber)} : Le propriétaire doit avoir un numéro de rue (valeur NULL ou numéro de rue vide).");
                }
                _StreetNumber = value;
            }        
        }

        private Town _Town;
        public Town Town { get => _Town;set
            {
                if (value == null) {
                    throw new ArgumentNullException($"{nameof(Town)} : Le propriétaire doit avoir une ville (valeur NULL ou ville vide)."); 
                }
                _Town = value;
            }
        }
        public int TownID { get; set; }

        public ObservableCollection<PhoneNumberOwner> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumberOwner>();
        public string CompleteName => $"{FirstName} {LastName}";
        public string Resume => $"{CompleteName}";

        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
