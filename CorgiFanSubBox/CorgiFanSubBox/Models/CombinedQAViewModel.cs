using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class CombinedQAViewModel
    {
        [Display(Name = "Question")]
        public List<SurveyQuestionsModel> SurveyQuestions { get; set; }
        [Display(Name = "Result")]
        public List<SurveyAnswersModel> SurveyAnswers { get; set; }
        public List<CombinedQAModel> CombinedQAs { get; set; }
    }
}