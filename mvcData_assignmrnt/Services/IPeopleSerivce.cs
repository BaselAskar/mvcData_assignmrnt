using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;

namespace mvcData_assignmrnt.Services
{
    public interface IPeopleSerivce
    {
        Person Add(CreatePersonView createPersonView);
        List<Person> All();
        List<Person> Search(string search,string by);
        Person? FindById(int id);
        bool Edit(int id, CreatePersonView createPersonView);
        bool Remove(int id);

    }
}
