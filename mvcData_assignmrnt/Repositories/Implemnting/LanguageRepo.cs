using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories.Implemnting
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly AppDbContext _context;

        public LanguageRepo(AppDbContext context)
        {
            _context = context;
        }

        public Language Add(Language language)
        {
            Language result = _context.Add(language).Entity;
            _context.SaveChanges();
            return result;
        }

        public bool Delete(Language language)
        {
            _context.Remove(language);
            return _context.SaveChanges() > 0;
        }

        public Language? FinById(int id)
        {
            return _context.Languages.Find(id);
        }

        public List<Language> FindAll()
        {
            return _context.Languages.ToList();
        }

        public Language? FindByName(string name)
        {
           return _context.Languages.SingleOrDefault(l => l.Name == name);
        }

        public bool Update(Language language)
        {
            Language? EntityLang = FinById(language.Id);
            if (EntityLang == null) 
            {
                return false;
            }

            _context.Languages.Update(language);
            return _context.SaveChanges() > 0;
        }
    }
}
