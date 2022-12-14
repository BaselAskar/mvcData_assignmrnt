using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Services;
using mvcData_assignmrnt.Services.Implementing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mvcData_assignment.Services
{
    public class CountryServiceTest : IClassFixture<DatabaseFixture>
    {
        private readonly ICountriesService testObject;
        private readonly AppDbContext context;

        public CountryServiceTest(DatabaseFixture fixture)
        {
            testObject = new CountriesService(fixture.CountriesRepo);
            context = fixture.Context;
        }

        [Fact(DisplayName = "Success to add country")]
        public void AddCountry_Test()
        {
            CreateCountryView createCountry = new CreateCountryView
            {
                Name= "countryName",
                Cities= new[] {"city1","city2","city3"}
            };

            CountryView result = testObject.Add(createCountry);

            var countries = context.Countries!.FromSqlRaw("SELECT * FROM Countries").ToList();

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Id);
            Assert.Contains(countries, c => c.Name == createCountry.Name);

        }


        [Fact(DisplayName = "Add country with no city .... throw an exception")]
        public void FieldToAddcountryWithNoCity()
        {

            string exMessage = "You have to provide the cities";

            CreateCountryView createCountry = new CreateCountryView
            {
                Name = "countryName",
                Cities = new string[0]
            };

            ArgumentException ex = Assert.Throws<ArgumentException>(() => testObject.Add(createCountry));

            Assert.Contains(exMessage, ex.Message);
        }



        [Fact(DisplayName = "Success in remove country")]
        public void RemoveCountry_Test()
        {
            bool result = testObject.Delete(1);

             List<Country> countries = context.Countries!.ToList();
             List<City> cities = context.Cities!.ToList();

            Assert.True(result);
            Assert.DoesNotContain(countries,c => c.Id == 1);
            Assert.DoesNotContain(cities, city => city.Name == "Malmö");
        }
    }
}
