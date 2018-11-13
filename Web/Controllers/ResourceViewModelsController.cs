using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ResourceViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResourceViewModels
        public ActionResult Index()
        {
            return View(db.ResourceViewModels.ToList());
        }

        // GET: ResourceViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceViewModel resourceViewModel = db.ResourceViewModels.Find(id);
            if (resourceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(resourceViewModel);
        }

        // GET: ResourceViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,seniority,workProfil,salary,picture,moyenneSkill,jobType,cv,businessSector,availability,firstName,lastName,email,archived")] ResourceViewModel resourceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.ResourceViewModels.Add(resourceViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceViewModel);
        }

        // GET: ResourceViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceViewModel resourceViewModel = db.ResourceViewModels.Find(id);
            if (resourceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(resourceViewModel);
        }

        // POST: ResourceViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,seniority,workProfil,salary,picture,moyenneSkill,jobType,cv,businessSector,availability,firstName,lastName,email,archived")] ResourceViewModel resourceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceViewModel);
        }

        // GET: ResourceViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceViewModel resourceViewModel = db.ResourceViewModels.Find(id);
            if (resourceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(resourceViewModel);
        }

        // POST: ResourceViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceViewModel resourceViewModel = db.ResourceViewModels.Find(id);
            db.ResourceViewModels.Remove(resourceViewModel);
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
