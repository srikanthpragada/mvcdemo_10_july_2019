using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CacheController : Controller
    {  
        [OutputCache(Duration = 60, VaryByParam ="*")]
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;
            return View(now);
        }
    }
}