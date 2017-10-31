using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkforceManagement.Models;
using WorkforceManagement.ViewModels;

namespace WorkforceManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private WorkforceManagementContext db = new WorkforceManagementContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            } 
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Departments = new WorkforceManagementContext().Departments.ToList().Select(x =>
                new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }


        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MakeNewEmployeeRequest employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employees
                {
                    JobTitle = employee.JobTitle,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    StartDate = employee.StartDate,
                    Departments = db.Departments.Find(employee.DepartmentId)
                };
                db.Employees.Add(newEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Departments = new WorkforceManagementContext().Departments.ToList().Select(x =>
            new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            var employeeDetails = new MakeNewEmployeeRequest
            {
                JobTitle = employees.JobTitle,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                StartDate = employees.StartDate,
                DepartmentId = employees.Departments.Id


            };
            

            if (employees == null)
            {
                return HttpNotFound();
            }

            return View(employeeDetails);


        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTitle,FirstName,LastName,StartDate,Departments")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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
