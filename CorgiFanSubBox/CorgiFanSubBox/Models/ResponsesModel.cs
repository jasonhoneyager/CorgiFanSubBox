using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class ResponsesModel
    {
        [Key]
        public int ID { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual SurveyQuestionsModel SurveyQuestions { get; set; }
        public virtual SurveyAnswersModel SurveyAnswers { get; set; }
    }
}