using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;
using mvcData_assignmrnt.Services.Implementing;

namespace mvcData_assignmrnt.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleServic;

        public PeopleController()
        {
            _peopleServic= new PeopleService();
        }


        public IActionResult Index()
        {
            List<Person> people = _peopleServic.GetPeople();
            return View(people);
        }



        public IActionResult AddPerson()
        {
            PersonParams personParams = new PersonParams();

            return View(personParams);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PersonParams personParams)
        {
            if (ModelState.IsValid)
            {
                _peopleServic.AddPerosn(personParams);
                return RedirectToAction("Index");
            }

            return View(nameof(AddPerson),personParams);
        }


        public IActionResult Details(int id)
        {
            Person? person = _peopleServic.GetPersonById(id);

            if (person == null)
            {
                Redirect("/Home/Error");
            }

            return View(person);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _peopleServic.DeletePerosn(id);

            List<Person> people = _peopleServic.GetPeople();

            return PartialView("_PeopleTable",people);
        }
    }
}
