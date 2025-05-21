using System.Linq;
using System.Web.Mvc;
using GymManagement.Models;

namespace GymManagement.Controllers
{
    public class TrialController : Controller
    {
        private GymDbContext db = new GymDbContext();

        // GET: Trial/Register
        public ActionResult Register()
        {
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name");
            return View();
        }

        // POST: Trial/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TrialRegistration trial)
        {
            if (ModelState.IsValid)
            {
                db.TrialRegistrations.Add(trial);
                db.SaveChanges();
                TempData["Success"] = "Cảm ơn bạn đã đăng ký tập thử! Chúng tôi sẽ liên hệ sớm nhất.";
                return RedirectToAction("Register");
            }

            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", trial.PackageId);
            return View(trial);
        }
    }
}
