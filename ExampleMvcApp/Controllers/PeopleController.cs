using ExampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleMvcApp.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        public ActionResult Index()
        {
            List<Person> people = GetListOfPeopleFromDatabase();
            return View(people);
        }

        private List<Person> GetListOfPeopleFromDatabase()
        {
            return new List<Person>
                   {
                       new Person{ Name = "Runtime Person 1" },
                       new Person{ Name = "Runtime Person 2" },
                       new Person{ Name = "Runtime Person 3" },
                   };
        }
    }
}
