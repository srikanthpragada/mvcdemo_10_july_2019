using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class BooksController : Controller
    {
         
        public string Index()
        {
            return "<h1>Books List </h1>";
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
    }
}