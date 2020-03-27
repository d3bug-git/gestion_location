using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;


namespace AnnonceBDD
{
    class FakeData
    {
        private const int WIDTH_AVATAR = 150;
        private const int HEIGHT_AVATAR = 150;

        private const int WIDTH_PICTURE = 500;
        private const int HEIGHT_PICTURE = 500;

        private const string MOT_DE_PASSE = "Soleil";
        private Security Security = new Security();

        private int CategoryFakeID=1;
        private string[] CategoryTitle = new string[] { "Studios", "Appartements", "Maisons", "Villas", "Gîtes" };
        private  Faker<Category> CategoryFake;

        private int CountryFakeID = 1;
        private Faker<Country> CountryFake;

        private int PictureFakeID = 1;
        private Faker<Picture> PictureFake;

        private int AdvertFakeID = 1;
        private Faker<Advert> AdvertFake;

        private int TownFakeID = 1;
        private Faker<Town> TownFake;

        private int PhoneNumberCustomerFakeID = 1;
        private Faker<PhoneNumberCustomer> PhoneNumberCustomerFake;

        private int PhoneNumberOwnerFakeID = 1;
        private Faker<PhoneNumberOwner> PhoneNumberOwnerFake;

        private int OwnerFakeID = 1;
        private Faker<Owner> OwnerFake;

        private int CustomerFakeID = 1;
        private Faker<Customer> CustomerFake;

        private int ScheduleFakeID = 1;
        private Faker<Schedule> ScheduleFake;

        private int BookFakeID = 1;
        private Faker<Book> BookFake;

        public FakeData(string Locale="fr")
        {

            CategoryFake = new Faker<Category>(Locale)
                .RuleFor(c => c.ID, f => CategoryFakeID++)
                .RuleFor(c => c.Title, f =>f.PickRandom(CategoryTitle))
                .RuleFor(c=>c.Description,f=>f.Lorem.Paragraphs())
                .RuleFor(c => c.Avatar, f => f.Image.DataUri(WIDTH_AVATAR, HEIGHT_AVATAR));

            CountryFake = new Faker<Country>(Locale)
                .RuleFor(c => c.ID, f => CountryFakeID++)
                .RuleFor(c => c.NameCountry, f => f.Address.Country())
                .RuleFor(c => c.Prefix, f => f.Address.CountryCode())
                .RuleFor(c => c.Indicatif, f =>"+"+f.Random.Replace("##"));

            PictureFake = new Faker<Picture>(Locale)
                .RuleFor(c => c.ID, f => PictureFakeID++)
                .RuleFor(c => c.Path, f => f.Image.DataUri(WIDTH_PICTURE, HEIGHT_PICTURE));

            AdvertFake = new Faker<Advert>(Locale)
                .RuleFor(c => c.ID, f => AdvertFakeID++)
                .RuleFor(c => c.Title, f => f.Address.County())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraphs())
                .RuleFor(c => c.NbRooms, (f, c) => f.Random.Int(c.MIN_ELEMENT, c.MAX_ELEMENT))
                .RuleFor(c => c.NbBeds, (f,c) => f.Random.Int(c.MIN_ELEMENT, c.MAX_ELEMENT))
                .RuleFor(c => c.NbBathrooms, (f, c) => f.Random.Int(c.MIN_ELEMENT, c.MAX_ELEMENT))
                .RuleFor(c => c.StreetNumber, f => f.Address.BuildingNumber())
                .RuleFor(c => c.Street, f => f.Address.StreetAddress());

            TownFake = new Faker<Town>(Locale)
                .RuleFor(c => c.ID, f => TownFakeID++)
                .RuleFor(c => c.NameTown, f => f.Address.City())
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode());

            PhoneNumberCustomerFake = new Faker<PhoneNumberCustomer>(Locale)
                .RuleFor(c => c.ID, f => PhoneNumberCustomerFakeID++)
                .RuleFor(c => c.Tel, f => f.Phone.PhoneNumber());

            PhoneNumberOwnerFake = new Faker<PhoneNumberOwner>(Locale)
                .RuleFor(c => c.ID, f => PhoneNumberOwnerFakeID++)
                .RuleFor(c => c.Tel, f => f.Phone.PhoneNumber());

            OwnerFake = new Faker<Owner>(Locale)
                .RuleFor(c => c.ID, f => OwnerFakeID++)
                .RuleFor(c => c.Password, f => Security.GenerateHash(MOT_DE_PASSE))
                .RuleFor(c => c.FirstName, (f) => f.Name.FirstName())
                .RuleFor(c => c.LastName, (f) => f.Name.LastName())
                .RuleFor(c => c.Email, (f) => f.Internet.ExampleEmail())
                .RuleFor(c => c.Sex, (f) => f.Random.Bool())
                .RuleFor(c => c.Avatar, f => f.Image.DataUri(WIDTH_AVATAR, HEIGHT_AVATAR))
                .RuleFor(c => c.Street, f => f.Address.StreetName())
                .RuleFor(c => c.StreetNumber, f => f.Address.BuildingNumber());

