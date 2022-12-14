using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.Constants;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Services;

namespace mvcData_assignmrnt.Controllers
{
    [Authorize(Roles = $"{Roles.SuperAdmin},{Roles.Admin}")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public IActionResult Index()
        {
            var result = _countriesService.GetAll();
            return View(result);
        }



        public IActionResult Create()
        {
            return View(new CreateCountryView());
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCountryView createCountryView)
        {

            bool validCities = createCountryView.Cities == null || createCountryView.Cities.Length == 0;

            if (!ModelState.IsValid || validCities)
            {
                if (validCities)
                {
                    ModelState.AddModelError("citiesNames", "You have to add the cities");
                }

                return View(createCountryView);
               
            }


            _countriesService.Add(createCountryView);

            return RedirectToAction(nameof(Index));
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var resutl = _countriesService.Delete(id);

            if (!resutl)
            {
                return NotFound();
            }

            List<CountryView> countries = _countriesService.GetAll();

            return PartialView("_CountriesTable", countries);
        }
    }
}
