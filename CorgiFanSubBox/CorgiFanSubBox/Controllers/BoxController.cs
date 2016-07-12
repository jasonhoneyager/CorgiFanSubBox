using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CorgiFanSubBox.Models;

namespace CorgiFanSubBox.Controllers
{
    public class BoxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Box
        public ActionResult Index()
        {
            return View(db.Box.ToList());
        }

        // GET: Box/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxModel boxModel = db.Box.Find(id);
            if (boxModel == null)
            {
                return HttpNotFound();
            }
            return View(boxModel);
        }

        // GET: Box/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Box/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PremiumItem1,PremiumItem2,PremiumItem3,SurveyItem1,SurveyItem2,SurveyItem3")] BoxModel boxModel)
        {
            if (ModelState.IsValid)
            {
                db.Box.Add(boxModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boxModel);
        }

        // GET: Box/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxModel boxModel = db.Box.Find(id);
            if (boxModel == null)
            {
                return HttpNotFound();
            }
            return View(boxModel);
        }

        // POST: Box/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PremiumItem1,PremiumItem2,PremiumItem3,SurveyItem1,SurveyItem2,SurveyItem3")] BoxModel boxModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boxModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boxModel);
        }

        // GET: Box/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxModel boxModel = db.Box.Find(id);
            if (boxModel == null)
            {
                return HttpNotFound();
            }
            return View(boxModel);
        }

        // POST: Box/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxModel boxModel = db.Box.Find(id);
            db.Box.Remove(boxModel);
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
