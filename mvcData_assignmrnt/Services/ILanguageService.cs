using mvcData_assignmrnt.ModelViews;

namespace mvcData_assignmrnt.Services
{
    public interface ILanguageService
    {
        LanguageView Add(string languageName);
        List<LanguageView> GetAll();
        void Remove(int languageId);
    }
}
