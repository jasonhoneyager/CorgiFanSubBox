using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class SurveyAnswersModel
    {
        [Key]
        public int ID { get; set; }
        public string Result { get; set; }
        public virtual ItemModel Item { get; set; }
    }
}