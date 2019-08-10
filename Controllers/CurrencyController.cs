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
            if (ModelState.IsValid)
            {
                model.Usd = model.Inr / Currency.USD_TO_INR;
                return View(model);
            }
            else
                return View(model);
        }


        // Get
        public ActionResult Convert()
        {
            CurrencyModel c = new CurrencyModel();
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "USD", Value = "0" });
            items.Add(new SelectListItem { Text = "EURO", Value = "1" });
            items.Add(new SelectListItem { Text = "AUD", Value = "2" });

            c.TargetCurrency = items;

            return View(c);
        }

        [HttpPost]
        public ActionResult Convert(CurrencyModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Target == 0)
                    model.Result = model.Amount / 70;
                else
                    if (model.Target == 1) // EURO
                    model.Result = model.Amount / 80;
                else
                    model.Result = model.Amount / 48;

                return View(model);
            }
            else
                return View(model);
        }
    }
}