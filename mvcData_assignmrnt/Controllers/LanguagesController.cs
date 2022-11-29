using Microsoft.AspNetCore.Mvc;

using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Services;

namespace mvcData_assignmrnt.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            ListLanguagesView languagesView = new ListLanguagesView();
            languagesView.Languages = _languageService.GetAll();
            return View(languagesView);
        }




        [HttpPost]
        public IActionResult AddLanguage(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("You have to add the name of language..!");
            }

            _languageService.Add(name);
            List<LanguageView> languages = _languageService.GetAll();
            return PartialView("_LanguagesTable", languages);
        }



        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _languageService.Remove(id);

            var languages = _languageService.GetAll();

            return PartialView("_LanguagesTable", languages);
        }

    }
}
