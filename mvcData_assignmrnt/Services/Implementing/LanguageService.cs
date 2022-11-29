using Microsoft.CodeAnalysis.Host;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Repositories;

namespace mvcData_assignmrnt.Services.Implementing
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public LanguageView Add(string languageName)
        {
            Language language = new Language { Name = languageName };
            language = _languageRepo.Add(language);
            return new LanguageView { Id = language.Id, Name = languageName };
        }

        public List<LanguageView> GetAll()
        {
            return _languageRepo.FindAll()
                .Select(lang => new LanguageView
                {
                    Id = lang.Id,
                    Name = lang.Name,
                }).ToList();
        }

        public void Remove(int languageId)
        {
            Language? language = _languageRepo.FinById(languageId);

            if (language == null)
            {
                throw new ArgumentException("The language has not found ....!");
            }

            bool result = _languageRepo.Delete(language);

            if (!result)
            {
                throw new Exception("Flied to remove language.. !");
            }

        }
    }
}
