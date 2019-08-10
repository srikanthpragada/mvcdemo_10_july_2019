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

    }
}