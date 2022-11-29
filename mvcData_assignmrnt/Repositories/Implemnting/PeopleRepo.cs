using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Data;
using Microsoft.EntityFrameworkCore;

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
            var result = _context.People!.Add(person);
            _context.SaveChanges();
            return result.Entity;
        }

        public bool Delete(Person person)
        {
            _context.People!.Remove(person);

            return _context.SaveChanges() > 0;
        }

        public Person? ReadById(int id)
        {
            return _context.People!
                .Include(p => p.City)
                .ThenInclude(c => c!.Country)
                .Include(p => p.Languages)
                .SingleOrDefault(p => p.Id == id);
        }

        public List<Person> Read()
        {
            return _context.People!
                .Include(p => p.City)
                .ToList();
        }

        public bool Update(Person person)
        {
            var result = _context.People!.Update(person);

            return _context.SaveChanges() > 0;
        }
    }
}
