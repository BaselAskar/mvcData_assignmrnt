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
            _data.People.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {
            return _data.People.Remove(person);
        }

        public Person? ReadById(int id)
        {
            return _data.People.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> Read()
        {
            return _data.People;
        }

        public bool Update(Person person)
        {
            Person? selectedPerson = ReadById(person.Id);

            if (selectedPerson != null)
            {
                selectedPerson.Name = person.Name;
                selectedPerson.PhoneNumber = person.PhoneNumber;
                selectedPerson.City = person.City;

                return true;
            }

            return false;
        }
    }
}
