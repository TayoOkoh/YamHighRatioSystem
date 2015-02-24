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
    public class ActivityController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /Activity/
        public ActionResult Index()
        {
            var tblactivities = db.tblActivities.Include(t => t.tblLocation).Include(t => t.tblMediumPrepType);
            return View(tblactivities.ToList());
        }

        // GET: /Activity/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblActivity tblactivity = db.tblActivities.Find(id);
            if (tblactivity == null)
            {
                return HttpNotFound();
            }
            return View(tblactivity);
        }

        // GET: /Activity/Create
        public ActionResult Create()
        {
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name");
            ViewBag.typeId = new SelectList(db.tblMediumPrepTypes, "typeId", "typename");
            return View();
        }

        // POST: /Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="activityId,name,locationId,typeId,description,createdBy,createdDate,updatedBy,updatedDate")] tblActivity tblactivity)
        {
            if (ModelState.IsValid)
            {
                db.tblActivities.Add(tblactivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tblactivity.locationId);
            ViewBag.typeId = new SelectList(db.tblMediumPrepTypes, "typeId", "typename", tblactivity.typeId);
            return View(tblactivity);
        }

        // GET: /Activity/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblActivity tblactivity = db.tblActivities.Find(id);
            if (tblactivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tblactivity.locationId);
            ViewBag.typeId = new SelectList(db.tblMediumPrepTypes, "typeId", "typename", tblactivity.typeId);
            return View(tblactivity);
        }

        // POST: /Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="activityId,name,locationId,typeId,description,createdBy,createdDate,updatedBy,updatedDate")] tblActivity tblactivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblactivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locationId = new SelectList(db.tblLocations, "locId", "name", tblactivity.locationId);
            ViewBag.typeId = new SelectList(db.tblMediumPrepTypes, "typeId", "typename", tblactivity.typeId);
            return View(tblactivity);
        }

        // GET: /Activity/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblActivity tblactivity = db.tblActivities.Find(id);
            if (tblactivity == null)
            {
                return HttpNotFound();
            }
            return View(tblactivity);
        }

        // POST: /Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblActivity tblactivity = db.tblActivities.Find(id);
            db.tblActivities.Remove(tblactivity);
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
