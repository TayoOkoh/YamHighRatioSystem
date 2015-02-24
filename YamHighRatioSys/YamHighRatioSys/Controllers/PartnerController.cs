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
    public class PartnerController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /Partner/
        public ActionResult Index()
        {
            return View(db.tblPartners.ToList());
        }

        // GET: /Partner/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPartner tblpartner = db.tblPartners.Find(id);
            if (tblpartner == null)
            {
                return HttpNotFound();
            }
            return View(tblpartner);
        }

        // GET: /Partner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Partner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="partnerId,name,contactAddress,phoneNumber,emailAddress,webAddress,geoLongitude,geoLatitude,createdBy,createdDate,updatedBy,updatedDate")] tblPartner tblpartner)
        {
            if (ModelState.IsValid)
            {
                db.tblPartners.Add(tblpartner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpartner);
        }

        // GET: /Partner/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPartner tblpartner = db.tblPartners.Find(id);
            if (tblpartner == null)
            {
                return HttpNotFound();
            }
            return View(tblpartner);
        }

        // POST: /Partner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="partnerId,name,contactAddress,phoneNumber,emailAddress,webAddress,geoLongitude,geoLatitude,createdBy,createdDate,updatedBy,updatedDate")] tblPartner tblpartner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpartner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpartner);
        }

        // GET: /Partner/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPartner tblpartner = db.tblPartners.Find(id);
            if (tblpartner == null)
            {
                return HttpNotFound();
            }
            return View(tblpartner);
        }

        // POST: /Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblPartner tblpartner = db.tblPartners.Find(id);
            db.tblPartners.Remove(tblpartner);
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
