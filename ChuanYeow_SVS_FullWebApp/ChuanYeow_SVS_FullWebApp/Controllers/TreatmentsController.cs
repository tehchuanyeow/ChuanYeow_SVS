using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChuanYeow_SVS_FullWebApp.Models;

namespace ChuanYeow_SVS_FullWebApp.Controllers
{
    public class TreatmentsController : Controller
    {
        private SVSEntities db = new SVSEntities();

        // GET: Treatments
        public ActionResult Index()
        {
            var treatments = db.Treatments.Include(t => t.Owner).Include(t => t.Pet).Include(t => t.Procedure);
            return View(treatments.ToList());
        }

        // GET: Treatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "Surname");
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName");
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Description");
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,OwnerID,ProcedureID,Date,Notes,Price")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "Surname", treatment.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", treatment.PetID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Description", treatment.ProcedureID);
            return View(treatment);
        }

        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "Surname", treatment.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", treatment.PetID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Description", treatment.ProcedureID);
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,OwnerID,ProcedureID,Date,Notes,Price")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "Surname", treatment.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", treatment.PetID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Description", treatment.ProcedureID);
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatment treatment = db.Treatments.Find(id);
            db.Treatments.Remove(treatment);
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
