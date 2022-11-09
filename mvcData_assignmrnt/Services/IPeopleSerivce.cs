using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;

namespace mvcData_assignmrnt.Services
{
    public interface IPeopleSerivce
    {
        Person AddPerosn(PersonParams personParams);
        List<Person> GetPeople();
        Person? GetPersonById(int id);
        void DeletePerosn(int id);

    }
}
