using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.ModelViews;

namespace mvcData_assignmrnt.Services
{
    public interface IPeopleService
    {
        PersonView Add(CreatePersonView createPersonView);
        List<PersonView> All();
        List<PersonView> Search(string search,string by);
        PersonView? FindById(int id);
        bool Edit(int id, CreatePersonView createPersonView);
        bool Remove(int id);

    }
}
