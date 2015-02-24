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
    public class MediumPrepTypeController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /MediumPrepType/
        public ActionResult Index()
        {
            return View(db.tblMediumPrepTypes.ToList());
        }

        // GET: /MediumPrepType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMediumPrepType tblmediumpreptype = db.tblMediumPrepTypes.Find(id);
            if (tblmediumpreptype == null)
            {
                return HttpNotFound();
            }
            return View(tblmediumpreptype);
        }

        // GET: /MediumPrepType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MediumPrepType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="typeId,typename")] tblMediumPrepType tblmediumpreptype)
        {
            if (ModelState.IsValid)
            {
                db.tblMediumPrepTypes.Add(tblmediumpreptype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblmediumpreptype);
        }

        // GET: /MediumPrepType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMediumPrepType tblmediumpreptype = db.tblMediumPrepTypes.Find(id);
            if (tblmediumpreptype == null)
            {
                return HttpNotFound();
            }
            return View(tblmediumpreptype);
        }

        // POST: /MediumPrepType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="typeId,typename")] tblMediumPrepType tblmediumpreptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmediumpreptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblmediumpreptype);
        }

        // GET: /MediumPrepType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMediumPrepType tblmediumpreptype = db.tblMediumPrepTypes.Find(id);
            if (tblmediumpreptype == null)
            {
                return HttpNotFound();
            }
            return View(tblmediumpreptype);
        }

        // POST: /MediumPrepType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblMediumPrepType tblmediumpreptype = db.tblMediumPrepTypes.Find(id);
            db.tblMediumPrepTypes.Remove(tblmediumpreptype);
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
