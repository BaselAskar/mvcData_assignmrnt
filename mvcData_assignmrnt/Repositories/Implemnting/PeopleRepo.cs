using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Data;

namespace mvcData_assignmrnt.Repositories.Implemting
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly AppDbContext _context;

        public PeopleRepo(AppDbContext context)
        {
            _context = context;
        }

        public Person AddPerson(Person person)
        {
            return _context.People!.Add(person).Entity;
        }

        public bool Delete(Person person)
        {
            var result = _context.People!.Remove(person);

            return result != null;
        }

        public Person? ReadById(int id)
        {
            return _context.People!.Find(id);
        }

        public List<Person> Read()
        {
            return _context.People!.ToList();
        }

        public bool Update(Person person)
        {
            var result = _context.People!.Update(person);

            return result != null;
        }
    }
}
