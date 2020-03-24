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

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new BDDAnnonce();
            BDD.Database.EnsureCreated();
            _Adverts = new ReadOnlyObservableCollection<Advert>(BDD?.Adverts.Local.ToObservableCollection());
            _Books = new ReadOnlyObservableCollection<Book>(BDD?.Books.Local.ToObservableCollection());
            _Pictures = new ReadOnlyObservableCollection<Picture>(BDD?.Pictures.Local.ToObservableCollection());
            _Categories = new ReadOnlyObservableCollection<Category>(BDD?.Categories.Local.ToObservableCollection());
            _Schedules = new ReadOnlyObservableCollection<Schedule>(BDD?.Schedules.Local.ToObservableCollection());
        }
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

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Advert AddAdvert(string aTitle, string aDescription, int aNbRooms, int aNbBeds, int aNbBathrooms, string aStreetNumber, string aStreet, Owner aOwner, Category aCategory)
        {
            return BDD?.AddAdvert(aTitle, aDescription, aNbRooms, aNbBeds, aNbBathrooms, aStreetNumber, aStreet, aOwner, aCategory);
        }
        public Book AddBook(Advert aAdvert, Customer aCustomer, DateTime aDateArrival, DateTime aDateDeparture, int aNbAdults, int aNbChildren, string aMessage)
        {
            return BDD?.AddBook(aAdvert, aCustomer, aDateArrival, aDateDeparture, aNbAdults, aNbChildren, aMessage);
        }
        public Picture AddPicture(string aPath, Advert aAdvert)
        {
            return BDD?.AddPicture( aPath,  aAdvert);
        }
        public Category AddCategory(string aTitle, string aDescription, string aAvatar)
        {
            return BDD?.AddCategory( aTitle,  aDescription,  aAvatar);
        }
        public Schedule AddSchedule(float aPrice, DateTime aStartDate, DateTime aEndDate, Advert aAdvert)
        {
            return BDD?.AddSchedule( aPrice,  aStartDate,  aEndDate,  aAdvert);
        }

        public void RemoveAdvert(Advert aAdvert)
        {
            BDD?.RemoveAdvert( aAdvert);
        }
        public void RemoveBook(Book aBook)
        {
            BDD?.RemoveBook(aBook);
        }
        public void RemovePicture(Picture aPicture)
        {
            BDD?.RemovePicture( aPicture);
        }
        public void RemoveCategory(Category aCategory)
        {
            BDD?.RemoveCategory(aCategory);
        }
        public void RemoveSchedule(Schedule aSchedule)
        {
            BDD?.RemoveSchedule(aSchedule);
        }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
