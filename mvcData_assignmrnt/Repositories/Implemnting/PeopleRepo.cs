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
            person.Id = MemoryData.NextPersonId;
            //_data.People.Add(person);
            //return person;
            List<Person> people = Read();
            people.Add(person);
            _data.PeopleContext = people;
            return person;
        }

        public bool Delete(int id)
        {
            List<Person> people = Read();
            Person person = people.FirstOrDefault(p => p.Id == id);
            bool result = people.Remove(person);
            if (!result)
            {
                return false;
            }

            _data.PeopleContext = people;
            return true;
        }

        public Person? ReadById(int id)
        {
            return _data.PeopleContext.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> Read()
        {
            return _data.PeopleContext;
        }

        public bool Update(Person person)
        {

            List<Person> people = Read();

            Person? selectedPerson = people.FirstOrDefault(p => p.Id == person.Id);

            if (selectedPerson != null)
            {
                selectedPerson.Name = person.Name;
                selectedPerson.PhoneNumber = person.PhoneNumber;
                selectedPerson.City = person.City;

                _data.PeopleContext = people;

                return true;
            }

            return false;
        }
    }
}
