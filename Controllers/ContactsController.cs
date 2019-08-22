using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private ContactsContext db = new ContactsContext();
        public ActionResult Index()
        {
            var username = Session["username"].ToString();
            var recentContacts = db.Contacts
                                   .Where (c => c.Username == username)
                                   .OrderByDescending(c => c.Id)
                                   .Take(5)
                                   .ToList();
            ViewBag.Title = "Recent Contacts";
            return View("contacts",recentContacts);
        }

        public ActionResult List()
        {
            var username = Session["username"].ToString();
            var contacts = db.Contacts
                                   .Where(c => c.Username == username)
                                   .OrderBy(c => c.Name)
                                   .ToList();
            ViewBag.Title = "All Contacts";
            return View("contacts", contacts);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Contacts/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                contact.Username = Session["username"].ToString();
                db.SaveChanges();
                if (contact.ContactPhoto != null)
                {
                    // save uploaded file 
                    var filename = "~/photos/" + contact.Id + ".jpg"; // Virtual path 
                    var pfilename = Server.MapPath(filename); // virtual path to physical path 
                    HttpContext.Trace.Write("V. Filename " + filename);
                    HttpContext.Trace.Write("P. Filename " + pfilename);
                    contact.ContactPhoto.SaveAs(pfilename); // Saving uploaded file 
                }
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                // Change state of object to Modified so that it is sent to DB
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                if (contact.ContactPhoto != null)
                {
                    // save uploaded file 
                    var filename = "~/photos/" + contact.Id + ".jpg"; // Virtual path 
                    var pfilename = Server.MapPath(filename); // virtual path to physical path 
                    HttpContext.Trace.Write("V. Filename " + filename);
                    HttpContext.Trace.Write("P. Filename " + pfilename);
                    contact.ContactPhoto.SaveAs(pfilename); // Saving uploaded file 
                }
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchContacts(string pattern)
        {
            var username = Session["username"].ToString();
            var selectedContacts = db.Contacts
                                   .Where(c => c.Username == username  && c.Name.Contains(pattern))  
                                   .ToList();
            ViewBag.Title = "";
            return PartialView("SearchContacts", selectedContacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
