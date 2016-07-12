using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class CombinedQAModel
    {
        [Key]
        public int ID { get; set; }
        public virtual SurveyQuestionsModel SurveyQuestions { get; set; }
        public virtual SurveyAnswersModel SurveyAnswers { get; set; }
    }
}