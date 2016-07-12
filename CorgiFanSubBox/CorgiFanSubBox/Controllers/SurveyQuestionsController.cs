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
    public class SurveyQuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SurveyQuestions
        public ActionResult Index()
        {
            return View(db.SurveyQuestionModels.ToList());
        }

        // GET: SurveyQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionsModel surveyQuestionsModel = db.SurveyQuestionModels.Find(id);
            if (surveyQuestionsModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionsModel);
        }

        // GET: SurveyQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question")] SurveyQuestionsModel surveyQuestionsModel)
        {
            if (ModelState.IsValid)
            {
                db.SurveyQuestionModels.Add(surveyQuestionsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surveyQuestionsModel);
        }

        // GET: SurveyQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionsModel surveyQuestionsModel = db.SurveyQuestionModels.Find(id);
            if (surveyQuestionsModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionsModel);
        }

        // POST: SurveyQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question")] SurveyQuestionsModel surveyQuestionsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyQuestionsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surveyQuestionsModel);
        }

        // GET: SurveyQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionsModel surveyQuestionsModel = db.SurveyQuestionModels.Find(id);
            if (surveyQuestionsModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionsModel);
        }

        // POST: SurveyQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyQuestionsModel surveyQuestionsModel = db.SurveyQuestionModels.Find(id);
            db.SurveyQuestionModels.Remove(surveyQuestionsModel);
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
