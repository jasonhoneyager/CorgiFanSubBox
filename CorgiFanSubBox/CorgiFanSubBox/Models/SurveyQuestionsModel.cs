using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class SurveyQuestionsModel
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
    }
}