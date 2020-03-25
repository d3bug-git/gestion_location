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

        private int CategoryFakeID=0;
        private string[] CategoryTitle = new string[] { "Studios", "Appartements", "Maisons", "Villas", "Gîtes" };
        private  Faker<Category> CategoryFake;

        private int CountryFakeID = 0;
        private Faker<Country> CountryFake;

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
        }

        public Category[] Category(int count=1)
        {
            return CategoryFake.Generate(count).ToList().ConvertAll(i=>i).ToArray();
        }
        public Country[] Country(int count = 1)
        {
            return CountryFake.Generate(count).ToList().ConvertAll(i => i).ToArray();
        }

    }
}
