using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.ModelViews;

namespace mvcData_assignmrnt.Services
{
    public interface ICountriesService
    {
        CountryView Add(CreateCountryView countryView);
        CountryView? FindById(int id);
        List<CountryView> GetAll();
        void Update(int id,CreateCountryView countryView);
        bool Delete(int counrtyId);

    }
}
