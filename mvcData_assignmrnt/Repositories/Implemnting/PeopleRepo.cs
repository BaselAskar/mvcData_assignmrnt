using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Data;

namespace mvcData_assignmrnt.Repositories.Implemting
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly MemoryData _data;

        public PeopleRepo()
        {
            _data = new MemoryData();
        }

        public Person AddPerson(Person person)
        {
            person.Id = IdCounters.NextPersonId;
            _data.People.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            _data.People.Remove(person);
        }

        public Person? FindById(int id)
        {
            return _data.People.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetAll()
        {
            return _data.People;
        }

        public Person? UpdatePerson(Person person)
        {
            Person? selectedPerson = FindById(person.Id);

            if (selectedPerson != null)
            {
                selectedPerson.FirstName = person.FirstName;
                selectedPerson.LastName = person.LastName;
                selectedPerson.Age = person.Age;
                selectedPerson.City = person.City;

            }

            return selectedPerson;

        }
    }
}
