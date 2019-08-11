using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        Dictionary<String, String> students = new Dictionary<string, string>
        {
            { "1","Scott Guithrie" },
            { "2","Rod Jhonson" },
            { "3","Gavin King" },
            { "4","Anders Helsberg" },
            { "5","James Gosling" }
        };   


        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public string Now()
        {
            return DateTime.Now.ToString();
        }

        public string StudentName(string rollno)
        {
            return students[rollno];
        }

        public ActionResult StudentSearch(string sname)
        {
            var names = students.Values.Where(n => n.Contains(sname));
            return PartialView("StudentSearch", names);
        }


    }
}