using FIRERISK.DAL;
using FIRERISK.Models;
using FIRERISK.ViewModels;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FIRERISK.Controllers
{
    public class WorkplaceController : Controller
    {
        //instatiates database context
        private MinetContext db = new MinetContext();

        public ActionResult Index(string searchString)
        {
            var works = from s in db.Workplaces
                        select s;

            #region searching

            if (!string.IsNullOrEmpty(searchString))
            {
                works = works.Where(s => s.WorkplaceName.Contains(searchString));
            }

            #endregion searching

            return View(works.ToList());
        }

        // GET: Workplace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // GET: Workplace/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Workplace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]  //preventing cross site request forgery attacks
        public ActionResult Create([Bind(Include = "ID,WorkplaceName,PostalAddress,Date")] Workplace workplace)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Workplaces.Add(workplace);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(workplace);
        }

        // GET: Workplace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: Workplace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var WorkToUpdate = db.Workplaces.Find(id);
            if (TryUpdateModel(WorkToUpdate, "",
                new string[] { "WorkplaceName,PostalAddress,Date" }))
            {
                try
                {
                    db.SaveChanges();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(WorkToUpdate);
        }

        // GET: Workplace/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: Workplace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Workplace workplace = db.Workplaces.Find(id);
                db.Workplaces.Remove(workplace);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Statistics()
        {
            IQueryable<EnrollmentDateGroup> data = from Workplace in db.Workplaces
                                                   group Workplace by Workplace.Date into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       OrganizationCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        //closing database connections
        //to free up resources they hold
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