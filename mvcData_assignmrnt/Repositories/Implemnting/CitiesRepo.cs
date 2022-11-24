using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories.Implemnting
{
    public class CitiesRepo : ICitiesReop
    {
        private readonly AppDbContext _context;

        public CitiesRepo(AppDbContext context)
        {
            _context = context;
        }

        public City Add(City city)
        {
            var result = _context.Cities!.Add(city).Entity;
            _context.SaveChanges();
            return result;
        }

        public bool Delete(City city)
        {
            _context.Cities!.Remove(city);

            return _context.SaveChanges() > 0;
        }
        public City? FindById(int id)
        {
            return _context.Cities!.Find(id);
        }

        public City? FindByName(string name)
        {
            return _context.Cities!.SingleOrDefault(c => c.Name!.ToLower() == name.ToLower());
        }

        public List<City> GetAll()
        {
            return _context.Cities!.ToList();
        }

        public City Update(City city)
        {
            var result = _context.Update<City>(city).Entity;
            _context.SaveChanges();
            return result;

        }
    }
}
