using Microsoft.EntityFrameworkCore;
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
            BDD?.Adverts.Load();
            _adverts = new ReadOnlyObservableCollection<Advert>(BDD?.Adverts.Local.ToObservableCollection());
            BDD?.Books.Load();
            _Books = new ReadOnlyObservableCollection<Book>(BDD?.Books.Local.ToObservableCollection());
            BDD?.Pictures.Load();
            _pictures = new ReadOnlyObservableCollection<Picture>(BDD?.Pictures.Local.ToObservableCollection());
            BDD?.Categories.Load();
            _categories = new ReadOnlyObservableCollection<Category>(BDD?.Categories.Local.ToObservableCollection());
            BDD?.Schedules.Load();
            _schedules = new ReadOnlyObservableCollection<Schedule>(BDD?.Schedules.Local.ToObservableCollection());
        }
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        private ReadOnlyObservableCollection<Owner> _owners;
        private ReadOnlyObservableCollection<Customer> _customers;
        private ReadOnlyObservableCollection<PhoneNumber> _phoneNumbers;
        private ReadOnlyObservableCollection<Country> _countries;
        private ReadOnlyObservableCollection<Town> _towns;
        private ReadOnlyObservableCollection<Advert> _adverts;
        private ReadOnlyObservableCollection<Book> _books;
        private ReadOnlyObservableCollection<Picture> _pictures;
        private ReadOnlyObservableCollection<Category> _categories;
        private ReadOnlyObservableCollection<Schedule> _schedules;
        public ReadOnlyObservableCollection<Owner> owners => _owners;
        public ReadOnlyObservableCollection<Customer> customers => _customers;
        public ReadOnlyObservableCollection<PhoneNumber> phoneNumbers => _phoneNumbers;
        public ReadOnlyObservableCollection<Country> countries => _countries;
        public ReadOnlyObservableCollection<Town> towns => _towns;
        public ReadOnlyObservableCollection<Advert> adverts => _adverts;
        public ReadOnlyObservableCollection<Book> books => _books;
        public ReadOnlyObservableCollection<Picture> pictures => _pictures;
        public ReadOnlyObservableCollection<Category> categories =>_categories;
        public ReadOnlyObservableCollection<Schedule> schedules => _schedules;
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
