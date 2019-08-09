using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvcdemo.Controllers
{
    public class CurrencyController : Controller
    {
        // Get
        public ActionResult Index()
        {
            Currency c = new Currency();
            return View(c);
        }

        // POST
        [HttpPost]
        public ActionResult Index(Currency model)
        {
            model.Usd = model.Inr / Currency.USD_TO_INR;
            return View(model);
        }
    }
}