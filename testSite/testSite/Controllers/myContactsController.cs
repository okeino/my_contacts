using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testSite.Models;

namespace testSite.Controllers
{
    public class myContactsController : Controller
    {
        // GET: myContacts
        mvcappdb _db = new mvcappdb();
        public ActionResult Index()
        {

            return View(_db.myContacts.ToList());
        }

        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(myContact _mycontact)
        {
            if (ModelState.IsValid)
            {
                _db.myContacts.Add( _mycontact);
                _db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(_mycontact);
        }

        public ActionResult Edit(int id=0)
        {
            myContact _mycontact = _db.myContacts.Find(id);
            if(_mycontact ==null)
            {
                return HttpNotFound();
            }

            return View(_mycontact);
        }

        [HttpPost]
        public ActionResult Edit(myContact _mycontact)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(_mycontact).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_mycontact);
        }

        public ActionResult Delete(int id=0)
        {
            myContact _mycontact = _db.myContacts.Find(id);
            if(_mycontact == null)
            {
                return HttpNotFound();
            }

            return View(_mycontact);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id=0)
        {
            myContact _mycontact = _db.myContacts.Find(id);
            _db.myContacts.Remove(_mycontact);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}