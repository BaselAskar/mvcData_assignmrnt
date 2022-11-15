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
        public Person Add(CreatePersonView createPersonView)
        {
            if (createPersonView == null)
            {
                throw new ArgumentException("You have to add arguments....");
            }

            Person person = new Person
            {
                Name= createPersonView.Name,
                PhoneNumber= createPersonView.PhoneNumber,
                City= createPersonView.City,
            };

            return _peopleRepo.AddPerson(person);
        }

        public bool Remove(int id)
        {
            return _peopleRepo.Delete(id);
        }

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }


        public List<Person> Search(string search, string by)
        {

            List<Person> people = All();


            if (by == "City")
            {
                return people.Where(p => p.City!.ToLower().Contains(search.ToLower())).ToList();
            }

            return people.Where(p => p.Name!.ToLower().Contains(search.ToLower())).ToList();
        }

        public Person? FindById(int id)
        {
            return _peopleRepo.ReadById(id);
        }

        public bool Edit(int id, CreatePersonView createPersonView)
        {
            Person person = new Person
            {
                Id = id,
                Name = createPersonView.Name,
                PhoneNumber = createPersonView.PhoneNumber,
                City = createPersonView.City,
            };

            return _peopleRepo.Update(person);
        }
    }
}
