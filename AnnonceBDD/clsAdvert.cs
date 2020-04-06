using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class Advert : INotifyPropertyChanged
    {
        public readonly int MIN_ELEMENT  = 1;
        public readonly int MAX_ELEMENT  = 7;

        public int ID { get; set; }

        private string _Title;
        public string Title { get=>_Title; set
            {
                if (value == null || value == "") {
                    throw new ArgumentNullException($"{nameof(Title)} : L'annonce  doit avoir un nom (valeur NULL ou chaine vide)."); 
                }
                _Title = value;
            }
        }
        private string _Description;
        public string Description { get=>_Description; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(Description)} L'annonce doit avoir un nom (valeur NULL ou chaine vide)."); 
                }
                _Description = value;
            }
        }
        private int _NbRooms;
        public int NbRooms { get=>_NbRooms; set
            {
                if (value < MIN_ELEMENT) { 
                    throw new ArgumentNullException($"{nameof(NbRooms)} : L'annonce doit avoir au moins {MIN_ELEMENT} pièce(s)."); 
                }
                _NbRooms = value;
            }
        }
        private int _NbBeds;
        public int NbBeds { get=>_NbBeds; set
            {
                if (value < MIN_ELEMENT) { 
                    throw new ArgumentNullException($"{nameof(NbBeds)} : L'annonce doit avoir au moins {MIN_ELEMENT} lit(s)."); 
                }
                _NbBeds = value;
            }  
        }
        private int _NbBathrooms;
        public int NbBathrooms { get=>_NbBathrooms; set
            {
                if (value < MIN_ELEMENT) {
                    throw new ArgumentNullException($"{nameof(NbBathrooms)} : L'annonce doit avoir au moins {MIN_ELEMENT} chambre(s)."); 
                }
                _NbBathrooms = value;
            }
        }
        private string _StreetNumber;
        public string StreetNumber { get=> _StreetNumber; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(StreetNumber)} : L'annonce doit avoir un numéro de rue (valeur NULL ou numéro de rue vide)."); 
                }
                _StreetNumber = value;
            }
        }
        private string _Street;
        public string Street { get=>_Street; set
            {
                if (value == null || value == "") { 
                    throw new ArgumentNullException($"{nameof(Street)} : L'annonce doit avoir une adresse (valeur NULL ou adresse vide)."); 
                }
                _Street = value;
            }
        }

        public int OwnerID { get; set; }
        private Owner _Owner;
        public Owner Owner { get=>_Owner; set
            {
                if (value == null) {
                    throw new ArgumentNullException($"{nameof(Owner)} : L'annonce doit avoir un propriétaire (valeur NULL)."); 
                }
                _Owner = value;
            }
             
        }
        
        public int CategoryID { get; set; }
        private Category _Category;
        public Category Category { get=>_Category; set
            {
                if (value == null) {
                    throw new ArgumentNullException($"{nameof(Category)} : L'annonce doit avoir une catégorie  (valeur NULL)."); 
                }
                _Category = value;
            }
        }
        public int TownID { get; set; }
        private Town _Town;
        public Town Town
        {
            get => _Town; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Town)} : L'annonce doit être liée à une ville  (valeur NULL).");
                }
                _Town = value;
            }
        }
        /// <summary>
        /// Cardinalité de type [M:N], côté N : Plusieurs books possibles par Advert.
        /// </summary>
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Schedule> Schedules { get; set; } = new ObservableCollection<Schedule>();
        public ObservableCollection<Picture> Pictures { get; set; } = new ObservableCollection<Picture>();
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
