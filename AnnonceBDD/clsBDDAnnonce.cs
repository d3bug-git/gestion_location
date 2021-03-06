﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace AnnonceBDD
{
    internal class BDDAnnonce : DbContext
    {
        #region Méthodes d'initialisation de la base de données
        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Bibliotheque;Integrated Security=true");
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDAnnonce.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FakeData FakeData = new FakeData();

            #region Contraintes liées au modèle de la BDD
            modelBuilder.Entity<Book>().HasKey(sc => new { sc.AdvertID, sc.CustomerID });
            #endregion

            #region Données présentes par défaut dans la BDD
            modelBuilder.Entity<Category>().HasData(FakeData.Category(3));
            modelBuilder.Entity<Country>().HasData(FakeData.Country(3));
            modelBuilder.Entity<Picture>().HasData( FakeData.Picture(1,3).Concat(FakeData.Picture(2, 3)) );
            modelBuilder.Entity<Advert>().HasData(FakeData.Advert(1, 1,1,3).Concat(FakeData.Advert(2, 1, 1,5)) );
            modelBuilder.Entity<Town>().HasData(FakeData.Town(1, 3).Concat(FakeData.Town(2, 3)));
            modelBuilder.Entity<PhoneNumberCustomer>().HasData(FakeData.PhoneNumberCustomer(1, 1).Concat(FakeData.PhoneNumberCustomer(2, 2)));
            modelBuilder.Entity<PhoneNumberOwner>().HasData(FakeData.PhoneNumberOwner(1, 1).Concat(FakeData.PhoneNumberOwner(2, 2)));
            modelBuilder.Entity<Owner>().HasData(FakeData.Owner(1, 3).Concat(FakeData.Owner(2, 3)));
            modelBuilder.Entity<Customer>().HasData(FakeData.Customer(1, 3).Concat(FakeData.Customer(2, 3)));
            modelBuilder.Entity<Schedule>().HasData(FakeData.Schedule(1, 3).Concat(FakeData.Schedule(2, 3)));
            modelBuilder.Entity<Book>().HasData(FakeData.Book(1,1,1).Concat(FakeData.Book(2,1, 1)).Concat(FakeData.Book(3, 1, 1)));
            #endregion
        }
        #endregion

        #region Tables de la BDD
        internal DbSet<Owner> Owners { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<PhoneNumberCustomer> PhoneNumberCustomers { get; set; }
        internal DbSet<PhoneNumberOwner> PhoneNumberOwners { get; set; }
        internal DbSet<Country> Countries { get; set; }
        internal DbSet<Town> Towns { get; set; }
        internal DbSet<Advert> Adverts { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<Picture> Pictures { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<Schedule> Schedules { get; set; }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Owner AddOwner(string aFirstName, string aLastName, string aeMail, string aPassword, bool aSex, string aAvatar, string aStreet, string aStreetNumber, Town aTown)
        {
            //Gestion des erreurs

            //Ajout du nouveau propriètaire
            Owner lOwner = new Owner() { FirstName = aFirstName, LastName = aLastName, Email = aeMail, Password = aPassword, Sex = aSex, Avatar = aAvatar, Street = aStreet, StreetNumber = aStreetNumber, Town = aTown };
            Owners.Local.Add(lOwner);
            return lOwner;
        }
        internal Customer AddCustomer(string aFirstName, string aLastName, string aeMail, string aPassword, bool aSex, string aAvatar, string aStreet, string aStreetNumber, Town aTown)
        {
            //Gestion des erreurs

            //Ajout du nouveau client
            Customer lCustomer = new Customer() { FirstName = aFirstName, LastName = aLastName, Email = aeMail, Password = aPassword, Sex = aSex, Avatar = aAvatar, Street = aStreet, StreetNumber = aStreetNumber, Town = aTown };
            Customers.Local.Add(lCustomer);
            return lCustomer;
        }
        internal PhoneNumberCustomer AddPhoneNumberCustomer(string aTel, Customer aCustomer, Country aCountry)
        {
            //Gestion des erreurs

            //Ajout du nouveau téléphone
            PhoneNumberCustomer lPhoneNumber = new PhoneNumberCustomer() { Tel = aTel, Customer = aCustomer, Country = aCountry };
            PhoneNumberCustomers.Local.Add(lPhoneNumber);
            return lPhoneNumber;
        }
        internal PhoneNumberOwner AddPhoneNumberOwner(string aTel, Owner aOwner, Country aCountry)
        {
            //Gestion des erreurs

            //Ajout du nouveau téléphone
            PhoneNumberOwner lPhoneNumber = new PhoneNumberOwner() { Tel = aTel, Owner = aOwner, Country = aCountry };
            PhoneNumberOwners.Local.Add(lPhoneNumber);
            return lPhoneNumber;
        }
        internal Country AddCountry(string aNameCountry, string aPrefix, string aIndicatif)
        {
            //Ajout du nouveau pays
            Country lCountry = new Country() { NameCountry = aNameCountry, Prefix = aPrefix, Indicatif = aIndicatif };
            Countries.Local.Add(lCountry);
            return lCountry;
        }
        internal Town AddTown(string aNameTown, string aPostalCode, Country aCountry)
        {
            if (aCountry == null) { throw new ArgumentNullException($"{nameof(AddTown)} : La ville doit être associée à un pays (valeur NULL)."); }

            //Ajout de la nouvelle ville
            Town lTown = new Town() { NameTown = aNameTown, PostalCode = aPostalCode, Country = aCountry };
            Towns.Local.Add(lTown);
            return lTown;
        }
        internal Advert AddAdvert(string aTitle, string aDescription, int aNbRooms, int aNbBeds, int aNbBathrooms, string aStreetNumber, string aStreet, Owner aOwner, Category aCategory, Town aTown)
        {
            //Gestion des erreurs
           
            //Ajout d'une annonce
            Advert lAdvert = new Advert() { Title = aTitle, Description = aDescription, NbRooms= aNbRooms, NbBeds= aNbBeds, NbBathrooms= aNbBathrooms, StreetNumber= aStreetNumber, Street= aStreet, Owner= aOwner, Category= aCategory, Town = aTown };
            Adverts.Local.Add(lAdvert);
            return lAdvert;
        }
        internal Book AddBook(Advert aAdvert, Customer aCustomer, DateTime aDateArrival, DateTime aDateDeparture, int aNbAdults, int aNbChildren, string aMessage)
        {
            //Ajout de la nouvelle ville
            Book lBook = new Book() { Advert= aAdvert, Customer= aCustomer , DateArrival = aDateArrival, DateDeparture= aDateDeparture, NbAdults= aNbAdults, NbChildren= aNbChildren, Message= aMessage };
            Books.Local.Add(lBook);
            return lBook;
        }
        internal Picture AddPicture(string aPath, Advert aAdvert)
        {
            if (aAdvert == null) { throw new ArgumentNullException($"{nameof(AddPicture)} : L'image doit être associée à une annonce (valeur NULL)."); }

            //Ajout d'une nouvelle picture
            Picture lPicture = new Picture() { Path= aPath, Advert = aAdvert };
            Pictures.Local.Add(lPicture);
            return lPicture;
        }
        internal Category AddCategory(string aTitle, string aDescription, string aAvatar)
        {
            //Ajout d'une nouvelle picture
            Category lCategory = new Category() { Title= aTitle, Description = aDescription, Avatar = aAvatar };
            Categories.Local.Add(lCategory);
            return lCategory;
        }
        internal Schedule AddSchedule(float aPrice, DateTime aStartDate, DateTime aEndDate, Advert aAdvert)
        {
            if (aAdvert == null) { throw new ArgumentNullException($"{nameof(AddPicture)} : Le calendrier de prix doit être associé à une annonce (valeur NULL)."); }
            if (aStartDate < DateTime.Now)
            {
                throw new ArgumentException($"{nameof(AddSchedule)} : La date de début doit être égale ou postérieure à la date du jour.");
            }
            if (aEndDate < DateTime.Now)
            {
                throw new ArgumentException($"{nameof(AddSchedule)} : La date de fin doit être égale ou postérieure à la date du jour.");
            }

            //Ajout d'une nouvelle picture
            Schedule lSchedule = new Schedule() { Price = aPrice, StartDate = aStartDate, EndDate = aEndDate, Advert = aAdvert };
            Schedules.Local.Add(lSchedule);
            return lSchedule;
        }
        internal void RemoveOwner(Owner aOwner)
        {
            if ((aOwner.PhoneNumbers?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveOwner)} : Il faut d'abord supprimer les numéros de téléphones du propriétaire."); }
            if ((aOwner.Adverts?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveOwner)} : Il faut d'abord supprimer les annonces du propriétaire."); }

            //Suppression du propriètaire
            Owners.Local.Remove(aOwner);
        }
        internal void RemoveCustomer(Customer aCustomer)
        {
            if ((aCustomer.PhoneNumbers?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveCustomer)} : Il faut d'abord supprimer les numéros de téléphones du client."); }
            if ((aCustomer.Books?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveCustomer)} : Il faut d'abord supprimer les réservations au nom de ce client."); }

            //Suppression du client
            Customers.Local.Remove(aCustomer);

        }
        internal void RemovePhoneNumberCustomer(PhoneNumberCustomer aPhoneNumberCustomer)
        {
            //Suppression du téléphone
            PhoneNumberCustomers.Local.Remove(aPhoneNumberCustomer);
        }
        internal void RemovePhoneNumberOwner(PhoneNumberOwner aPhoneNumberOwner)
        {
            //Suppression du téléphone
            PhoneNumberOwners.Local.Remove(aPhoneNumberOwner);
        }
        internal void RemoveCountry(Country aCountry)
        {
            if ((aCountry.Towns?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveCountry)} : Il faut d'abord supprimer les villes associées à ce pays."); }
            if ((aCountry.PhoneNumbers?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveCountry)} : Il faut d'abord supprimer les numéros de téléphone associés à ce pays."); }
            //Suppression du pays
            Countries.Local.Remove(aCountry);
        }
        internal void RemoveTown(Town aTown)
        {
            if ((aTown.Customers?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveTown)} : Il faut d'abord supprimer les clients habitant la ville."); }
            if ((aTown.Owners?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveTown)} : Il faut d'abord supprimer les propriétaires habitant la ville."); }
            if ((aTown.Adverts?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveTown)} : Il faut d'abord supprimer les annonces dont le bien immobilier est situé dans cette ville."); }

            //Suppression de la ville
            Towns.Local.Remove(aTown);
        }
        internal void RemoveAdvert(Advert aAdvert)
        {
            if ((aAdvert.Books?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveAdvert)} : Il faut d'abord supprimer les réservations associées à cette annonce."); }
            //if ((aAdvert.Schedules?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveAdvert)} : Il faut d'abord supprimer les calendriers de prix associés à cette annonce."); }
            //if ((aAdvert.Pictures?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveAdvert)} : Il faut d'abord supprimer les photos associées à cette annonce."); }
            
            //Suppression d'une annonce
            Adverts.Local.Remove(aAdvert);
        }
        internal void RemoveBook(Book aBook)
        {
            //Suppression d'une reservation
            Books.Local.Remove(aBook);
        }
        internal void RemovePicture(Picture aPicture)
        {
            //Suppression d'une picture
            Pictures.Local.Remove(aPicture);
        }
        internal void RemoveCategory(Category aCategory)
        {
            if ((aCategory.Adverts?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(RemoveCategory)} : Il faut d'abord supprimer les annonces associées à cette catégorie."); }
            //Suppression d'une categorie
            Categories.Local.Remove(aCategory);
        }
        internal void RemoveSchedule(Schedule aSchedule)
        {
            //Suppression d'un planning
            Schedules.Local.Remove(aSchedule);
        }
        #endregion 
    }
}
