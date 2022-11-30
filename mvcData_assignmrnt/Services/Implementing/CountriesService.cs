using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Repositories;

namespace mvcData_assignmrnt.Services.Implementing
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepo _countriesRepo;

        public CountriesService(ICountriesRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        public CountryView Add(CreateCountryView countryView)
        {
            if (countryView == null)
            {
                throw new ArgumentException("You have to provide the country info..!");
            }

            if (countryView.Cities == null || countryView.Cities.Length < 1)
            {
                throw new ArgumentException("You have to provide the cities....");
            }


            List<City> cities = countryView.Cities.Select(name => new City { Name = name }).ToList();

            Country country = new Country
            {
                Name = countryView.Name,
                Cities = cities
            };

            country = _countriesRepo.Add(country);

            CountryView result = new CountryView
            {
                Id= country.Id,
                Name = countryView.Name,
                Cities = country.Cities!.Select(c => c.Name!).ToList()
            };


            return result;
        }

        public bool Delete(int counrtyId)
        {
            var country = _countriesRepo.FindById(counrtyId);

            if (country == null)
            {
                return false;
            }

            return _countriesRepo.Delete(country);
        }

        public CountryView? FindById(int id)
        {
            var country = _countriesRepo.FindById(id);

            if (country == null)
            {
                throw new ArgumentException("There is no country with this id..");
            }

            return new CountryView
            {
                Name = country!.Name,
                Cities = country.Cities.Select(c => c.Name!).ToList()
            };
        }

        public List<CountryView> GetAll()
        {
            return _countriesRepo.FindAll()
                .Select(c => new CountryView
                {
                    Id = c.Id,
                    Name = c.Name,
                    Cities = c.Cities.Select(city => city.Name!).ToList()
                }).ToList();
        }

        public void Update(int id, CreateCountryView countryView)
        {
            Country country = new Country
            {
                Id = id,
                Name = countryView.Name,
            };

            _countriesRepo.Update(country);
        }
    }
}
