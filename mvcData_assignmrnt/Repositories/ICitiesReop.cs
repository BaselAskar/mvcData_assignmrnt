using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories
{
    public interface ICitiesReop
    {
        City Add(City city);
        List<City> GetAll();
        City? FindById(int id);
        City? FindByName(string name);
        City Update(City city);
        bool Delete(City city);
    }
}
