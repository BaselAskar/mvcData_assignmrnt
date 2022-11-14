using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.Services.Implementing;

namespace mvcData_assignmrnt.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleService;

        public PeopleController()
        {
            _peopleService= new PeopleService();
        }


        public IActionResult Index()
        {
            List<Person> people = _peopleService.All();
            return View(people);
        }



        public IActionResult AddPerson()
        {
            CreatePersonView personParams = new CreatePersonView();

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
            Person? person = _peopleService.FindById(id);

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

            List<Person> people = _peopleService.All();

            return PartialView("_PeopleTable",people);
        }



        public IActionResult SearchById(int id)
        {
            Person? person = _peopleService.FindById(id);

            if (person == null )
            {
                return PartialView("_PeopleTable",new List<Person>());
            }

            return PartialView("_PeopleTable",new List<Person> { person});
        }



        public IActionResult GetAllPeople()
        {
            List<Person> people = _peopleService.All();

            return PartialView("_PeopleTable", people);
        }


        public IActionResult GetPeopleBy(string search, string by)
        {
            List<Person> result = _peopleService.Search(search, by);

            return PartialView("_PeopleTable", result);
        }
    }
}
