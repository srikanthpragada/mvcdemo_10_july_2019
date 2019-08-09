using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Contact
    {
        private List<string> mobile = new List<string>();
        public string Name { get; set; }
        public string Email { get; set; }
        
        public List<string> Mobile
        {
            get
            {
                return mobile;
            }
        }
    }
}