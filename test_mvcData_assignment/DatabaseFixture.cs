using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Repositories.Implemnting;
using mvcData_assignmrnt.Repositories.Implemting;
using mvcData_assignmrnt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mvcData_assignment
{
    public class DatabaseFixture : IDisposable
    {
        public IPeopleRepo PeopleRepo { get; private set; }
        public ICountriesRepo CountriesRepo { get; private set; }
        public ICitiesReop CitiesReop { get; private set; }
        public ILanguageRepo LanguageRepo { get; private set; }

        public AppDbContext Context { get;private set; }

        public DatabaseFixture()
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            DbContextOptions<AppDbContext> options = builder.Options;
            Context = new AppDbContext(options);

            PeopleRepo = new PeopleRepo(Context);
            CountriesRepo = new CountriesRepo(Context);
            CitiesReop = new CitiesRepo(Context);
            LanguageRepo = new LanguageRepo(Context);


            //Add Languages
            List<Language> languages = new List<Language>
            {
                new Language{Id=1,Name="English"},
                new Language {Id = 2,Name= "Swedish"},
                new Language{Id=3,Name= "Arabic"}
            };


            languages.ForEach(lang => Context.Languages!.Add(lang));

            Context.SaveChanges();

            //Add Countries
            List<Country> countries = new List<Country>
            {
                new Country{Id=1,Name = "Sweden",Cities= new List<City>
                    {
                        new City{Id = 1,Name="Malmö"},
                        new City{Id=2,Name= "Växjö"},
                        new City{Id=3,Name= "Stockholm"}
                    }
                },

                new Country{Id = 2,Name = "Germany",Cities = new List<City>
                    {
                        new City{Id = 4,Name = "Beril"},
                        new City{Id=5,Name = "Hamborg"}
                    }
                }
            };



            countries.ForEach(contry => Context.Countries!.Add(contry));
            Context.SaveChanges();


            //Add Poeple

            List<string> personLanguages1 = new List<string>
            {
                "Arabic","English"
            };


            List<string> personLanguages2 = new List<string>
            {
                "English","Swedish"
            };




            List<Person> people = new List<Person>
            {
                new Person{Id=1,Name = "Basel Askar",City = Context.Cities!.Find(1),PhoneNumber = "0729002221",Languages = personLanguages1.Select(pl => Context.Languages!.Single(lang => lang.Name == pl)).ToList()},
                new Person{Id=2,Name = "Åsa Jonsson",City = Context.Cities!.Find(2),PhoneNumber = "0796521421",Languages = personLanguages2.Select(pl => Context.Languages!.Single(lang => lang.Name == pl)).ToList()}
            };

            foreach (Person person in people) Context.People!.Add(person);

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
