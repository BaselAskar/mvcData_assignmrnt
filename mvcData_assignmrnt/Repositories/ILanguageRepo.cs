using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Repositories
{
    public interface ILanguageRepo
    {
        Language Add(Language language);
        bool Update(Language language);
        Language? FinById(int id);
        Language? FindByName(string name);
        List<Language> FindAll();
        bool Delete(Language language);
    }
}
