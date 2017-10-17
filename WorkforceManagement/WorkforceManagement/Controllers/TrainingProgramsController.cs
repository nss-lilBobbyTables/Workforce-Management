using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkforceManagement.Models;

namespace WorkforceManagement.Controllers
{
    public class TrainingProgramsController : Controller
    {
        private WorkforceManagementContext db = new WorkforceManagementContext();

        // GET: TrainingPrograms
        public ActionResult Index()
        {
            return View(db.TrainingPrograms.ToList());
        }

        // GET: TrainingPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPrograms trainingPrograms = db.TrainingPrograms.Find(id);
            if (trainingPrograms == null)
            {
                return HttpNotFound();
            }
            return View(trainingPrograms);
        }

        // GET: TrainingPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Name,MaxCapacity,StartDate,EndDate")] TrainingPrograms trainingPrograms)
        {
            if (ModelState.IsValid)
            {
                db.TrainingPrograms.Add(trainingPrograms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingPrograms);
        }

        // GET: TrainingPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPrograms trainingPrograms = db.TrainingPrograms.Find(id);
            if (trainingPrograms == null)
            {
                return HttpNotFound();
            }
            return View(trainingPrograms);
        }

        // POST: TrainingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,MaxCapacity,StartDate,EndDate")] TrainingPrograms trainingPrograms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingPrograms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingPrograms);
        }

        // GET: TrainingPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPrograms trainingPrograms = db.TrainingPrograms.Find(id);
            if (trainingPrograms == null)
            {
                return HttpNotFound();
            }
            return View(trainingPrograms);
        }

        // POST: TrainingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingPrograms trainingPrograms = db.TrainingPrograms.Find(id);
            db.TrainingPrograms.Remove(trainingPrograms);
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
