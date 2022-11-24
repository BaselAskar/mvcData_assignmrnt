using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories.Implemnting
{
    public class CountriesRepo : ICountriesRepo
    {
        private readonly AppDbContext _context;

        public CountriesRepo(AppDbContext context)
        {
            _context = context;
        }

        public Country Add(Country country)
        {
            var result = _context.Countries!.Add(country).Entity;
            _context.SaveChanges();
            return result;

        }

        public bool Delete(Country country)
        {
            var result = _context.Countries!.Remove(country);

            return _context.SaveChanges() > 0;
        }

        public List<Country> FindAll()
        {
            return _context.Countries!
                .Include(c => c.Cities)
                .ToList();
        }

        public Country? FindById(int id)
        {
            return _context.Countries!.Find(id);
        }

        public Country Update(Country country)
        {
            var result = _context.Countries!.Update(country).Entity;
            _context.SaveChanges();
            return result;
        }
    }
}
