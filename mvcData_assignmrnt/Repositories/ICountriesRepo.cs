using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories
{
    public interface ICountriesRepo
    {
        Country Add(Country country);
        Country Update(Country country);
        bool Delete(Country country);
        List<Country> FindAll();
        Country? FindById(int id);

    }
}
