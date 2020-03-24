using System;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
    public class BDDSingleton
    {

        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        public static BDDSingleton Instance { get; set; } = new BDDSingleton();
        private BDDAnnonce BDD { get; set; }
        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion
        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        private ReadOnlyObservableCollection<Owner> _Owners;
        private ReadOnlyObservableCollection<Customer> _Customers;
        private ReadOnlyObservableCollection<PhoneNumber> _PhoneNumbers;
        private ReadOnlyObservableCollection<Country> _Countries;
        private ReadOnlyObservableCollection<Town> _Towns;
        private ReadOnlyObservableCollection<Advert> _Adverts;
        private ReadOnlyObservableCollection<Book> _Books;
        private ReadOnlyObservableCollection<Picture> _Pictures;
        private ReadOnlyObservableCollection<Category> _Categories;
        private ReadOnlyObservableCollection<Schedule> _Schedules;
        public ReadOnlyObservableCollection<Owner> Owners => _Owners;
        public ReadOnlyObservableCollection<Customer> Customers => _Customers;
        public ReadOnlyObservableCollection<PhoneNumber> PhoneNumbers => _PhoneNumbers;
        public ReadOnlyObservableCollection<Country> Countries => _Countries;
        public ReadOnlyObservableCollection<Town> Towns => _Towns;
        public ReadOnlyObservableCollection<Advert> Adverts => _Adverts;
        public ReadOnlyObservableCollection<Book> Books => _Books;
        public ReadOnlyObservableCollection<Picture> Pictures => _Pictures;
        public ReadOnlyObservableCollection<Category> Categories =>_Categories;
        public ReadOnlyObservableCollection<Schedule> Schedules => _Schedules;
        #endregion

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new BDDAnnonce();
            BDD.Database.EnsureCreated();
        }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
