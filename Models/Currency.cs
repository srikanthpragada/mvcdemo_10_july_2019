using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Currency
    {
        public static double USD_TO_INR = 70.50;
        [Range(1000,Double.MaxValue, ErrorMessage ="Minimum value is 1000")]
        public double Inr { get; set; }
        public double Usd { get; set; }
    }
}