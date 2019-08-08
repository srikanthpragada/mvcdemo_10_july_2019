using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
        public string Index()
        {
            return "<h1>Hello!</h1>";
        }

        public ActionResult Wish(string name)
        {
            var hours = DateTime.Now.Hour;
            String msg = "Good Evening!";

            if (hours < 12)
                msg = "Good Morning!";
            else
                if (hours < 17)
                msg = "Good Afternoon!";

            if (name == null)    // param name is missing
                name = "Guest";

            ViewBag.Message = name + " , " + msg;

            return View();
        }

        public ActionResult Contact()
        {
            var c = new Contact
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Mobile = "3934934343"
            };

            return View(c); // Sending model to view 
        }
    }
}