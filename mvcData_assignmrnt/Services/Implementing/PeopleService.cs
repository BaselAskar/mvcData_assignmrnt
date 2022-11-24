using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemting;

namespace mvcData_assignmrnt.Services.Implementing
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICitiesReop _citiesRepo;
        public PeopleService(IPeopleRepo peopleRepo, ICitiesReop citiesRepo)
        {
            _peopleRepo = peopleRepo;
            _citiesRepo = citiesRepo;
        }
        public Person Add(CreatePersonView createPersonView)
        {
            if (createPersonView == null)
            {
                throw new ArgumentException("You have to add arguments....");
            }

            if (createPersonView.CityName == null)
            {
                throw new ArgumentException("You have to provide city name");
            }

            City? city = _citiesRepo.FindByName(createPersonView.CityName);

            Person person = new Person
            {
                Name= createPersonView.Name,
                PhoneNumber= createPersonView.PhoneNumber,
                City= city,
            };

            return _peopleRepo.AddPerson(person);
        }

        public bool Remove(int id)
        {
            Person? person = FindById(id);

            if (person == null)
            {
                throw new Exception("The person is not found.....!");
            }

            return _peopleRepo.Delete(person);
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
                return people.Where(p => p.City!.Name!.ToLower().Contains(search.ToLower())).ToList();
            }

            return people.Where(p => p.Name!.ToLower().Contains(search.ToLower())).ToList();
        }

        public Person? FindById(int id)
        {
            return _peopleRepo.ReadById(id);
        }

        public bool Edit(int id, CreatePersonView createPersonView)
        {

            if (createPersonView == null)
            {
                throw new ArgumentException("You have to add the person iformations....");
            }

            if (createPersonView.CityName== null)
            {
                throw new ArgumentException("You have to add city name");
            }

            City? city = _citiesRepo.FindByName(createPersonView.CityName);

            Person person = new Person
            {
                Id = id,
                Name = createPersonView.Name,
                PhoneNumber = createPersonView.PhoneNumber,
                City = city
            };

            return _peopleRepo.Update(person);
        }
    }
}
