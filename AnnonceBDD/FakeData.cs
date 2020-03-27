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
                .RuleFor(c => c.Indicatif, f => f.Address.CountryCode());

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
    }
}
