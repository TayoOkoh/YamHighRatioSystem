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
    public class LocationController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /Location/
        public ActionResult Index()
        {
            return View(db.tblLocations.ToList());
        }

        // GET: /Location/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tbllocation = db.tblLocations.Find(id);
            if (tbllocation == null)
            {
                return HttpNotFound();
            }
            return View(tbllocation);
        }

        // GET: /Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="locId,name,locNumber,source,description,createdBy,createdDate,updatedBy,updatedDate")] tblLocation tbllocation)
        {
            if (ModelState.IsValid)
            {
                db.tblLocations.Add(tbllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbllocation);
        }

        // GET: /Location/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tbllocation = db.tblLocations.Find(id);
            if (tbllocation == null)
            {
                return HttpNotFound();
            }
            return View(tbllocation);
        }

        // POST: /Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="locId,name,locNumber,source,description,createdBy,createdDate,updatedBy,updatedDate")] tblLocation tbllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbllocation);
        }

        // GET: /Location/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tbllocation = db.tblLocations.Find(id);
            if (tbllocation == null)
            {
                return HttpNotFound();
            }
            return View(tbllocation);
        }

        // POST: /Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblLocation tbllocation = db.tblLocations.Find(id);
            db.tblLocations.Remove(tbllocation);
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
