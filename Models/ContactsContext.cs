using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext()
            : base(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=msdb;Integrated Security=True")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}