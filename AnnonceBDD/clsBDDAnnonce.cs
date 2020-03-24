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
            #region Contraintes liées au modèle de la BDD

            #endregion

            #region Données présentes par défaut dans la BDD

            #endregion
        }
        #endregion
        
        #region Tables de la BDD
        internal DbSet<Owner> Owners { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<PhoneNumber> PhoneNumbers { get; set; }
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
            //Ajout du nouveau propriètaire
            Owner lOwner = new Owner() { FirstName = aFirstName, LastName = aLastName, eMail = aeMail, Password = aPassword, Sex = aSex, Avatar = aAvatar, Street = aStreet, StreetNumber = aStreetNumber, Town = aTown };
            Owners.Local.Add(lOwner);
            return lOwner;
        }
        internal Customer AddCustomer(string aFirstName, string aLastName, string aeMail, string aPassword, bool aSex, string aAvatar, string aStreet, string aStreetNumber, Town aTown)
        {
            //Ajout du nouveau client
            Customer lCustomer = new Customer() { FirstName = aFirstName, LastName = aLastName, eMail = aeMail, Password = aPassword, Sex = aSex, Avatar = aAvatar, Street = aStreet, StreetNumber = aStreetNumber, Town = aTown };
            Customers.Local.Add(lCustomer);
            return lCustomer;
        }
        internal PhoneNumber AddPhoneNumber(string aTel, Customer aCustomer, Owner aOwner, Country aCountry)
        {
            //Ajout du nouveau téléphone
            PhoneNumber lPhoneNumber = new PhoneNumber() { Tel = aTel, Customer = aCustomer, Owner = aOwner, Country = aCountry };
            PhoneNumbers.Local.Add(lPhoneNumber);
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
            //Ajout de la nouvelle ville
            Town lTown = new Town() { NameTown = aNameTown, PostalCode = aPostalCode, Country = aCountry };
            Towns.Local.Add(lTown);
            return lTown;
        }
        internal Advert AddAdvert(string aTitle, string aDescription, int aNbRooms, int aNbBeds, int aNbBathrooms, string aStreetNumber, string aStreet, Owner aOwner, Category aCategory)
        {
            //Ajout d'une annonce
            Advert lAdvert = new Advert() { Title = aTitle, Description = aDescription, NbRooms= aNbRooms, NbBeds= aNbBeds, NbBathrooms= aNbBathrooms, StreetNumber= aStreetNumber, Street= aStreet, Owner= aOwner, Category= aCategory };
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
            //Ajout d'une nouvelle picture
            Schedule lSchedule = new Schedule() { Price = aPrice, StartDate = aStartDate, EndDate = aEndDate, Advert = aAdvert };
            Schedules.Local.Add(lSchedule);
            return lSchedule;
        }
        internal void RemoveOwner(Owner aOwner)
        {
            //Suppression du propriètaire
            Owners.Local.Remove(aOwner);
        }
        internal void RemoveCustomer(Customer aCustomer)
        {
            //Suppression du client
            Customers.Local.Remove(aCustomer);

        }
        internal void RemovePhoneNumber(PhoneNumber aPhoneNumber)
        {
            //Suppression du téléphone
            PhoneNumbers.Local.Remove(aPhoneNumber);
        }
        internal void RemoveCountry(Country aCountry)
        {
            //Suppression du pays
            Countries.Local.Remove(aCountry);
        }
        internal void RemoveCountry(Town aTown)
        {
            //Suppression de la ville
            Towns.Local.Remove(aTown);
        }
        internal void RemoveAdvert(Advert aAdvert)
        {
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
