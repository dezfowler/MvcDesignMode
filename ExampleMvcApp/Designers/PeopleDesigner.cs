using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel;
using ExampleMvcApp.Models;

namespace ExampleMvcApp.Designers
{
    public class PeopleDesigner : Controller
    {
        [Description("Empty people list page")]
        public ActionResult EmptyList()
        {
            return View("Index", new List<Person>{});
        }

        [Description("People list page with 5 random people")]
        public ActionResult ListWithFivePeople()
        {
            return View("Index", new List<Person>
                                 {
                                     new Person
                                     {
                                         Name = "John Smith"
                                     },
                                     new Person
                                     {
                                         Name = "Betty Davis"
                                     },
                                     new Person
                                     {
                                         Name = "Steve Jobs"
                                     },
                                     new Person
                                     {
                                         Name = "Bill Gates"
                                     },
                                     new Person
                                     {
                                         Name = "John Carmack"
                                     },
                                 });
        }

    }
}
