using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YamHighRatioSys.Models;

namespace YamHighRatioSys.Controllers
{
    public class LocationUserController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /LocationUser/
        public ActionResult Index()
        {
            var tbllocationusers = db.tblLocationUsers.Include(t => t.tblLocation);
            return View(tbllocationusers.ToList());
        }

        // GET: /LocationUser/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationUser tbllocationuser = db.tblLocationUsers.Find(id);
            if (tbllocationuser == null)
            {
                return HttpNotFound();
            }
            return View(tbllocationuser);
        }

        // GET: /LocationUser/Create
        public ActionResult Create()
        {
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name");
            return View();
        }

        // POST: /LocationUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="locationUserId,userId,locationId,startDate,endDate,status,createdBy,createdDate,updatedBy,updatedDate")] tblLocationUser tbllocationuser)
        {
            if (ModelState.IsValid)
            {
                db.tblLocationUsers.Add(tbllocationuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tbllocationuser.locationId);
            return View(tbllocationuser);
        }

        // GET: /LocationUser/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationUser tbllocationuser = db.tblLocationUsers.Find(id);
            if (tbllocationuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tbllocationuser.locationId);
            return View(tbllocationuser);
        }

        // POST: /LocationUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="locationUserId,userId,locationId,startDate,endDate,status,createdBy,createdDate,updatedBy,updatedDate")] tblLocationUser tbllocationuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllocationuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tbllocationuser.locationId);
            return View(tbllocationuser);
        }

        // GET: /LocationUser/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationUser tbllocationuser = db.tblLocationUsers.Find(id);
            if (tbllocationuser == null)
            {
                return HttpNotFound();
            }
            return View(tbllocationuser);
        }

        // POST: /LocationUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblLocationUser tbllocationuser = db.tblLocationUsers.Find(id);
            db.tblLocationUsers.Remove(tbllocationuser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
