using mvcdemo.Models;
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
        private ContactsContext db = new ContactsContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string ReturnUrl)
        {
            var user = db.Users.Where(u => u.Username == username && u.Password == password)
                       .SingleOrDefault();    
            if (user != null)
            {
                Session.Add("username", user.Username); 
                FormsAuthentication.SetAuthCookie(user.Username, false);
                if (ReturnUrl == null)
                    ReturnUrl = "/Contacts";

                return Redirect(ReturnUrl);
            }
            else
            {
                ViewBag.Message = "Invalid Login. Please try again!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        public ActionResult Register()
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}