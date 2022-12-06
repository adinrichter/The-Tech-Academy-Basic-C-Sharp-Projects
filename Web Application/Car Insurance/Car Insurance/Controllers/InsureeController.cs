using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Insurance.Models;

namespace Car_Insurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }
        public ActionResult Admin()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DOB,VehicleYear,VehicleMake,VehicleModel,DUI,MovingViolations,FullCoverage,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // sets a base quote
                insuree.Quote = 50;

                // sets quote based on age and ensures it's within range of the correct age
                TimeSpan tsAge = DateTime.Now - insuree.DOB;
                double age = Math.Floor(tsAge.Days / 365.25);
                if (age >= 16 && age <= 18)
                {
                    insuree.Quote += 100;
                }
                else if (age >= 19 && age <= 25)
                {
                    insuree.Quote += 50;
                }
                else if (age >= 26)
                {
                    insuree.Quote += 25;
                }
                else
                {
                    return View("AgeError");
                }

                // adds price if vehicle was not made between 2000 and and 2015
                if (insuree.VehicleYear < 2000 || insuree.VehicleYear > 2015)
                {
                    insuree.Quote += 25;
                }

                // adds price if vehicle manufacturer is porsche
                if (insuree.VehicleMake.ToLower() == "porsche")
                {
                    insuree.Quote += 25;
                }
                
                // adds additional price if the vehicle manufacturer is porsche and the model is 911 carrera
                if (insuree.VehicleMake.ToLower() == "porsche" && insuree.VehicleModel.ToLower() == "911 carrera")
                {
                    insuree.Quote += 25;
                }

                // adds $10 for every moving violation
                insuree.Quote += 10 * insuree.MovingViolations;

                // increases price by 25% if the insuree has had a dui
                if (insuree.DUI)
                {
                    insuree.Quote *= 1.25m;
                }

                // increases price by 50% if insuree is getting full coverage
                if (insuree.FullCoverage)
                {
                    insuree.Quote *= 1.5m;
                }
                

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DOB,VehicleYear,VehicleMake,VehicleModel,DUI,MovingViolations,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
