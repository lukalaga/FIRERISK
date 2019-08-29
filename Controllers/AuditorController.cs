using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FIRERISK.DAL;
using FIRERISK.Models;

namespace FIRERISK.Controllers
{
    public class AuditorController : Controller
    {

        private MinetContext db = new MinetContext();

        public ActionResult GetAuditors()
        {
            var contacts = db.Auditors.Select(c => new
            {
                c.RegistrationNo,
                c.AuditorName,
                c.EmailAddress,
                c.Organization,
                c.PhoneNumber
            }).ToList();
            return Json(new { data = contacts }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string message = "";
            var v = db.Auditors.Where(a => a.AuditorName == login.AuditorName).FirstOrDefault();
            if (v != null)
            {
                if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                {
                    int timeout = login.RememberMe ? 525600 : 20;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(login.AuditorName, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                    {
                        Expires = DateTime.Now.AddMinutes(timeout),
                        HttpOnly = true
                    };
                    Response.Cookies.Add(cookie);


                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    message = "Invalid Credentials Provided";

                }
            }
            else
            {
                message = "Wrong Credentials Provided";
            }

            ViewBag.Message = message;
            return View();
        }

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
            Auditor auditor = db.Auditors.Find(id);
            if (auditor == null)
            {
                return HttpNotFound();
            }
            return View(auditor);
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
        public ActionResult Create([Bind(Include = "RegistrationNo,AuditorName,Organization,EmailAddress,PhoneNumber,Password")] Auditor auditor)
        {
            if (ModelState.IsValid)
            {


                auditor.Password = Crypto.Hash(auditor.Password);
                




                db.Auditors.Add(auditor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditor);
        }

        // GET: Auditor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditor auditor = db.Auditors.Find(id);
            if (auditor == null)
            {
                return HttpNotFound();
            }
            return View(auditor);
        }

        // POST: Auditor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationNo,AuditorName,Organization,EmailAddress,PhoneNumber,Password")] Auditor auditor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditor);
        }

        // GET: Auditor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditor auditor = db.Auditors.Find(id);
            if (auditor == null)
            {
                return HttpNotFound();
            }
            return View(auditor);
        }

        // POST: Auditor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Auditor auditor = db.Auditors.Find(id);
            db.Auditors.Remove(auditor);
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