            CustomerFake = new Faker<Customer>(Locale)
                .RuleFor(c => c.ID, f => OwnerFakeID++)
                .RuleFor(c => c.Password, f => Security.GenerateHash(MOT_DE_PASSE))
                .RuleFor(c => c.FirstName, (f) => f.Name.FirstName())
                .RuleFor(c => c.LastName, (f) => f.Name.LastName())
                .RuleFor(c => c.Email, (f) => f.Internet.ExampleEmail())
                .RuleFor(c => c.Sex, (f) => f.Random.Bool())
                .RuleFor(c => c.Avatar, f => f.Image.DataUri(WIDTH_AVATAR, HEIGHT_AVATAR))
                .RuleFor(c => c.Street, f => f.Address.StreetName())
                .RuleFor(c => c.StreetNumber, f => f.Address.BuildingNumber());

            ScheduleFake = new Faker<Schedule>(Locale)
                .RuleFor(c => c.ID, f => ScheduleFakeID++)
                .RuleFor(c => c.Price, f => f.Random.Float())
                .RuleFor(c => c.StartDate, f => DateTime.Now)
                .RuleFor(c => c.EndDate, f => f.Date.Future(2, DateTime.Now));

            BookFake = new Faker<Book>(Locale)
                .RuleFor(c => c.DateArrival, f => DateTime.Now)
                .RuleFor(c => c.DateDeparture, f => f.Date.Soon(5, DateTime.Now))
                .RuleFor(c => c.NbAdults, (f, c) => f.Random.Int(c.MIN_ADULT, c.MAX_PERSONS))
                .RuleFor(c => c.NbChildren, (f, c) => f.Random.Int(c.MIN_CHILD, c.MAX_PERSONS))
                .RuleFor(c => c.Message, f => f.Lorem.Paragraphs());            
        }

        public Category[] Category(int count=1)
        {
            return CategoryFake.Generate(count).ToArray();
        }
        public Country[] Country(int count = 1)
        {
            return CountryFake.Generate(count).ToArray();
        }
        public Picture[] Picture(int advertId,int count = 1)
        {
            PictureFake.RuleFor(c => c.AdvertID, f => advertId);
            return PictureFake.Generate(count).ToArray();
        }
        public Advert[] Advert(int OwnerID,int CategoryID,int TownID,  int count = 1)
        {
            AdvertFake.RuleFor(c => c.OwnerID, f => OwnerID)
                .RuleFor(c => c.CategoryID, f => CategoryID)
                .RuleFor(c => c.TownID, f => TownID);
            return AdvertFake.Generate(count).ToArray();
        }
        public Town[] Town(int CountryID, int count = 1)
        {
            TownFake.RuleFor(c => c.CountryID, f => CountryID);
            return TownFake.Generate(count).ToArray();
        }

        public PhoneNumberCustomer[] PhoneNumberCustomer(int CustomerID, int CountryID, int count = 1)
        {
            PhoneNumberCustomerFake.RuleFor(c => c.CustomerID, f => CustomerID);
            PhoneNumberCustomerFake.RuleFor(c => c.CountryID, f => CountryID);
            return PhoneNumberCustomerFake.Generate(count).ToArray();
        }

        public PhoneNumberOwner[] PhoneNumberOwner(int OwnerID, int CountryID, int count = 1)
        {
            PhoneNumberOwnerFake.RuleFor(c => c.OwnerID, f => OwnerID);
            PhoneNumberOwnerFake.RuleFor(c => c.CountryID, f => CountryID);
            return PhoneNumberOwnerFake.Generate(count).ToArray();
        }
        public Owner[] Owner(int TownID, int count = 1)
        {
            OwnerFake.RuleFor(c => c.TownID, f => TownID);
            return OwnerFake.Generate(count).ToArray();
        }
        public Customer[] Customer(int TownID, int count = 1)
        {
            CustomerFake.RuleFor(c => c.TownID, f => TownID);
            return CustomerFake.Generate(count).ToArray();
        }
        public Schedule[] Schedule(int AdvertID, int count = 1)
        {
            ScheduleFake.RuleFor(c => c.AdvertID, f => AdvertID);
            return ScheduleFake.Generate(count).ToArray();
        }
        public Book[] Book(int AdvertID, int CustomerID, int count = 1)
        {
            BookFake.RuleFor(c => c.AdvertID, f => AdvertID);
            BookFake.RuleFor(c => c.CustomerID, f => CustomerID);
            return BookFake.Generate(count).ToArray();
        }
    }
}
