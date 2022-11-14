using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories
{
    public interface IPeopleRepo
    {
        Person AddPerson(Person person);
        List<Person> Read();
        Person? ReadById(int id);
        bool Update(Person person);
        bool Delete(Person person);
    }
}
