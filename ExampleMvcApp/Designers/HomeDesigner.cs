using System.Web;
using System.Web.Mvc;

namespace ExampleMvcApp.Designers
{
    public class HomeDesigner : Controller
    {
        //
        // GET: /HomeDesigner/

        public ActionResult Index()
        {
            ViewBag.Title = "Page title";
            return View();
        }

        public ActionResult IndexAuth()
        {
            return View("Index");
        }
    }
}
