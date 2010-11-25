using System.Web.Mvc;
using ExampleMvcApp.Models;

namespace ExampleMvcApp.Designers
{
    public class AccountDesigner : Controller
    {
        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordModel());
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View(new LogOnModel());
        }

        public ActionResult Register()
        {
            return View(new RegisterModel());
        }
    }
}
