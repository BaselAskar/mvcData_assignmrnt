using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.ModelViews;
using mvcData_assignmrnt.Services;
using mvcData_assignmrnt.Services.Implementing;

namespace mvcData_assignmrnt.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountriesService _countriesService;

        public PeopleController(IPeopleService peopleService, ICountriesService countriesService)
        {
            _peopleService = peopleService;
            _countriesService = countriesService;
        }


        public IActionResult Index()
        {
            List<PersonView> people = _peopleService.All();
            return View(people);
        }



        public IActionResult AddPerson()
        {
            CreatePersonView personParams = new CreatePersonView();

            personParams.Countries = _countriesService.GetAll();

            return View(personParams);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreatePersonView personParams)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(personParams);
                return RedirectToAction("Index");
            }

            return View(nameof(AddPerson),personParams);
        }


        public IActionResult Details(int id)
        {
            PersonView? person = _peopleService.FindById(id);

            if (person == null)
            {
                Redirect("/Home/Error");
            }

            return View(person);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool result = _peopleService.Remove(id);

            if (!result)
            {
                return NotFound();
            }

            List<PersonView> people = _peopleService.All();

            return PartialView("_PeopleTable",people);
        }



        public IActionResult SearchById(int id)
        {
            PersonView? person = _peopleService.FindById(id);

            if (person == null )
            {
                return PartialView("_PeopleTable",new List<PersonView>());
            }

            return PartialView("_PeopleTable",new List<PersonView> { person});
        }



        public IActionResult GetAllPeople()
        {
            List<PersonView> people = _peopleService.All();

            return PartialView("_PeopleTable", people);
        }


        public IActionResult GetPeopleBy(string search, string by)
        {
            List<PersonView> result = _peopleService.Search(search, by);

            return PartialView("_PeopleTable", result);
        }
    }
}
