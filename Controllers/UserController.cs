using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password)
        {
            if (password == "123")
            {
                FormsAuthentication.SetAuthCookie("guest", false);
                return RedirectToAction("Add", "Books");
            }
            else
            {
                ViewBag.Message = "Invalid Password!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","User");

        }
    }
}