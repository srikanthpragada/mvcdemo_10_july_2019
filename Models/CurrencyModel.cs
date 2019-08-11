using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class CurrencyModel
    {
        public double Amount { get; set; }
        public double Result { get; set; }
        public int Target { get; set; }
        public List<SelectListItem> TargetCurrency;

        public CurrencyModel()
        {
            var items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "USD", Value = "0" });
            items.Add(new SelectListItem { Text = "EURO", Value = "1" });
            items.Add(new SelectListItem { Text = "AUD", Value = "2" });

            TargetCurrency = items;
        }

    }
}