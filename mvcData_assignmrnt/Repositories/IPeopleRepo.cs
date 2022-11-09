using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories
{
    public interface IPeopleRepo
    {
        Person AddPerson(Person person);
        List<Person> GetAll();
        Person? FindById(int id);
        Person? UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
