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
    public class InventoryController : Controller
    {
        private CropBreedingUnitDBEntities db = new CropBreedingUnitDBEntities();

        // GET: /Inventory/
        public ActionResult Index()
        {
            var tblinventories = db.tblInventories.Include(t => t.tblReagent);
            return View(tblinventories.ToList());
        }

        // GET: /Inventory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInventory tblinventory = db.tblInventories.Find(id);
            if (tblinventory == null)
            {
                return HttpNotFound();
            }
            return View(tblinventory);
        }

        // GET: /Inventory/Create
        public ActionResult Create()
        {
            ViewBag.reagentId = new SelectList(db.tblReagents, "reagentId", "name");
            return View();
        }

        // POST: /Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="inventoryId,reagentId,quantity,stock,stockDate,stockUserId,initialStock,createdBy,createdDate,updatedBy,updatedDate")] tblInventory tblinventory)
        {
            if (ModelState.IsValid)
            {
                db.tblInventories.Add(tblinventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.reagentId = new SelectList(db.tblReagents, "reagentId", "name", tblinventory.reagentId);
            return View(tblinventory);
        }

        // GET: /Inventory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInventory tblinventory = db.tblInventories.Find(id);
            if (tblinventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.reagentId = new SelectList(db.tblReagents, "reagentId", "name", tblinventory.reagentId);
            return View(tblinventory);
        }

        // POST: /Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="inventoryId,reagentId,quantity,stock,stockDate,stockUserId,initialStock,createdBy,createdDate,updatedBy,updatedDate")] tblInventory tblinventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblinventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reagentId = new SelectList(db.tblReagents, "reagentId", "name", tblinventory.reagentId);
            return View(tblinventory);
        }

        // GET: /Inventory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInventory tblinventory = db.tblInventories.Find(id);
            if (tblinventory == null)
            {
                return HttpNotFound();
            }
            return View(tblinventory);
        }

        // POST: /Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblInventory tblinventory = db.tblInventories.Find(id);
            db.tblInventories.Remove(tblinventory);
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
