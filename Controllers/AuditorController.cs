using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIRERISK.DAL;
using FIRERISK.Models;

namespace FIRERISK.Controllers
{
    public class AuditorController : Controller
    {
        private MinetContext db = new MinetContext();

        // GET: Auditor
        public ActionResult Index()
        {
            return View(db.Auditors.ToList());
        }

        // GET: Auditor/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditor auditors = db.Auditors.Find(id);
            if (auditors == null)
            {
                return HttpNotFound();
            }
            return View(auditors);
        }

        // GET: Auditor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationNo,AuditorName,Organization,EmailAddress,PhoneNumber")] Auditor auditors)
        {
            if (ModelState.IsValid)
            {
                db.Auditors.Add(auditors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditors);
        }

        // GET: Auditor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditor auditors = db.Auditors.Find(id);
            if (auditors == null)
            {
                return HttpNotFound();
            }
            return View(auditors);
        }

        // POST: Auditor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationNo,AuditorName,Organization,EmailAddress,PhoneNumber")] Auditor auditors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditors);
        }

        // GET: Auditor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditor auditors = db.Auditors.Find(id);
            if (auditors == null)
            {
                return HttpNotFound();
            }
            return View(auditors);
        }

        // POST: Auditor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Auditor auditors = db.Auditors.Find(id);
            db.Auditors.Remove(auditors);
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
