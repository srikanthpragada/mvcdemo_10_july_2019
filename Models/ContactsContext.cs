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
            Database.SetInitializer<ContactsContext>(null);
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}