using FIRERISK.DAL;
using FIRERISK.Models;
using FIRERISK.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace FIRERISK.Controllers
{
    public class HomeController : Controller
    {
        private MinetContext db = new MinetContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}