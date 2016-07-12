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
    public class CombinedQAController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CombinedQA
        public ActionResult Index()
        {
            var x = db.SurveyQuestionModels.ToList();
            var y = db.SurveyAnswerModels.ToList();
            //var z = db.CombinedQAModels.Distinct().ToList();
            var m = db.CombinedQAModels.GroupBy(q => q.SurveyQuestions).Select( l => l.FirstOrDefault()).ToList();
            var c = new CombinedQAViewModel { SurveyQuestions = x, SurveyAnswers = y, CombinedQAs = m };          
            
            return View(c);
        }

        // GET: CombinedQA/Details/5
       

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
