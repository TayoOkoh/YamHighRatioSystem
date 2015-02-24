﻿using System;
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
    public class VarietyProcessFlowController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /VarietyProcessFlow/
        public ActionResult Index()
        {
            var tblvarietyprocessflows = db.tblVarietyProcessFlows.Include(t => t.tblVariety);
            return View(tblvarietyprocessflows.ToList());
        }

        // GET: /VarietyProcessFlow/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarietyProcessFlow tblvarietyprocessflow = db.tblVarietyProcessFlows.Find(id);
            if (tblvarietyprocessflow == null)
            {
                return HttpNotFound();
            }
            return View(tblvarietyprocessflow);
        }

        // GET: /VarietyProcessFlow/Create
        public ActionResult Create()
        {
            ViewBag.varietyId = new SelectList(db.tblVarieties, "varietyId", "name");
            return View();
        }

        // POST: /VarietyProcessFlow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="proccessId,varietyId,form,processDate,userId,rank,barcode,description,createdBy,createdDate,updatedBy,updatedDate")] tblVarietyProcessFlow tblvarietyprocessflow)
        {
            if (ModelState.IsValid)
            {
                db.tblVarietyProcessFlows.Add(tblvarietyprocessflow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.varietyId = new SelectList(db.tblVarieties, "varietyId", "name", tblvarietyprocessflow.varietyId);
            return View(tblvarietyprocessflow);
        }

        // GET: /VarietyProcessFlow/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarietyProcessFlow tblvarietyprocessflow = db.tblVarietyProcessFlows.Find(id);
            if (tblvarietyprocessflow == null)
            {
                return HttpNotFound();
            }
            ViewBag.varietyId = new SelectList(db.tblVarieties, "varietyId", "name", tblvarietyprocessflow.varietyId);
            return View(tblvarietyprocessflow);
        }

        // POST: /VarietyProcessFlow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="proccessId,varietyId,form,processDate,userId,rank,barcode,description,createdBy,createdDate,updatedBy,updatedDate")] tblVarietyProcessFlow tblvarietyprocessflow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblvarietyprocessflow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.varietyId = new SelectList(db.tblVarieties, "varietyId", "name", tblvarietyprocessflow.varietyId);
            return View(tblvarietyprocessflow);
        }

        // GET: /VarietyProcessFlow/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarietyProcessFlow tblvarietyprocessflow = db.tblVarietyProcessFlows.Find(id);
            if (tblvarietyprocessflow == null)
            {
                return HttpNotFound();
            }
            return View(tblvarietyprocessflow);
        }

        // POST: /VarietyProcessFlow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblVarietyProcessFlow tblvarietyprocessflow = db.tblVarietyProcessFlows.Find(id);
            db.tblVarietyProcessFlows.Remove(tblvarietyprocessflow);
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
