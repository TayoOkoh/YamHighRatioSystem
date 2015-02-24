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
    public class ReagentController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /Reagent/
        public ActionResult Index()
        {
            return View(db.tblReagents.ToList());
        }

        // GET: /Reagent/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReagent tblreagent = db.tblReagents.Find(id);
            if (tblreagent == null)
            {
                return HttpNotFound();
            }
            return View(tblreagent);
        }

        // GET: /Reagent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Reagent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="reagentId,name,uom,createdBy,craetedDate,updatedBy,updatedDate")] tblReagent tblreagent)
        {
            if (ModelState.IsValid)
            {
                db.tblReagents.Add(tblreagent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblreagent);
        }

        // GET: /Reagent/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReagent tblreagent = db.tblReagents.Find(id);
            if (tblreagent == null)
            {
                return HttpNotFound();
            }
            return View(tblreagent);
        }

        // POST: /Reagent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="reagentId,name,uom,createdBy,craetedDate,updatedBy,updatedDate")] tblReagent tblreagent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblreagent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblreagent);
        }

        // GET: /Reagent/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReagent tblreagent = db.tblReagents.Find(id);
            if (tblreagent == null)
            {
                return HttpNotFound();
            }
            return View(tblreagent);
        }

        // POST: /Reagent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblReagent tblreagent = db.tblReagents.Find(id);
            db.tblReagents.Remove(tblreagent);
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
