using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemting;

namespace mvcData_assignmrnt.Services.Implementing
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICitiesReop _citiesRepo;
        private readonly ILanguageRepo _languageRepo;
        public PeopleService(IPeopleRepo peopleRepo, ICitiesReop citiesRepo, ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _citiesRepo = citiesRepo;
            _languageRepo = languageRepo;
        }
        public PersonView Add(CreatePersonView createPersonView)
        {
            if (createPersonView == null)
            {
                throw new ArgumentException("You have to add arguments....");
            }

            if (createPersonView.CityName == null)
            {
                throw new ArgumentException("You have to provide city name");
            }

            if (createPersonView.LangsName == null || createPersonView.LangsName.Length == 0)
            {
                throw new ArgumentException("You have to add the person's languages..!");
            }

            List<Language> languages = new List<Language>();

            foreach (string name in createPersonView.LangsName)
            {
                Language? language = _languageRepo.FindByName(name);

                if (language == null)
                {
                    throw new Exception("Field to find the language..!");
                }

                languages.Add(language);
            }

            City? city = _citiesRepo.FindByName(createPersonView.CityName);

            Person person = new Person
            {
                Name= createPersonView.Name,
                PhoneNumber= createPersonView.PhoneNumber,
                City= city,
                Languages = languages
            };

            var result = _peopleRepo.AddPerson(person);

            if (person == null)
            {
                throw new Exception("Field to add person");
            }

            return new PersonView
            {
                Id = person.Id,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City?.Name!,
                Country = person.City?.Country?.Name!
            };
        }

        public bool Remove(int id)
        {
            Person? person = _peopleRepo.ReadById(id);

            if (person == null)
            {
                throw new Exception("The person is not found.....!");
            }

            return _peopleRepo.Delete(person);
        }

        public List<PersonView> All()
        {
            return _peopleRepo.Read().Select(p => new PersonView
            {
                Id = p.Id,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                City = p.City?.Name!,
                Country = p.City?.Country?.Name!
            }).ToList();
        }


        public List<PersonView> Search(string search, string by)
        {

            List<PersonView> people = All();


            if (by == "City")
            {
                return people.Where(p => p.City!.ToLower().Contains(search.ToLower())).ToList();
            }

            return people.Where(p => p.Name!.ToLower().Contains(search.ToLower())).ToList();
        }

        public PersonView? FindById(int id)
        {
            var p = _peopleRepo.ReadById(id);

            if (p == null)
            {
                return null;
            }



            return new PersonView
            {
                Id = p.Id,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                City = p.City?.Name!,
                Country = p.City?.Country?.Name!,
                Languages = p.Languages!.Select(lang => lang.Name!).ToList()
            };
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
