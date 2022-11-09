using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemting;

namespace mvcData_assignmrnt.Services.Implementing
{
    public class PeopleService : IPeopleSerivce
    {
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService()
        {
            _peopleRepo = new PeopleRepo();
        }
        public Person AddPerosn(PersonParams personParams)
        {
            if (personParams == null)
            {
                throw new ArgumentException("You have to add arguments....");
            }

            Person person = new Person
            {
                Id = personParams.Id,
                FirstName= personParams.FirstName,
                LastName= personParams.LastName,
                Age= personParams.Age,
                City= personParams.City,
            };

            return _peopleRepo.AddPerson(person);
        }

        public void DeletePerosn(int id)
        {
            Person? person = GetPersonById(id);

            if (person == null)
            {
                throw new Exception("The person is not found.....!");
            }

            _peopleRepo.DeletePerson(person);
        }

        public List<Person> GetPeople()
        {
            return _peopleRepo.GetAll();
        }

        public Person? GetPersonById(int id)
        {
            return _peopleRepo.FindById(id);
        }
    }
}
