using System.Linq;
using System.Web.Mvc;
using GymManagement.Models;
using System.Data.Entity;
using GymManagement.Filters;


namespace GymManagement.Controllers
{
   
   
    public class TrainerController : Controller
    {
        private GymDbContext db = new GymDbContext();

        // GET: Trainer
        public ActionResult Index()
        {
            var trainers = db.Trainers.ToList();
            return View(trainers);
        }
        [AuthorizeRole("Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        [AuthorizeRole("Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }
        // GET: Trainer/Edit/5
        [AuthorizeRole("Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var trainer = db.Trainers.Find(id);
            if (trainer == null)
                return HttpNotFound();

            return View(trainer);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        [AuthorizeRole("Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }
        // GET: Trainer/Delete/5
        [AuthorizeRole("Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var trainer = db.Trainers.Find(id);
            if (trainer == null)
                return HttpNotFound();

            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var trainer = db.Trainers.Find(id);
            if (trainer == null)
                return HttpNotFound();

            return View(trainer);
        }


    }
}
